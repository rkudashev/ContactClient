using System.Text;
using Api.Model;
using Api.ModelDto;
using Microsoft.Data.Sqlite;

namespace Api.Storage;

public class SqLiteStorage : IStorage
{
    private readonly string connectionString;

    public SqLiteStorage(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public bool Add(Contact contact)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        string sql = @"
            INSERT INTO contacts (name, email) 
            VALUES ($name, $email)";

        command.CommandText = sql;
        command.Parameters.AddWithValue("$name", contact.Name);
        command.Parameters.AddWithValue("$email", contact.Email);

        return command.ExecuteNonQuery() > 0;
    }

    public List<Contact> GetAll()
    {
        var contacts = new List<Contact>();

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM contacts";

        using var reader = command.ExecuteReader(); 

        while(reader.Read())
        {
            contacts.Add(
                new Contact()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2)
                }
            );
        }

        return contacts;
    }

    public Contact GetById(int id)
    {
        var contact = Contact.Unknown;

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        string sql = @"SELECT * FROM contacts WHERE id = $id";
        command.CommandText = sql;
        command.Parameters.AddWithValue("$id", id);

        using var reader = command.ExecuteReader(); 

        while(reader.Read())
        {
            contact = (
                new Contact()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2)
                }
            );
        }

        return contact;
    }

    public bool Remove(int id)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        string sql = @"DELETE FROM contacts WHERE id = $id";
        command.CommandText = sql;
        command.Parameters.AddWithValue("$id", id);
        
        return command.ExecuteNonQuery() > 0;
    }

    public bool Update(ContactDto contactDto, int id)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        string sql = @"
            UPDATE contacts 
            SET name = $name, email = $email 
            WHERE id = $id";

        command.CommandText = sql;
        command.Parameters.AddWithValue("$name", contactDto.Name);
        command.Parameters.AddWithValue("$email", contactDto.Email);
        command.Parameters.AddWithValue("$id", id);

        return command.ExecuteNonQuery() > 0;
    }
}