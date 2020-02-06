using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace NodesPractice
{
    class Program
    {
        static bool CheckPositive(List<int> l)
        {
            bool flag = true;
            Node<int> n1 = l.GetFirst();
            while (flag && n1 != null)
            {
                if (n1.GetInfo() < 1)
                {
                    flag = false;
                }
                n1 = n1.GetNext();
            }
            return flag;
        }

        static double Average(List<int> l)
        {
            double sum = 0;
            int counter = 0;
            Node<int> n1 = l.GetFirst();
            while (n1 != null)
            {
                sum += n1.GetInfo();
                counter++;
                n1 = n1.GetNext();
            }
            return sum/counter;
        }

        static void PrintEven(List<int> l)
        {
            Node<int> n1 = l.GetFirst();
            while (n1 != null)
            {
                if (n1.GetInfo() %  2 == 0)
                {
                    Console.WriteLine(n1);
                }
                n1 = n1.GetNext();
            }
        }

        static void PrintNodes(Node<int> first)
        {
            Node<int> temp = first;
            Console.Write("[");
            while (temp != null)
            {
                Console.Write(" { "+temp.GetInfo()+" } ");
                temp = temp.GetNext();
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }

        static int GetNumOf(List<int> l)
        {
            int counter = 0;
            Node<int> n1 = l.GetFirst();
            while (n1 != null)
            {
                counter++;
                n1 = n1.GetNext();
            }
            return counter;
        }

        static bool IsFound1(Node<int> chain, int x)
        {
            Node<int> temp = chain;
            while (temp.GetNext() != null)
            {
                if (temp.GetInfo() + temp.GetNext().GetInfo() == x)
                {
                    return true;
                }
                temp = temp.GetNext();
            }
            return false;
        }

        static void PrintNames(Node<string> chain1, Node<int> chain2)
        {
            Node<string> tempNames = chain1;
            Node<string> firstName = chain1;
            Node<int> tempNums = chain2;
            int counter = 1;

            while (tempNums != null)
            {
                if (counter == tempNums.GetInfo())
                {
                    tempNums = tempNums.GetNext();
                    Console.WriteLine(tempNames.GetInfo());
                    tempNames = firstName;
                    counter = 1;
                }

                else
                {
                    counter++;
                    tempNames = tempNames.GetNext();
                     
                }
            }
        }

        static void GrowingSequence(Node<int> chain)
        {
            Node<int> temp = chain;
            Node<int> first = chain;
            int temp1;
            bool flag = false;
            bool hadMistake = true;
            while (flag == false)
            {
                if (temp.GetNext() != null && temp.GetInfo() > temp.GetNext().GetInfo())
                {
                    hadMistake = true;    
                    temp1 = temp.GetInfo();
                    temp.SetInfo(temp.GetNext().GetInfo());
                    temp.GetNext().SetInfo(temp1);
                }

                    temp = temp.GetNext();

                if (temp.GetNext() == null && !hadMistake)
                {
                    flag = true;
                }

                if (temp.GetNext() == null)
                {
                    temp = first;
                    hadMistake = false;
                }
            }
        }

        static bool AllDifferent(Stack<int> s)
        {
            Stack<int> temp = new Stack<int>();
            int counter = 0, counter1 = 0, num = 0, counter2 = 0;
            while (!s.IsEmpty())
            {
                counter++;
                temp.Push(s.Pop());
            }

            while (!temp.IsEmpty())
            {
                s.Push(temp.Pop());
            }

            while (counter1 != counter)
            {
                for (int i = 0; i <= counter1; i++)
                { 
                    if (i == counter1)
                    {
                        num = s.Top();
                    }
                    temp.Push(s.Pop());
                }

                while (!temp.IsEmpty())
                {
                    s.Push(temp.Pop());
                }

                while (!s.IsEmpty())
                {
                    if (s.Top() == num)
                        counter2++;
                    temp.Push(s.Pop());
                    
                }

                while (!temp.IsEmpty())
                {
                    s.Push(temp.Pop());
                }

                if (counter2 > 1)
                    return false;
                counter2 = 0;
                counter1++;
            }
            return true;
        }

        static void Main(string[] args)
        {
            List<int> l1 = new List<int>();
            Node<int> first = new Node<int>(4);
            Node<int> n1 = new Node<int>(2);
            Node<int> n2 = new Node<int>(1);
            Node<int> n3 = new Node<int>(5);
            Node<int> n4 = new Node<int>(3);

            Node<string> firstN = new Node<string>("Mike");
            Node<string> name1 = new Node<string>("Guy");
            Node<string> name2 = new Node<string>("Nathan");
            Node<string> name3 = new Node<string>("Jack");
            Node<string> name4 = new Node<string>("Roy");

            first.SetNext(n1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);

            firstN.SetNext(name1);
            name1.SetNext(name2);
            name2.SetNext(name3);
            name3.SetNext(name4);

            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(10);
            s.Push(3);
            s.Push(11);
            s.Push(11);
            s.Push(14);
            s.Push(39);

            Console.WriteLine(AllDifferent(s));
               
        }
    }
}
