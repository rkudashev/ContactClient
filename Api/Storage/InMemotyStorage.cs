using Api.Model;
using Api.ModelDto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Storage;

public class InMemoryStorage : IStorage
{
    private List<Contact> contacts;
    public InMemoryStorage()
    {
        contacts = [];
    }

    public List<Contact> GetAll()
    {
        return contacts;
    }

    public Contact GetById(int id)
    {
        foreach(var contact in contacts)
        {
            if(contact.Id == id)
            {
                return contact;
            }
        }

        return Contact.Unknown;
    }

    public Contact Add(ContactDto contact)
    {
        var last = contacts.MaxBy(c => c.Id);

        contacts.Add(new Contact()
        {
            Id = last.Id + 1,
            Name = contact.Name,
            Email = contact.Email
        }
        );
        return contacts.Last();
    }

    public bool Remove(int id)
    {
        foreach(var contact in contacts)
        {
            if(contact.Id == id)
            {
                contacts.Remove(contact);
                return true;
            }
        }

        return false;
    }

    public bool Update(ContactDto contactDto, int id)
    {
        foreach(var contact in contacts)
        {
            if(contact.Id == id)
            {
                if(!string.IsNullOrEmpty(contactDto.Name))
                {
                    contact.Name = contactDto.Name;
                }

                if(!string.IsNullOrEmpty(contactDto.Email))
                {
                    contact.Email = contactDto.Email;
                }

                return true;
            }
        }
        return false;
    }
}