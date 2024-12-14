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

            return stack;
        }

        static void StackCommandHandler(ref Stack stack)
        {
            Console.WriteLine();
            Console.WriteLine("Привет, я Иван Иваныч, чего тебе надобно?");
            Console.WriteLine("Чтобы добавить элемент в стек нажми 1");
            Console.WriteLine("Чтобы удолить элемент стека нажми 2");
            Console.WriteLine("Чтобы выйти из программы нажмите Esc");

            var ComandKey = Console.ReadKey();
            Console.WriteLine();
            

            switch (ComandKey.Key) {
                case ConsoleKey.Escape:
                    Console.WriteLine("Произвожу выход из программы");
                    return;
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
                        if (string.IsNullOrEmpty(WitdrawString))
                        {
                            throw new Exception("Стек пустой, совсем пустой, не могу удолить");
                        }
                        Console.WriteLine($"Извлек верхний элемент '{WitdrawString}' Size = {stack._Size}");
                        Console.WriteLine($"size = {stack._Size}, Top = {(stack._Top == null ? "null" : stack._Top)}");
                    }
                    catch (Exception ex) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
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
