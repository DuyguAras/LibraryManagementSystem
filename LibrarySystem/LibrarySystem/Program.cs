using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace LibraryManagementSystem
{
    class Program
    {
        private static int bookNumber;

        static List<string> bookTitles = new List<string>();

        static List<string> bookAuthors = new List<string>();
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

            Choices();

            Console.ReadLine();
        }
        public static void Choices()
        {
            Console.Write("What would you like to do?: ");
            string choice = Console.ReadLine();

            switch (int.Parse(choice))
            {
                case 1:
                    BookTitle(bookTitles);
                    BookAuthor(bookAuthors);
                    break;
                case 2:
                    BorrowBook(bookTitles);
                    break;
                case 3:
                    ReturnBook(bookTitles);
                    break;
                case 4:
                    SearchBook(bookTitles, bookAuthors);
                    break;
                case 5:
                    ViewAllBooks(bookTitles);
                    break;

            }


        }

        public static void BookTitle(List<string> titleList)
        {
            Console.Write("Please enter the book title: ");

            do
            {
                string bookTitle = Console.ReadLine();
                bookNumber++;

                if (bookTitle.Length < 2 || bookTitle.Length > 30)
                {
                    Console.WriteLine("The entered title is invalid.\n");
                    Console.Write("Please enter the book title again: ");
                }
                else
                {
                    titleList.Add(bookTitle);
                    Console.WriteLine($"{bookTitle} has been added to the library.\n");
                    break;
                }
            } while (true);


        }

        public static void BookAuthor(List<string> authorList)
        {
            Console.Write("Please enter the author's name: ");

            do
            {
                string bookAuthor = Console.ReadLine();

                if (bookAuthor.Length < 2 || bookAuthor.Length > 50)
                {
                    Console.WriteLine("The entered name is invalid.\n");
                    Console.Write("Please enter the author name again: ");
                }
                else
                {
                    authorList.Add(bookAuthor);
                    Console.WriteLine($"{bookAuthor} has been added to the library.\n");
                    Choices();
                }
            } while (true);
        }

        public static void BorrowBook(List<string> titleList)
        {
            Console.Write("Please enter the title of the book you want to borrow: ");

            string bookTitle = Console.ReadLine();
            Console.WriteLine($"You borrowed {bookTitle}!");

            titleList.Remove(bookTitle);
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

        public static void ViewAllBooks(List<string> titleList)
        {
            Console.WriteLine("The number of books in the library is " + bookNumber);
        }
    }
}
