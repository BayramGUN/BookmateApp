using BookmateApp.DTOs.Responses;

namespace BookmateApp.Mvc.Models;

public class BookCollection
{
    public List<BookListItem> BookListItems { get; set; } = new List<BookListItem>();
    public string? LibraryName { get; set; }
    public void ClearAll() => BookListItems.Clear();
    public int TotalBookRates() => BookListItems.Sum(item => (int)item.Book.Rate);
    public float AvarageBookRates() => (float) TotalBookRates() / BookListItems.Count;

    public void AddBook(BookListItem bookListItem)
    {
        
        if(isExist(bookListItem))
            bookListItem.IsAdded = true;
        else
            BookListItems.Add(bookListItem);
        
    }
    public void RemoveBook(Guid id)
    {
            var bookListItem = BookListItems.FirstOrDefault(bI => bI.Book.Id == id);
            BookListItems.Remove(bookListItem);        
    }
    private bool isExist(BookListItem bookListItem) =>
        BookListItems.FirstOrDefault(b => b.Book.Id == bookListItem.Book.Id) is not null;
}
public class BookListItem
{ 
    public BookDisplayResponse Book { get; set; }
    public bool? IsRead { get; set; }
    public bool? IsAdded { get; set; }
}