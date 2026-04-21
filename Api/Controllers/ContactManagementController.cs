using Api.Model;
using Api.ModelDto;
using Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class ContactManagementController : BaseController
{
    private readonly ContactStorage storage;
    public ContactManagementController(ContactStorage storage)
    {
        this.storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        var res = storage.Add(contact);

        if(res)
        {
            return Created();
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
}