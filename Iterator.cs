using System;
using System.Collections;
using System.Collections.Generic;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
    void Reset();
}

public interface ILibraryCollection
{
    IIterator<Book> CreateIterator();
    int Count { get; }
    Book this[int index] { get; set; }
}

public class Book
{
    public string Title { get; }
    public string Author { get; }
    public int Year { get; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title} ({Author}, {Year})";
    }
}

public class Library : ILibraryCollection
{
    private List<Book> _books = new List<Book>();

    public int Count => _books.Count;

    public Book this[int index]
    {
        get => _books[index];
        set => _books.Insert(index, value);
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public IIterator<Book> CreateIterator()
    {
        return new LibraryIterator(this);
    }
}

public class LibraryIterator : IIterator<Book>
{
    private readonly ILibraryCollection _collection;
    private int _currentIndex = 0;

    public LibraryIterator(ILibraryCollection collection)
    {
        _collection = collection;
    }

    public bool HasNext()
    {
        return _currentIndex < _collection.Count;
    }

    public Book Next()
    {
        return _collection[_currentIndex++];
    }

    public void Reset()
    {
        _currentIndex = 0;
    }
}

class Program
{
    static void Main()
    {

        var library = new Library();
        library.AddBook(new Book("Война и мир", "Лев Толстой", 1869));
        library.AddBook(new Book("Преступление и наказание", "Фёдор Достоевский", 1866));
        library.AddBook(new Book("Мастер и Маргарита", "Михаил Булгаков", 1967));

      
        var iterator = library.CreateIterator();

        Console.WriteLine("Все книги в библиотеке:");
        while (iterator.HasNext())
        {
            var book = iterator.Next();
            Console.WriteLine($"- {book}");
        }

        iterator.Reset();

        Console.WriteLine("\nПервая книга в коллекции:");
        var newIterator = library.CreateIterator();
        if (newIterator.HasNext())
        {
            Console.WriteLine(newIterator.Next());
        }
    }
}
