using WebAPIWithCrud.Models;

namespace WebAPIWithCrud.Services;

/// <summary>
/// Business logic for items: in-memory storage and CRUD operations.
/// </summary>
public class ItemsService
{
    private readonly List<Items> _items = new();
    private int _nextId = 1;

    public IEnumerable<Items> GetAll() => _items;

    public Items? GetById(int id)
    {
        foreach (var item in _items)
        {
            if (item.Id == id)
                return item;
        }
        return null;
    }

    public Items Create(Items item)
    {
        item.Id = _nextId;
        _nextId++;
        _items.Add(item);
        return item;
    }

    public bool Update(int id, Items item)
    {
        Items? existingItem = null;

        foreach (Items candidate in _items)
        {
            if (candidate.Id == id)
            {
                existingItem = candidate;
                break;
            }
        }

        if (existingItem == null)
            return false;

        existingItem.Name = item.Name;
        return true;
    }

    public bool Delete(int id)
    {
        for (int i = _items.Count - 1; i >= 0; i--)
        {
            if (_items[i].Id == id)
            {
                _items.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}
