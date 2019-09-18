//Реалізувати структуру однозв’язного списку.Для виконання операцій з елементами заданої структури створити функції, які додатково реалізують:
//- !готово!пересування елемента на n позицій;
//- !готово!створення копії списку;
//- !готово!додавання елементу в початок списку;
//- !готово!склеювання двох списків;
//- !готово!видалення n-го елементу з списку;
//- !готово!вставлення елементу після n-го елементу списку;
//- створення списку, який містить спільні елементи двох списків;
//- впорядкувати елементи в списку за зростанням(спаданням);
//- !готово!видалення кожного n-го елементу списку;
//- !готово!очищення списку.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsLaba2
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public object Re { get; internal set; }
    }

    public class LinkedList<T> : IEnumerable<T> //where T: // IInterface // односвязный список
    {
        Node<T> head; // первый элемент
        Node<T> tail; // последний элемент
        int count;  // количество элементов
        public void Insert(T data, int n)
        {
            if (n < 0 || n > count)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node<T> node = new Node<T>(data);
            Node<T> current = head;
            Node<T> next = null;
            int i = 0;
                while (i != n)
                {
                    i++;
                    current = current.Next;                 
                }
                next = current.Next;
                current.Next = node;
                node.Next = next;
                count++;

        }    
        
            // добавление элемента
            public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        // удаление элемента
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }
        public bool Remove(int n)
        {
            Node<T> current = head;
            Node<T> previous = null;
            int i = 0;
            while (current != null)
            {
                if (n < 0)
                    n = 0;
                if (n > count)
                    n = count-1;
                if (i==n)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                ++i;
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public void Remove_Each(int n)
        {
            if (n == 1)
            {
                Clear();
            }
            else
            {
                n = n - 1;
                for (int i = 1; i < count; i++)
                {
                    if (i % n == 0)
                    {
                        Remove(i);
                    }
                }
            }
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public void Move(int index, int n)
        {
            Node<T> node = null;
            Node<T> current = head;
            int i = 0;
            while (index != i)
            {
                i++;
                current = current.Next;
            }
            node = current;
            Remove(current.Data);
            if (n > 0 & n < Count)
            {
                Insert(node.Data, n);
            }

        }
        public LinkedList<T> Copy()
        {
            LinkedList<T> newList = new LinkedList<T>();
            foreach (var item in this)
            {
                newList.Add(item);
            }
            return newList;
        }
        public Node<T> Step(int n)
        {
            Node<T> node = head;

            for (int i = 0; i < n; ++i)
            {
                if (node == null)
                    break;

                node = node.Next;
            }

            return node;
        }
        public static void Connect(LinkedList<T> list1, LinkedList<T> list2)
        {
            Node<T> node = list1.Step(list1.Count - 1);
            node.Next = list2.head;
        }
        public void Find_Equal(LinkedList<T> list1, LinkedList<T> list2)
        {
            for(int i=0; i<list1.Count;i++)
            {
                for (int j = 0; i < list2.Count; i++)
                {

                }
            }
        }
    }   

   
    class Program
    {
        static void Main(string[] args)
        {
           
            LinkedList<string> linkedList = new LinkedList<string>();
            void ShowThelist()
            {
                foreach (var item in linkedList)
                {
                    Console.WriteLine(item);
                }
            }
            // добавление элементов
            linkedList.Add("Tom");
            linkedList.Add("Alice");
            linkedList.Add("Bob");
            linkedList.Add("Sam");
            linkedList.Add("Tom");
            linkedList.Add("Alice");
            linkedList.Add("Bob");
            linkedList.Add("Sam");
            linkedList.Add("Tom");
            linkedList.Add("Alice");
            linkedList.Add("Bob");
            linkedList.Add("Sam");
            ShowThelist();
            Console.WriteLine("______________________");
            linkedList.Remove_Each(1);
            ShowThelist();
            
//Console.WriteLine("Delete on DATA");
//            linkedList.Remove("Alice");
//            ShowThelist();
//            Console.WriteLine("DELETE on index");
//            linkedList.Remove(100);
//            ShowThelist();
            //// выводим элементы
            //ShowThelist();
            //Console.WriteLine("____________________");
            //linkedList.Insert("John", 3);
            //ShowThelist();
            //Console.WriteLine("____________________");
            //linkedList.Insert("Walfey", 3);
            //ShowThelist();
            //Console.WriteLine("____________________");
            //linkedList.Move(1, 2);
            //ShowThelist();
            //Console.WriteLine("_________________");
            //linkedList.Move(3, 4);
            //ShowThelist();
            //    Console.WriteLine("__________SOMETEST___________");
            //LinkedList<string> linkedList1 = new LinkedList<string>();
            //linkedList.Copy();
            //linkedList1 = linkedList.Copy();
            //foreach (var item in linkedList1)
            //{
            //    Console.WriteLine(item);
            //}
            //linkedList1.Add("Matthew");
            //Console.WriteLine("NEW LIST_____________");
            //foreach (var item in linkedList1)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("OLD LIST_____________");
            //ShowThelist();
            

            Console.ReadKey();
        }
    }
}
