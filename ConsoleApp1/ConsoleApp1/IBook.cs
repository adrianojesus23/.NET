namespace App
{
    public interface IBook
    {
       Book GetBookById(int id);
       IEnumerable<Book> GetBook();
    }
}