using Microsoft.AspNetCore.Mvc;
using WebAPIWithCrud.Models;
using WebAPIWithCrud.Services;

namespace WebAPIWithCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ItemsService _itemsService;

    public ItemsController(ItemsService itemsService)
    {
        _itemsService = itemsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Items>> GetAll()
    {
        return Ok(_itemsService.GetAll());
    }


    [HttpGet("{id:int}")]
    public ActionResult<Items> Get(int id)
    {
        var item = _itemsService.GetById(id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public ActionResult<Items> Create(Items item)
    {
        var created = _itemsService.Create(item);
        return Created($"/api/items/{created.Id}", created);
    }

    [HttpPut("{id:int}")]
    public ActionResult Update(int id, Items item)
    {
        if (!_itemsService.Update(id, item))
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        if (!_itemsService.Delete(id))
            return NotFound();
        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public ActionResult Patch(int id, [FromBody] ItemPatchDto patch)
    {
        if (!_itemsService.Patch(id, patch.Name))
            return NotFound();
        return NoContent();
    }
}

public class ItemPatchDto
{
    public string? Name { get; set; }
}
