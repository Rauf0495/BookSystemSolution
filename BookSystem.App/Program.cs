using BookSystem.App.Models;
using BookSystem.Lib;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace BookSystem.App
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Helpers.Init("Rauf V1");            

            Book[] books = new Book[0];
            l1:
            Helpers.PrintMenu();

            MenuStates m = Helpers.ReadMenu("Birini Secin:");       

            Console.Clear();
                       

            switch (m)
            {
                case MenuStates.BooksAll:

                    Console.WriteLine("List of Books");

                    foreach (var item in books)
                    {
                        Console.WriteLine(item);
                    }
                    goto l1;

                case MenuStates.BooksId:

                    int Id = Helpers.ReadInt("Kitabin Id nomresini qeyd edin:");

                    if (Id == 0)
                    {
                        goto case MenuStates.BooksAll;
                    }

                    var search = new Book(Id);

                    int index=Array.IndexOf(books, search);                    

                    if (index!=-1)
                    {
                        search = books[index];
                        Console.Clear();
                        Console.WriteLine($"Tapildi: {search}");
                        goto l1;
                    }

                    Helpers.Printerror("Kitap Tapilmadi");
                    goto case MenuStates.BooksId;
                                                         

                case MenuStates.BooksAdd:
                    int len = books.Length;//<<<<<<<<<<<<<<<<<<<<--------------------------------
                    Array.Resize(ref books, len + 1);

                    books[len] = new Book();
                    books[len].Name = Helpers.ReadString("Kitabin adi:", true);
                    books[len].Author = Helpers.ReadString("Kitabin Muellifi:", true);
                    books[len].PageCount = Helpers.ReadInt("Kitabin sehifesayi:",1);
                    books[len].Price = Helpers.ReadDouble("Kitabin qiymeti:",0.50);
                    Console.Clear();
                    goto case MenuStates.BooksAll;            
                    
                case MenuStates.BooksEdit:

                    Console.WriteLine("List of Books");

                    foreach (var item in books)
                    {
                        Console.WriteLine(item);
                    }


                    int edit = Helpers.ReadInt("Kitabin Id nomresini qeyd edin:",1);

                    if (edit == 0)
                    {
                        goto case MenuStates.BooksAll;
                    }

                    var searchedit = new Book(edit);

                    int indexEdit = Array.IndexOf(books, searchedit);

                    if (indexEdit != -1)
                    {
                        searchedit = books[indexEdit];
                        Console.Clear();
                        Console.WriteLine($"Tapildi: {searchedit}");

                        searchedit.Name = Helpers.ReadString("Kitabin adi:", true);
                        searchedit.Author = Helpers.ReadString("Kitabin Muellifi:", true);
                        searchedit.PageCount = Helpers.ReadInt("Kitabin sehifesayi:", 1);
                        searchedit.Price = Helpers.ReadDouble("Kitabin qiymeti:", 0.50);

                        Console.Clear();

                        goto case  MenuStates.BooksAll;
                    }

                    Helpers.Printerror("Kitap Tapilmadi");
                    goto case MenuStates.BooksEdit;
                    
                case MenuStates.BooksRemove:
                    break;
                case MenuStates.AuthorAll:
                    break;
                case MenuStates.AuthorById:
                    break;
                case MenuStates.AuthorAdd:
                    break;
                case MenuStates.AuthorEdit:
                    break;
                case MenuStates.Authorremove:
                    break;
                case MenuStates.Save:
                    break;
                case MenuStates.Exit:
                    break;
                default:
                    break;
            }



        }

        
    }
}
