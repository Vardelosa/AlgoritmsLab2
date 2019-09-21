//Реалізувати структуру однозв’язного списку.Для виконання операцій з елементами заданої структури створити функції, які додатково реалізують:
//- !готово!пересування елемента на n позицій;
//- !готово!створення копії списку;
//- !готово!додавання елементу в початок списку;
//- !готово!склеювання двох списків;
//- !готово!видалення n-го елементу з списку;
//- !готово!вставлення елементу після n-го елементу списку;
//- !готово!створення списку, який містить спільні елементи двох списків;
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
            if (current == null)
            {
                Add(data);
            }
            else
            {
                next = current.Next;
                current.Next = node;
                node.Next = next;
                count++;
            }

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
        public LinkedList<T> Find_Equal(LinkedList<T> list2)
        {
            LinkedList<T> newList = new LinkedList<T>();
            foreach(var item in this)
            {
                foreach(var item1 in list2)
                {
                    if(item.Equals(item1))
                    {
                        newList.Add(item);
                    }
                }
            }
            return newList;
        }
    }   
    struct Footballer
    {
        public string surname;
        public Footballer(string surname)
        {
            this.surname = surname;
        }
        public void Printfootballer()
        {
            Console.WriteLine(surname);
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
           //Создаем футболистов
            LinkedList<Footballer> main_team = new LinkedList<Footballer>();
            LinkedList<Footballer> help_team = new LinkedList<Footballer>();
            Footballer[] footballers_main = new Footballer[3];
            Footballer[] footballers_help = new Footballer[3];
            footballers_main[0] = new Footballer("Aksenov");
            footballers_main[1] = new Footballer("Fedotov");
            footballers_main[2] = new Footballer("Kravchuk");
            footballers_help[0] = new Footballer("Yarmulin");
            footballers_help[1] = new Footballer("Kinohin");
            footballers_help[2] = new Footballer("Savin");
            for(int i=0;i<3;i++)
            {
                main_team.Add(footballers_main[i]);
                help_team.Add(footballers_help[i]);
            }
            ShowTheMainTeam();//Методы, выводящий элементы списка
            ShowTheHelpTeam();
            Console.WriteLine("How many changes do you want to make?");
            int k = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<k;i++)
            {
                Console.WriteLine("Enter index of the person in the main team");
                int ind = Convert.ToInt32(Console.ReadLine())-1;
                if (ind > 2)//Делаем так, чтоб пользователь не вылез за границы
                    ind = 2;
                if (ind < 0)
                    ind = 0;
                Console.WriteLine("Enter index of the person in the help team");
                int ind1 = Convert.ToInt32(Console.ReadLine())-1;
                if (ind1 > 2)
                    ind1 = 2;
                if (ind1 < 0)
                    ind1 = 0;
                main_team.Remove(ind);//Удаляем элементы, чтоб совершить замену
                help_team.Remove(ind1);
                for (int j = 0; j < 3; j++)
                {
                if(j==ind)
                {
                        if (j == 0)//Если элемент первым, то ставим его в начало
                        {
                            main_team.AppendFirst(footballers_help[ind1]);
                        }
                        else
                        {
                            main_team.Insert(footballers_help[ind1], ind-1);
                        }
                    }
                if(j==ind1)
                {
                        if (j == 0)
                        {
                            help_team.AppendFirst(footballers_main[ind]);
                        }
                        else
                        {
                            help_team.Insert(footballers_main[ind], ind1-1);
                        }
                    }
                    
                }
                Console.Clear();
                ShowTheMainTeam();
                ShowTheHelpTeam();
                UpdateTeams();//Метод, обновляющий массив футболистов
            }


            Console.ReadKey();
            void UpdateTeams()
            {
                int j = 0;
                int j1 = 0;
                foreach (var item in main_team)
                {
                    footballers_main[j] = item;
                    j++;                
                }
                foreach (var item in help_team)
                {
                    footballers_help[j1] = item;
                    j1++;
                }
            }
            void ShowTheMainTeam()
            {
               int i = 0;
                Console.WriteLine("Main team:");
                foreach (var item in main_team)
                {           
                    i++;
                    Console.WriteLine("{0}){1}", i, item.surname);
                }
            }
            void ShowTheHelpTeam()
            {
                int i = 0;
                Console.WriteLine("Help team:");
                foreach (var item in help_team)
                {
                    i++;
                    Console.WriteLine("{0}){1}", i, item.surname);
                }
            }
        }
    }
}
