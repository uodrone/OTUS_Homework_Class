using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_Homework_Class
{
    public class Stack
    {
        public List<string> StringList = new List<string>();
        public int Size { get; set; }
        public string? Top {  get; set; }

        public Stack()
        {
            
        }
        /// <summary>
        /// Конструктор формирует список из массива строк, если они есть, а если нет - не формирует :)
        /// </summary>
        /// <param name="Strings"></param>
        public Stack(string[] Strings)
        {
            foreach (string String in Strings)
            { 
                StringList.Add(String);
            }

            Size = Strings.Length;
            Top = Strings[Strings.Length - 1];
        }

        /// <summary>
        /// Добавляем элемент в стек
        /// </summary>
        /// <param name="String"></param>
        public void Add(string String)
        {
            StringList.Add(String);
            Size++;
            Top = String;
            Console.WriteLine($"size = {Size}, Top = '{Top}'");
        }
        /// <summary>
        /// Извлекаем последний элемент из стека, удаляем его и возвращаем его значение
        /// </summary>
        /// <returns></returns>
        public string Pop()
        {
            string String = StringList[StringList.Count - 1];
            StringList.RemoveAt(StringList.Count - 1);
            Size--;
            Top = StringList.Last();
            return String;
        }

        public void ViewList ()
        {
            Console.WriteLine("Список строк:");
            Console.WriteLine(string.Join(",", StringList));
            Console.WriteLine($"Количество элементов в списке: {Size}, Финальный элемент: {Top}");
        }
        
        public static Stack Concat(Stack[] StackArray)
        {
            Stack ReverseStack = new Stack();

            foreach (Stack Stack in StackArray) {
                for (int i = Stack.StringList.Count; i > 0; i--)
                {
                    ReverseStack.StringList.Add(Stack.StringList[i - 1]);
                }
            }

            return ReverseStack;
        }
    }
}
