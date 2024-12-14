namespace OTUS_Homework_Class
{
    public class Program
    {

        static void Main()
        {
            Stack stack = InitStack();

            StackCommandHandler(ref stack);
        }

        public static Stack InitStack() {
            List<string> ListString = new List<string>();

            Console.WriteLine("Введите строки, а когда закончите - введите пустую строку (Enter)");
            string? str;
            do
            {
                str = Console.ReadLine();
                if (!string.IsNullOrEmpty(str))
                {
                    ListString.Add(str);
                }
            }
            while (!string.IsNullOrEmpty(str));


            string[] StringArray = ListString.ToArray();

            Stack stack = new Stack(StringArray);

            stack.ViewList();

            return stack;
        }

        static void StackCommandHandler(ref Stack stack)
        {
            Console.WriteLine();
            Console.WriteLine("Привет, я Иван Иваныч, чего тебе надобно?");
            Console.WriteLine("Чтобы добавить элемент в стек нажми 1");
            Console.WriteLine("Чтобы удолить элемент стека нажми 2");
            Console.WriteLine("Чтобы добавить реверс второго стека к первому нажми 3");
            Console.WriteLine("Чтобы получить стек из реверсов N стеков нажми 4");
            Console.WriteLine("Чтобы выйти из программы нажмите Esc");

            var ComandKey = Console.ReadKey();
            Console.WriteLine();
            

            switch (ComandKey.Key) {
                case ConsoleKey.Escape:
                    Console.WriteLine("Произвожу выход из программы");
                    return;
                break;
                case ConsoleKey.D1:
                    Console.WriteLine("Введите строку, которую нужно добавить:");
                    string? AddString;
                    do
                    {
                        AddString = Console.ReadLine();
                        if (!string.IsNullOrEmpty(AddString))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            stack.Add(AddString);
                            stack.ViewList();
                        } else
                        {
                            Console.WriteLine("строка пустая!");
                        }
                    } while (string.IsNullOrEmpty(AddString));                    
                    break;
                case ConsoleKey.D2:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string WitdrawString = stack.Pop();
                        Console.WriteLine($"Извлек верхний элемент '{WitdrawString}' Size = {stack.Size}");
                        Console.WriteLine($"size = {stack.Size}, Top = {(stack.Top == null ? "null" : stack.Top)}");
                    }
                    catch (Exception) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Стек пустой, совсем пустой, не могу удолить");
                    }
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Введи значения для второго стэка");
                    Stack stack2 = InitStack();
                    stack.Merge(stack, stack2);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Объединенный стэк:");
                    stack.ViewList();
                    Console.ResetColor();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("Введите количество стеков, которое вы ходите объединить в один");
                    bool IsInt = int.TryParse(Console.ReadLine(), out int StacksCount);

                    while (!IsInt)
                    {
                        int.TryParse(Console.ReadLine(), out StacksCount);
                    }

                    if (StacksCount > 0) {
                        Stack[] Stacks = new Stack[StacksCount];

                        for (int i = 0; i < StacksCount; i++) {
                            Stacks[0] = stack;
                            if (i > 0) {
                                Stacks[i] = InitStack();
                            }
                        }

                        string ConcatReverseStack = string.Join(",", Stack.Concat(Stacks).StringList);

                        Console.WriteLine("Конкатинированный реверснутый стек:");
                        Console.WriteLine(ConcatReverseStack);
                    }
                    break;
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Возвращаемся к началу");
            StackCommandHandler(ref stack);
        }
    }
}
