using Api.Model;
using Api.ModelDto;

namespace Api.Storage;

public interface IStorage
{
    List<Contact> GetAll();
    Contact GetById(int id);
    bool Add(Contact contact);
    bool Remove(int id);
    bool Update(ContactDto contactDto, int id);
}
