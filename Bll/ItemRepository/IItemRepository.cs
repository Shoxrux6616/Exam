using Dal.Entity;

namespace Repositoriy.ItemRepository;

public interface IItemRepository
{
    Task<long> InsertToDoItemAsync(Item toDoItem);
    Task DeleteToDoItemByIdAsync(long id);
    Task UpdateToDoItemAsync(Item toDoItem);
    Task<ICollection<Item>> SelectAllToDoItemsAsync(int skip, int take);
    Task<Item> SelectToDoItemByIdAsync(long id);
    Task<ICollection<Item>> SelectByDueDateAsync(DateTime dueDate);
    Task<ICollection<Item>> SelectCompletedAsync(int skip, int take);
    Task<ICollection<Item>> SelectIncompleteAsync(int skip, int take);
    Task<ICollection<Item>> SearchToDoItemsAsync(string keyword);
    Task<ICollection<Item>> SelectOverdueItemsAsync();
    Task<ICollection<Item>> GetUpcomingDeadlinesAsync();
    Task<int> SelectTotalCountAsync();
    IQueryable<Item> SelectAllToDoItems();
}