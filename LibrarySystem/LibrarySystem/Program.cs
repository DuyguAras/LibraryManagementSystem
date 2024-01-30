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

            books.Add(new Book("Donusum", "Franz Kafka", "978-605-2169-29-2", 1111, false, false, false));
            books.Add(new Book("Delifisek", "Vasconcelos", "978-605-2169-29-2", 2222, true, false, false));

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
                        ReturnBook(books);
                        break;
                    case 4:
                        SearchBook(books);
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

            Book newBook = new Book(title, author, ISBN, copy, false, false, false);
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
                if (ISBN.Length != 17)
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

            Choices();

            return 0;   
        }

        public static void BorrowBook(List<Book> borrowInfo)
        {
            Console.Write("Please enter the title of the book you want to borrow: ");

            string borrowed = Console.ReadLine();

            bool isBorrowed = false;

            foreach (Book book in borrowInfo)
            {
                if (book.title == borrowed)
                {
                    
                    if (book.borrowed)
                    {
                        Console.WriteLine("The entered book is already borrowed.\n");
                    }
                    else
                    {
                        Console.WriteLine("You borrowed " + book.title + ".");
                    }
                    
                    isBorrowed = true;
                    break;
                } 
            }

            if (!isBorrowed)
            {
                Console.WriteLine("The entered book is not available.\n");
                BorrowBook(books);
                
            }

            Choices();
        }

        public static void ReturnBook(List<Book> returnedInfo)
        {
            Console.Write("Please enter the title of the book you want to return: ");

            string returned = Console.ReadLine();

            bool isReturned = false;

            foreach (Book book in returnedInfo)
            {
                if (book.title == returned)
                {
                    isReturned = true;
                    Console.WriteLine("You returned " + book.title);
                    break;
                } 
            }

            if (!isReturned)
            {
                Console.WriteLine("The entered title is not available in the library.\n");
                ReturnBook(books); 
            }

            Choices();
        }

        public static void SearchBook(List<Book> searchedInfo)
        {
            Console.Write("Please enter the title or the author or the ISBN of the book you want to search for: ");

            string searched = Console.ReadLine();
     
            bool isSearched = false;

            foreach (Book book in searchedInfo)
            {
                if (book.title == searched  || book.author == searched || book.ISBN == searched)
                {
                    isSearched = true;

                    Console.WriteLine($"Title: {book.title} ");
                    Console.WriteLine($"Author: {book.author} ");
                    Console.WriteLine($"ISBN: {book.ISBN} ");
                    Console.WriteLine($"Copy number: {book.copy} ");
                    Console.WriteLine($"Is it borrowed?: {book.borrowed} \n");
                }
            }

            if (!isSearched)
            {
                Console.WriteLine("The entered data is not available in the library.\n");
                SearchBook(books);
            }

            Choices();
        }

        public static void ViewAllBooks(List<Book> bookInfo)
        {
            Console.WriteLine($"The number of books in the library is {bookInfo.Count} \n");

            foreach (var book in bookInfo)
            {
                Console.WriteLine($"Title: {book.title} ");
                Console.WriteLine($"Author: {book.author} ");
                Console.WriteLine($"ISBN: {book.ISBN} ");
                Console.WriteLine($"Copy number: {book.copy} ");
                Console.WriteLine($"Is it borrowed?: {book.borrowed} \n");
            }

            Choices();
        }

        public class Book
        {
            public string title;
            public string author;
            public string ISBN;
            public int copy;
            public bool borrowed;
            public bool returned;
            public bool searched;

            public Book(string title, string author, string ISBN, int copy, bool borrowed, bool returned, bool searched)
            {
                this.title = title;
                this.author = author;
                this.ISBN = ISBN;
                this.copy = copy;
                this.borrowed = borrowed;
                this.returned = returned;
                this.searched = searched;
            }
        }
    }
}

