using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Author> Authors = new Dictionary<string, Author>();

            Dictionary<string, Book> books = new Dictionary<string, Book>();

            Dictionary<string, House> House = new Dictionary<string, House>();

            Console.WriteLine("Здравствуйте");

            Menu();

            void Menu()
            {
                Console.WriteLine("1 - меню книг, 2 - список авторов. Остальные клавиши - выход");
                string selection = Console.ReadLine();
                while (selection != "0")
                {
                    switch (selection)
                    {
                        case "1":
                            InitBooks();
                            break;
                        case "2":
                            InfoAuthors();
                            break;
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }
            }

           
           void InitBooks()
            {
                Console.WriteLine("1 - добавить книгу. 2 - удалить книгу. 3 - вывести книги. Другое - выход в основное меню");
                string select = Console.ReadLine();
                if (select == "1")
                {
                    Console.WriteLine("Добавление книги.");
                    Console.Write("Введите название книги: ");
                    string name_book = Console.ReadLine();
                    string ISBN;
                    int pages;
                    DateTime pubYear;
                    string house;
                   
                    while (true)
                    {
                        Console.Write("Введите ISBN книги: ");
                        ISBN = Console.ReadLine();
                        if (ISBN == null || ISBN.Length != 10 || ISBN.Any(ch => ch < '0' || ch > '9'))
                        {
                            Console.WriteLine("Ошибка ввода ISBN, попробуйте снова. ISBN должен содержать 10 цифр");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    while (true)
                    {
                        Console.Write("Введите количество страниц: ");
                        pages = Int32.Parse(Console.ReadLine());
                        if (pages < 10 || pages > 13095)
                        {
                            Console.WriteLine("Ошибка ввода кол-ва страниц, попробуйте снова");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                                                       
                    while (true)
                    {
                        Console.Write("Введите дату публикации книги: ");
                        string d = Console.ReadLine();
                        try
                        {
                            pubYear = Convert.ToDateTime(d);
                            break;

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка ввода даты, попробуйте заново");
                            continue;
                        }
                    }


                    Console.Write("Введите издательский дом: ");
                    house = Console.ReadLine();
                   
                    List<string> authors_list = new List<string>();
                    
                    Console.Write("Введите автора: ");
                    string author = Console.ReadLine();
                    try
                    {
                        authors_list.Add(Authors[author].Name);
                    }
                    catch (KeyNotFoundException)
                    {
                        Author author1 = InitAuthors(author);
                        authors_list.Add(Authors[author].Name);
                    }

                    while (true)
                    {
                        Console.WriteLine("Введите ещё автора или нажмите 'Enter' если авторов больше нет");
                        string author_while = Console.ReadLine();
                        if (author_while == "")
                        {
                            break;
                        }
                        else
                        {
                            try
                            {
                                authors_list.Add(Authors[author_while].Name);
                            }
                            catch (KeyNotFoundException)
                            {
                                Author author1 = InitAuthors(author_while);
                                authors_list.Add(Authors[author_while].Name);
                            }
                        }
                    }
                
                    Book book = new Book() { Name = name_book, ISBN = ISBN, Pages = pages, PublicationYear = pubYear, House = house, Authors = authors_list };

                    books.Add(book.Name, book);
                    Authors[author].Books.Add(name_book);
                }
                else if (select == "2")
                {
                    Console.Write("Введите название книги которую вы хотите удалить: ");
                    string delete_object = Console.ReadLine();
                    books.Remove(delete_object);
                }
                else if (select == "3")
                {
                    foreach (KeyValuePair<string, Book> book in books)
                    {
                        Console.Write("{0}. ISBN: {1} Кол-во страниц: {2} Дата публикации книги: {3} ", book.Key, book.Value.ISBN, book.Value.Pages, book.Value.PublicationYear);
                        Console.Write("Автор(ы): ");
                        foreach (string autor in book.Value.Authors)
                        {
                            Console.Write(autor + " ");
                        }

                    }
                    Console.WriteLine();
                }
                else
                {
                    Menu();
                }
            }


            Author InitAuthors(string aut)
            {
                Console.WriteLine("Добавление автора {0}", aut);
                string name = aut;

                DateTime dateofbirth;
                while (true)
                {
                    Console.Write("Дата рождения: ");     
                    string date_born_author = Console.ReadLine();
                    try
                    {                       
                        dateofbirth = Convert.ToDateTime(date_born_author);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка ввода даты рождения");
                        continue;
                    }
                }
                

                Console.Write("Фото: ");
                string photo = Console.ReadLine();

                Author author = new Author() { Name = name, DayOfBirdth = dateofbirth, Photo = photo };

                Authors.Add(author.Name, author);

                return (author);
            }

            void InfoAuthors()
            {
                foreach(KeyValuePair<string, Author> author in Authors)
                {
                    Console.WriteLine(author.Key + " " +  author.Value.DayOfBirdth);
                    Console.Write("Книги: ");
                    foreach(string book in author.Value.Books)
                    {
                        Console.Write(book + " ");
                    }
                }
                Menu();
                
            }

            void InitHouse()
            {
                Console.WriteLine("Добавление издательства");
                Console.Write("Город: ");
                string city = Console.ReadLine();

            }
        }    
    }
}
