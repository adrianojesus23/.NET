using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
  

    public class Book : IBook
    {
        GetList bookBases = new GetList();

        public IEnumerable<Book> GetBook()
        {
            return (IEnumerable<Book>)GetList.GetLists();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }

    internal class GetList : IList<BookBase>
    {

        public static IEnumerable<BookBase> GetLists()
        {
            yield return new BookBase { Id = 1, Name = "Jesus" };
            yield return new BookBase { Id = 2, Name = "Laura" };
            yield return new BookBase { Id = 3, Name = "Gabriel" };
        }

        public BookBase this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(BookBase item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(BookBase item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(BookBase[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<BookBase> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(BookBase item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, BookBase item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(BookBase item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
