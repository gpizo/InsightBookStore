using System;
using System.Collections.Generic;
using System.Text;

namespace InsightTecnicalTest
{
    public enum BookCategory
    {
        Crime = 1,
        Romance = 2,
        Fantasy = 3
    }

    public interface IBook
    {
        string Title { get; }
        BookCategory Category { get; }
    }

    public class Book : IBook
    {
        public string Title { get; private set; }
        public BookCategory Category { get; private set; }
        public Book(string title, BookCategory category)
        {
            Title = title;
            Category = category;
        }
    }
}
