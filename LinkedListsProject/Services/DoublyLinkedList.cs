using LinkedListsProject.Models;

namespace LinkedListsProject.Services
{
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = tail = newNode;
                return;
            }

            if (data.CompareTo(head.Data) <= 0)
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            else if (data.CompareTo(tail.Data) >= 0)
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current != null && current.Data.CompareTo(data) < 0)
                {
                    current = current.Next;
                }
                newNode.Next = current;
                newNode.Previous = current.Previous;
                current.Previous.Next = newNode;
                current.Previous = newNode;
            }
        }

        public void Display(bool forward)
        {
            Node<T> temp = forward ? head : tail;
            if (temp == null) return;

            while (temp != null)
            {
                Console.Write($"[{temp.Data}] ");
                temp = forward ? temp.Next : temp.Previous;
            }
            Console.WriteLine();
        }

        public void SortDescending()
        {
            if (head == null) return;

            Node<T> current = head;
            Node<T> temp = null;
            tail = head;

            while (current != null)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                head = current;
                current = current.Previous;
            }
        }

        public void ProcessStatistics(bool showGraph)
        {
            if (head == null) return;

            var counts = new Dictionary<T, int>();
            Node<T> temp = head;
            while (temp != null)
            {
                if (counts.ContainsKey(temp.Data)) counts[temp.Data]++;
                else counts[temp.Data] = 1;
                temp = temp.Next;
            }

            if (showGraph)
            {
                foreach (var entry in counts)
                {
                    Console.WriteLine($"{entry.Key.ToString().PadRight(10)} | {new string('*', entry.Value)} ({entry.Value})");
                }
            }
            else
            {
                int max = counts.Values.Max();
                var modes = counts.Where(x => x.Value == max).Select(x => x.Key);
                Console.WriteLine("Mode(s): " + string.Join(", ", modes));
            }
        }

        public bool Search(T data)
        {
            Node<T> temp = head;
            while (temp != null)
            {
                if (temp.Data.Equals(data)) return true;
                temp = temp.Next;
            }
            return false;
        }

        public void Remove(T data, bool removeAll)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current == head)
                    {
                        head = head.Next;
                        if (head != null) head.Previous = null;
                    }
                    else if (current == tail)
                    {
                        tail = tail.Previous;
                        if (tail != null) tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                    if (!removeAll) return;
                }
                current = current.Next;
            }
        }
    }
}