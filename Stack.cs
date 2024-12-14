using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_Homework_Class
{
    public class Stack
    {
        //предыдущий элемент связного списка, для первого элемента - равен нулю, для последующих - является ссылкой на предыдущий
        StackItem _PrevElement;
        public int _Size { get; set; }
        public string? _Top { get; set; }

        public Stack()
        {

        }
        /// <summary>
        /// Конструктор формирует список из массива строк, если они есть, а если нет - не формирует :)
        /// </summary>
        /// <param name="Strings"></param>
        public Stack(string[] Strings)
        {
            for (int i = 0; i < Strings.Length; i++)
            {
                if (i > 0)
                {
                    StackItem Item = new StackItem(Strings[i], _PrevElement);
                    _PrevElement = Item;
                }
            }

            _Size = Strings.Length;
            _Top = Strings[Strings.Length - 1];
        }

        /// <summary>
        /// Класс для хранения стека на замену листу
        /// </summary>
        private class StackItem
        {
            public string? _ElementValue { get; set; }
            public StackItem? _link { get; set; }

            public StackItem(string? elementValue, StackItem link)
            {
                _ElementValue = elementValue;
                _link = link;
            }
        }

        /// <summary>
        /// Добавляем элемент в стек
        /// </summary>
        /// <param name="String"></param>
        public void Add(string String)
        {
            StackItem Item = new StackItem(String, _PrevElement);
            _PrevElement = Item;

            _Size++;
            _Top = String;
            Console.WriteLine($"size = {_Size}, Top = '{_Top}'");
        }
        /// <summary>
        /// Извлекаем последний элемент из стека, удаляем его и возвращаем его значение
        /// </summary>
        /// <returns></returns>
        public string Pop()
        {
            if (_PrevElement == null)
            {
                return null;
            }

            _Size--;
            _Top = _PrevElement._ElementValue;

            string? String = _PrevElement._ElementValue;
            _PrevElement = _PrevElement._link;
            return String;
        }
    }
}
