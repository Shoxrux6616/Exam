using Dal;
using Dal.Entity;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoriy.ItemRepository;

    public class ItemRepository : IItemRepository
    {

    private readonly MainContext MainContext;

    public ItemRepository(MainContext mainDbContext)
    {
        MainContext = mainDbContext;
    }

    public async Task DeleteToDoItemByIdAsync(long id)
    {
        var toDoItem = await SelectToDoItemByIdAsync(id);
        MainContext.ToDoItems.Remove(toDoItem);
        await MainContext.SaveChangesAsync();
    }

    public Task<ICollection<Item>> GetUpcomingDeadlinesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<long> InsertToDoItemAsync(Item toDoItem)
    {
        await MainContext.ToDoItems.AddAsync(toDoItem);
        await MainContext.SaveChangesAsync();
        return toDoItem.ItemId;

    }

    public Task<ICollection<Item>> SearchToDoItemsAsync(string keyword)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Item> SelectAllToDoItems()
    {
        return MainContext.ToDoItems;
    }

    public async Task<ICollection<Item>> SelectAllToDoItemsAsync(int skip, int take)
    {
        if (skip < 0 || take <= 0)
        {
            throw new ArgumentOutOfRangeException("Skip and take must be non-negative and take must be greater than zero.");
        }
        return await MainContext.ToDoItems
              .Skip(skip)
              .Take(take)
              .ToListAsync();
    }

    public async Task<ICollection<Item>> SelectByDueDateAsync(DateTime dueTime)
    {
        var query = MainContext.ToDoItems
            .Where(t => t.DueDate.Date == dueTime);
        return await query.ToListAsync();
    }

    public async Task<ICollection<Item>> SelectCompletedAsync(int skip, int take)
    {
        if (skip < 0 || take <= 0)
        {
            throw new ArgumentOutOfRangeException("Skip and take must be non-negative and take must be greater than zero.");
        }

        var query = MainContext.ToDoItems
            .Where(t => t.IsCompleted)
            .Skip(skip)
            .Take(take);

        return await query.ToListAsync();
    }

    public async Task<ICollection<Item>> SelectIncompleteAsync(int skip, int take)
    {
        if (skip < 0 || take <= 0)
        {
            throw new ArgumentOutOfRangeException("Skip and take must be non-negative and take must be greater than zero.");
        }
        var query = MainContext.ToDoItems
            .Where(t => !t.IsCompleted)
            .Skip(skip)
            .Take(take);

        return await query.ToListAsync();
    }

    public Task<ICollection<Item>> SelectOverdueItemsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Item> SelectToDoItemByIdAsync(long id)
    {
        var toDoItem = await MainContext.ToDoItems.FirstOrDefaultAsync(x => x.ItemId == id);

        return toDoItem;
    }

    public async Task<int> SelectTotalCountAsync()
    {
        return await MainContext.ToDoItems.CountAsync();
    }

    public async Task UpdateToDoItemAsync(Item toDoItem)
    {
        MainContext.ToDoItems.Update(toDoItem);
        await MainContext.SaveChangesAsync();
    }

}

