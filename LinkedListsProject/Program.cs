using System;
using LinkedListsProject.Services;

namespace LinkedListsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> lista = new DoublyLinkedList<string>();
            string op = "";

            while (op != "0")
            {
                Console.WriteLine("\n--- MENU DE LISTAS DOBLES ---");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Mostrar (A-Z)");
                Console.WriteLine("3. Mostrar (Z-A)");
                Console.WriteLine("4. Invertir");
                Console.WriteLine("5. Ver Moda");
                Console.WriteLine("6. Ver Grafico");
                Console.WriteLine("7. Buscar");
                Console.WriteLine("8. Eliminar uno");
                Console.WriteLine("9. Eliminar todos");
                Console.WriteLine("0. Salir");
                Console.Write("\nOpcion: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Console.Write("Dato: ");
                        lista.Add(Console.ReadLine());
                        break;
                    case "2": lista.Display(true); break;
                    case "3": lista.Display(false); break;
                    case "4": lista.SortDescending(); break;
                    case "5": lista.ProcessStatistics(false); break;
                    case "6": lista.ProcessStatistics(true); break;
                    case "7":
                        Console.Write("Buscar: ");
                        Console.WriteLine(lista.Search(Console.ReadLine()) ? "Encontrado" : "No existe");
                        break;
                    case "8":
                        Console.Write("Eliminar: ");
                        lista.Remove(Console.ReadLine(), false);
                        break;
                    case "9":
                        Console.Write("Eliminar todos: ");
                        lista.Remove(Console.ReadLine(), true);
                        break;
                }
            }
        }
    }
}