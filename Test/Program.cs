using System;
using System.Linq;

namespace Test
{
    class Program
    {
        private static Model1Container1 connection { get; set; }

        static void Main(string[] args)
        {
            connection = new Model1Container1();
            while (true)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1.Добавить книгу");
                Console.WriteLine("2.Добавить автора");
                Console.WriteLine("3.Вывести книги");
                Console.WriteLine("4.Вывести авторов");
                Console.WriteLine("5.Поиск по автору");
                Console.WriteLine("6.Удаление книги");
                if (int.TryParse(Console.ReadLine(), out int i))
                {

                    switch (i)
                    {
                        case 1: { Console.Clear(); BookAdd(); break; }
                        case 2: { Console.Clear(); AuthorAdd(); break; }
                        case 3: { Console.Clear(); ShowBooks(); break; }
                        case 4: { Console.Clear(); ShowAuthor(); break; }
                        case 5: { Console.Clear(); SearchByAuthor(); break; }
                        case 6: { Console.Clear(); DeleteBook(); break; }

                    }
                }
                else Console.WriteLine("Неверный выбор");
            }
        }

        private static void BookAdd()
        {
            Console.WriteLine("Введите имя книги:");
            string _nm = Console.ReadLine();
            if (_nm.Length <= 30)
            {
                Console.WriteLine("Введите год:");
                if (int.TryParse(Console.ReadLine(), out int _year))
                {
                    connection.BooksSet.Add(new Books() { Name = _nm, Year = _year });
                    connection.SaveChanges();
                    Console.WriteLine("Введите номера авторов через запятую");
                    foreach (Author item in connection.AuthorSet)
                    {
                        Console.WriteLine(item.Id_author + "." + item.Name);
                    }
                    string[] aut = Console.ReadLine().Split(',');
                    foreach (string item in aut)
                    {
                        int bokId = connection.BooksSet.Select(x => x.Id_book).Max();
                        connection.BookAuthorSet.Add(new BookAuthor() { Id_author = int.Parse(item), Id_book = bokId});

                    }
                    connection.SaveChanges();
                }
                else Console.WriteLine("Введено неверное значение");
            }
            else
            {
                Console.WriteLine("Имя книги больше 30 символов");
                Console.WriteLine();
                BookAdd();

            }
        }

        private static void DeleteBook()
        {
            Console.WriteLine("Введите номер книги для удаления");
           
                foreach (var item in connection.BooksSet)
                {
                Console.WriteLine(item.Id_book+"."+item.Name);

                }
            Console.WriteLine();
            if (int.TryParse(Console.ReadLine(), out int _delid))
            {
                connection.BooksSet.Remove(connection.BooksSet.Find(_delid));
                connection.SaveChanges();
            }
            else Console.WriteLine("Неверное значение");
        }

        private static void SearchByAuthor()
        {
            if (connection.AuthorSet.Count() != 0)
            {
                foreach (var item in connection.AuthorSet)
                {
                    Console.WriteLine(item.Id_author + "." + item.Name);

                }
                Console.WriteLine();
                Console.WriteLine("Выберите номер автора для поиска");
                if (int.TryParse(Console.ReadLine(), out int _idAuthor))
                {

                    var res = connection.BookAuthorSet.Where(x => x.Id_author == _idAuthor).Select(f => f.Id_book);
                    var names = connection.BooksSet.Join(res, 
                                                        p => p.Id_book, 
                                                        c => c, 
                                                        (p, c) => new 
                                                        {
                                                            Name = p.Name

                                                        });

                    foreach (var authorEntity in names)
                    {
                        Console.WriteLine(authorEntity.Name);
                    }

                }
                else Console.WriteLine("Записей нет!");
                Console.WriteLine();
            }
        }

        private static void ShowAuthor()
        {
            if (connection.AuthorSet.Count() != 0)
            {
                foreach (var item in connection.AuthorSet)
                {
                    Console.WriteLine(item.Id_author + "." + item.Name); 

                }
                Console.WriteLine();
            }
            else Console.WriteLine("Записей нет!");
            Console.WriteLine();
        }

        private static void ShowBooks()
        {
            if (connection.BooksSet.Count() != 0)
            {
                var result = from BookAuthor in connection.BookAuthorSet
                             join Author in connection.AuthorSet on BookAuthor.Id_author equals Author.Id_author
                             select new
                             {
                                 Name = Author.Name,
                                 Id_book = BookAuthor.Id_book,

                             };


                foreach (var item in connection.BooksSet)
                {
                    string s = item.Id_book + "." + item.Name + " " + item.Year;
                    foreach (string z in result.Where(x => x.Id_book == item.Id_book).Select(f => f.Name))
                    {
                        s += " " + z;

                    }

                    Console.WriteLine(s);

                }
            }
            else Console.WriteLine("Записей нет!");
            Console.WriteLine();
        }

        private static void AuthorAdd()
        {
            Console.WriteLine("Введите имя автора:");
            var _nm = Console.ReadLine();
            if (_nm.Length <= 20)
            {
                connection.AuthorSet.Add(new Author() { Name = _nm });
                connection.SaveChanges();
                Console.WriteLine();
            }
            else {
                Console.WriteLine("Фамилия больше 20 символов");
                Console.WriteLine();
                AuthorAdd();
                }   
        
        }

    }
}