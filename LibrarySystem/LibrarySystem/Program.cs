using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    class LibrarySystem
    {
        private static List<Book> books = new List<Book>();

        static void Main()
        {
            //1- kitap ekle isim ve yazar+numara ve kopya-
            //2- kitap odunc al+
            //3- kitap iade et+
            //4- kitap ara+
            //5- tum kitaplari goruntule
            //6- tarihi gecmis kitaplari goruntule
            //7- basa don

            Console.WriteLine("Welcome to Library!\n");
            Console.WriteLine("Please press '1' to add a book.");
            Console.WriteLine("'2' to borrow a book.");
            Console.WriteLine("'3' to return a book.");
            Console.WriteLine("'4' to search for a book by title or author.");
            Console.WriteLine("'5' to view all books.");
            Console.WriteLine("'6' to view overdue books.");
            Console.WriteLine("To go back to the beginning, press the 'q' key.\n");

            books.Add(new Book("Donusum", "Franz Kafka", "978-605-2169-29-2", 1111, false, false));

            Choices();

            Console.ReadLine();
        }

        public static void Choices()
        {
            Console.Write("What would you like to do?: ");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int choiceNumber))
            {
                switch (choiceNumber)
                {
                    case 1:
                        CreateNewBook();
                        break;
                    case 2:
                        BorrowBook(books);
                        break;
                    case 3:
                        //ReturnBook(bookTitles);
                        break;
                    case 4:
                        //SearchBook(bookTitles, bookAuthors);
                        break;
                    case 5:
                        ViewAllBooks(books);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid number.\n");
                        Choices();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
                Choices();
            }
        }

        private static void CreateNewBook()
        {
            string title = BookTitle();
            string author = BookAuthor();
            string ISBN = BookISBN();
            int copy = BookCopy();

            Book newBook = new Book(title, author, ISBN, copy, false, false);
            books.Add(newBook);

            Choices();
        }

        public static string BookTitle()
        {
            Console.Write("Please enter the book title: ");

            string title = Console.ReadLine();

            do
            {
                if (title.Length < 2 || title.Length > 30)
                {
                    Console.WriteLine("The entered title is invalid.\n");
                    BookTitle();
                    break;
                }
                else
                {

                    Console.WriteLine(title + " has been added to the library.\n");
                    return title;
                }
            } while (true);

            return null;
        }

        public static string BookAuthor()
        {
            Console.Write("Please enter the author's name: ");

            string author = Console.ReadLine();

            do
            {
                if (author.Length < 2 || author.Length > 50)
                {
                    Console.WriteLine("The entered name is invalid.\n");
                    BookAuthor();
                    break;
                }
                else
                {
                    Console.WriteLine(author + " has been added to the library.\n");
                    return author;
                }
            } while (true);

            return null;
        }

        public static string BookISBN()
        {
            Console.Write("Please enter the ISBN: ");

            string ISBN = Console.ReadLine();

            do
            {
                if (ISBN.Length != 2)
                {
                    Console.WriteLine("The entered ISBN is invalid.\n");
                    BookISBN();
                    break;
                }
                else
                {
                    Console.WriteLine(ISBN + " has been added to the library.\n");
                    return ISBN;
                }
            } while (true);

            return null;
        }

        public static int BookCopy()
        {
            Console.Write("Please enter the copy number: ");

            int copy = int.Parse(Console.ReadLine());

            do
            {
                if (copy <= 0)
                {
                    Console.WriteLine("The entered copy number is invalid.\n");
                    BookCopy();
                    //Console.Write("Please enter the copy number again: ");
                    break;
                }
                else
                {
                    Console.WriteLine(copy + " has been added to the library.\n");
                    return copy;
                }
            } while (true);

            return 0;
        }

        public static void BorrowBook(List<Book> borrowInfo)
        {
            Console.Write("Please enter the title of the book you want to borrow: ");

            string borrowed = Console.ReadLine();

            foreach (Book book in borrowInfo)
            {
                if (book.borrowed)
                {
                    Console.WriteLine("The entered book is not available.\n");
                }
                else
                {
                    Console.WriteLine("You borrowed " + book.title);
                }
            }
             
            
        }

        public static void ReturnBook(List<string> titleList)
        {
            Console.Write("Please enter the title of the book you want to return: ");

            string bookTitle = Console.ReadLine();
            Console.WriteLine($"You returned {bookTitle}!");

            titleList.Add(bookTitle);
        }

        public static void SearchBook(List<string> titleList, List<string> authorList)
        {
            Console.Write("Please enter the title or the author of the book you want to search for: ");

            string bookTitle = Console.ReadLine();
            string bookAuthor = Console.ReadLine();

            foreach (var title in titleList)
            {
                if (bookTitle == title)
                {
                    Console.WriteLine($"The book {bookTitle} is available in the library.");
                }
                else
                {
                    Console.WriteLine($"The book {bookTitle} could not be found in the library.");
                }
            }

            foreach (var author in authorList)
            {
                if (bookAuthor == author)
                {
                    Console.WriteLine($"The author {bookAuthor} is available in the library.");
                }
                else
                {
                    Console.WriteLine($"The author {bookAuthor} could not be found in the library.");
                }
            }
        }

        public static void ViewAllBooks(List<Book> bookInfos)
        {
            Console.WriteLine($"The number of books in the library is {bookInfos.Count} \n");

            foreach (var book in bookInfos)
            {
                Console.WriteLine($"Title: {book.title} ");
                Console.WriteLine($"Author: {book.author} ");
                Console.WriteLine($"ISBN: {book.ISBN} ");
                Console.WriteLine($"Copy number: {book.copy} ");
                Console.WriteLine($"Is it borrowed?: {book.borrowed} \n");
            }
        }

        public class Book
        {
            public string title;
            public string author;
            public string ISBN;
            public int copy;
            public bool borrowed;
            public bool returned;

            public Book(string title, string author, string ISBN, int copy, bool borrowed, bool returned)
            {
                this.title = title;
                this.author = author;
                this.ISBN = ISBN;
                this.copy = copy;
                this.borrowed = borrowed;
                this.returned = returned;
            }
        }
    }
}

