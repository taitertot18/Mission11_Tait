namespace Mission11_Tait.Models;

public interface IBookRepository
{
    public IQueryable<Book> Books { get; }
}