//Реалізувати структуру однозв’язного списку.Для виконання операцій з елементами заданої структури створити функції, які додатково реалізують:
//- пересування елемента на n позицій;
//- створення копії списку;
//- !готово!додавання елементу в початок списку;
//- склеювання двох списків;
//- видалення n-го елементу з списку;
//- !готово!вставлення елементу після n-го елементу списку;
//- створення списку, який містить спільні елементи двох списків;
//- впорядкувати елементи в списку за зростанням(спаданням);
//- видалення кожного n-го елементу списку;
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

    public class LinkedList<T> : IEnumerable<T> where T: // IInterface // односвязный список
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
            //Node<T> current = head;
            //Node<T> previous = null;

            //while (current != null)
            //{
            //    if (current.Data.Equals(data))
            //    {
            //        // Если узел в середине или в конце
            //        if (previous != null)
            //        {
            //            // убираем узел current, теперь previous ссылается не на current, а на current.Next
            //            previous.Next = current.Next;

            //            // Если current.Next не установлен, значит узел последний,
            //            // изменяем переменную tail
            //            if (current.Next == null)
            //                tail = previous;
            //        }
            //        else
            //        {
            //            // если удаляется первый элемент
            //            // переустанавливаем значение head
            //            head = head.Next;

            //            // если после удаления список пуст, сбрасываем tail
            //            if (head == null)
            //                tail = null;
            //        }
            //        count--;
            //        return true;
            //    }

            //    previous = current;
            //    current = current.Next;
            //}
            //return false;

            Node<T> current = this.head;

            while(current.Data  data)
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
            Remove(current);
            if(n>0&n<Count-i)
            {
                Insert(node.Data, n);
            }
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
