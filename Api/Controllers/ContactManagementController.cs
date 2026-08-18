using Api.Model;
using Api.ModelDto;
using Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class ContactManagementController : BaseController
{
    private readonly IPaginationStorage storage;
    public ContactManagementController(IPaginationStorage storage)
    {
        this.storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] ContactDto contact)
    {
        var res = storage.Add(contact);

        if(res.Id != -1)
        {
            return Created(nameof(Create), res);
        }

        return Conflict();
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(storage.GetAll());
    }

    [HttpGet("contacts/{id}")]
    public ActionResult<Contact> GetById(int id)
    {
        var contact = storage.GetById(id);

        if(contact.Id == -1)
        {
            return NotFound(contact);
        }

        return Ok(contact);
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteById(int id)
    {
        var res = storage.Remove(id);

        if(res)
        {
            return NoContent();
        }

        return BadRequest("Ошибка id");
    }


    [HttpPut("contacts/{id}")]
    public IActionResult UpdateById([FromBody] ContactDto contactDto, int id)
    {
        var res = storage.Update(contactDto, id);

        if(res)
        {
            return Ok();
        }

        return Conflict("Контакт с таким id не найден");
    }

    [HttpGet("contacts/page")]
    public IActionResult GetContacts(int pageNumber = 1, int pageSize = 5)
    {
        var (contacts, total) = storage.GetContacts(pageNumber, pageSize);

        var response = new
        {
            Contacts = contacts,
            TotalCount = total,
            CurrentPage = pageNumber,
            PageSize = pageSize
        };

        return Ok(response);
    }
}