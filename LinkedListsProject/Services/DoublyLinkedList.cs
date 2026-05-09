using System;
using System.Collections.Generic;
using System.Linq;
using LinkedListsProject.Models;

namespace LinkedListsProject.Services
{
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        private Node<T> cabeza;
        private Node<T> cola;

        public void Add(T dato)
        {
            Node<T> nuevoNodo = new Node<T>(dato);

            if (cabeza == null)
            {
                cabeza = cola = nuevoNodo;
                return;
            }

            if (dato.CompareTo(cabeza.Dato) <= 0)
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza.Anterior = nuevoNodo;
                cabeza = nuevoNodo;
            }
            else if (dato.CompareTo(cola.Dato) >= 0)
            {
                nuevoNodo.Anterior = cola;
                cola.Siguiente = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                Node<T> actual = cabeza;
                while (actual != null && actual.Dato.CompareTo(dato) < 0)
                {
                    actual = actual.Siguiente;
                }
                nuevoNodo.Siguiente = actual;
                nuevoNodo.Anterior = actual.Anterior;
                actual.Anterior.Siguiente = nuevoNodo;
                actual.Anterior = nuevoNodo;
            }
        }

        public void Display(bool haciaAdelante)
        {
            Node<T> temporal = haciaAdelante ? cabeza : cola;
            if (temporal == null) return;

            while (temporal != null)
            {
                Console.Write($"[{temporal.Dato}] ");
                temporal = haciaAdelante ? temporal.Siguiente : temporal.Anterior;
            }
            Console.WriteLine();
        }

        public void SortDescending()
        {
            if (cabeza == null) return;

            Node<T> actual = cabeza;
            Node<T> temp = null;
            cola = cabeza;

            while (actual != null)
            {
                temp = actual.Anterior;
                actual.Anterior = actual.Siguiente;
                actual.Siguiente = temp;
                cabeza = actual;
                actual = actual.Anterior;
            }
        }

        public void ProcessStatistics(bool mostrarGrafico)
        {
            if (cabeza == null) return;

            var conteos = new Dictionary<T, int>();
            Node<T> temp = cabeza;
            while (temp != null)
            {
                if (conteos.ContainsKey(temp.Dato)) conteos[temp.Dato]++;
                else conteos[temp.Dato] = 1;
                temp = temp.Siguiente;
            }

            if (mostrarGrafico)
            {
                foreach (var entrada in conteos)
                {
                    Console.WriteLine($"{entrada.Key.ToString().PadRight(10)} | {new string('*', entrada.Value)} ({entrada.Value})");
                }
            }
            else
            {
                int max = conteos.Values.Max();
                var modas = conteos.Where(x => x.Value == max).Select(x => x.Key);
                Console.WriteLine("Moda(s): " + string.Join(", ", modas));
            }
        }

        public bool Search(T dato)
        {
            Node<T> temp = cabeza;
            while (temp != null)
            {
                if (temp.Dato.Equals(dato)) return true;
                temp = temp.Siguiente;
            }
            return false;
        }

        public void Remove(T dato, bool eliminarTodos)
        {
            Node<T> actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Equals(dato))
                {
                    if (actual == cabeza)
                    {
                        cabeza = cabeza.Siguiente;
                        if (cabeza != null) cabeza.Anterior = null;
                    }
                    else if (actual == cola)
                    {
                        cola = cola.Anterior;
                        if (cola != null) cola.Siguiente = null;
                    }
                    else
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = actual.Anterior;
                    }

                    if (!eliminarTodos) return;
                }
                actual = actual.Siguiente;
            }
        }
    }
}