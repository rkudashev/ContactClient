using System.Text;
using Api.DataContext;
using Api.Model;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Api.Seed;

public class SqliteEfFakerInitializer : IInitializer
{
    private readonly SqliteDbContext context;

    public SqliteEfFakerInitializer(SqliteDbContext context)
    {
        this.context = context;
    }

    public void Initialize()
    {
        context.Database.Migrate();

        if(!context.Contacts.Any())
        {
            var faker = new Faker<Contact>("ru")
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Email, (f, c) => GenerateEmailForName(c.Name));

            var contacts = faker.Generate(200);

            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }
    }

    private string GenerateEmailForName(string name)
    {
        string email = Transliterate(name)
            .ToLower()
            .Replace(" ", ".") + "@mail.ru";

        return email;
    }

    private string Transliterate(string data)
    {
        Dictionary<char, string> alphabet = new Dictionary<char, string>()
        {
            {'а', "a"}, {'б', "b"},  {'в', "v"},  {'г', "g"}, {'д', "d"},
            {'е', "e"}, {'ё', "yo"}, {'ж', "zh"}, {'з', "z"}, {'и', "i"},
            {'й', "y"}, {'к', "k"},  {'л', "l"},  {'м', "m"}, {'н', "n"},
            {'о', "o"}, {'п', "p"},  {'р', "r"},  {'с', "s"}, {'т', "t"},
            {'у', "u"}, {'ф', "f"},  {'х', "kh"}, {'ц', "ts"}, {'ч', "ch"},
            {'ш', "sh"}, {'щ', "shch"}, {'ъ', ""}, {'ы', "y"}, {'ь', ""},
            {'э', "e"}, {'ю', "yu"}, {'я', "ya"}
        };

        StringBuilder sb = new();

        foreach(var ch in data.ToLower())
        {
            bool res = alphabet.TryGetValue(ch, out string str);

            if (res)
            {
                sb.Append(str);
            }
            else
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }
}