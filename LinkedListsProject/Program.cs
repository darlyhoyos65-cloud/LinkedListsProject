using System;
using LinkedListsProject.Services;

namespace LinkedListsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            string option = "";

            while (option != "0")
            {
                Console.WriteLine("\n--- LINKED LISTS SYSTEM ---");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Show Forward");
                Console.WriteLine("3. Show Backward");
                Console.WriteLine("4. Sort Descending");
                Console.WriteLine("5. Show Mode");
                Console.WriteLine("6. Show Graph");
                Console.WriteLine("7. Search");
                Console.WriteLine("8. Remove One");
                Console.WriteLine("9. Remove All");
                Console.WriteLine("0. Exit");
                Console.Write("\nSelect an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter data: ");
                        list.Add(Console.ReadLine());
                        break;
                    case "2":
                        list.Display(true);
                        break;
                    case "3":
                        list.Display(false);
                        break;
                    case "4":
                        list.SortDescending();
                        break;
                    case "5":
                        list.ProcessStatistics(false);
                        break;
                    case "6":
                        list.ProcessStatistics(true);
                        break;
                    case "7":
                        Console.Write("Search for: ");
                        Console.WriteLine(list.Search(Console.ReadLine()));
                        break;
                    case "8":
                        Console.Write("Value to remove: ");
                        list.Remove(Console.ReadLine(), false);
                        break;
                    case "9":
                        Console.Write("All values to remove: ");
                        list.Remove(Console.ReadLine(), true);
                        break;
                }
            }
        }
    }
}