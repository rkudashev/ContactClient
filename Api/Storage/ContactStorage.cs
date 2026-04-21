using Api.Model;
using Api.ModelDto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Storage;
public class ContactStorage
{
    private List<Contact> contacts;
    public ContactStorage()
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

    public bool Add(Contact contact)
    {
        foreach(var item in contacts)
        {
            if(item.Id == contact.Id)
            {
                return false;
            }
        }

        contacts.Add(contact);
        return true;
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