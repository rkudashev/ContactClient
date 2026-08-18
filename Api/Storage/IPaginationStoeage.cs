using Api.Model;

namespace Api.Storage;

public interface IPaginationStorage : IStorage
{
    (List<Contact>, int TotalCount) GetContacts(int pageNumber, int pageSize);
}