using Api.DataContext;
using Api.Model;
using Api.ModelDto;

namespace Api.Storage;

public class SqliteEfStorage(SqliteDbContext context) : IStorage
{
    private readonly SqliteDbContext context = context;

    public Contact Add(ContactDto contact)
    {
        context.Contacts.Add(
            new Contact()
            {
               Name = contact.Name,
               Email = contact.Email 
            }
        );
        context.SaveChanges();

        return context.Contacts.Single(c => c.Email == contact.Email) ?? Contact.Unknown;
    }

    public List<Contact> GetAll() => context.Contacts.ToList();

    public Contact GetById(int id)
    {
        var contact = context.Contacts.Find(id);

        if(contact == null)
        {
            return Contact.Unknown;
        }

        return contact;
    }

    public bool Remove(int id)
    {
        var contact = context.Contacts.Find(id);

        if(contact == null)
        {
            return false;
        }

        context.Contacts.Remove(contact);
        context.SaveChanges();

        return true;
    }

    public bool Update(ContactDto contactDto, int id)
    {
        var contact = context.Contacts.Find(id);

        if(contact == null)
        {
            return false;
        }

        contact.Name = contactDto.Name;
        contact.Email = contactDto.Email;
        context.SaveChanges();

        return true;
    }
}