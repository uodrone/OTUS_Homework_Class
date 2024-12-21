using OTUS_Homework_Class.Interfaces;
using System.ComponentModel;

namespace OTUS_Homework_Class
{
    public class Program
    {

        static void Main()
        {
            var quadcopter = new Quadcopter();            

            Console.WriteLine($"Информация о зарядке: {quadcopter.GetInfo()}, вот посмотри");
            quadcopter.Charge();

            IRobot robot = new Quadcopter();
            Console.WriteLine($"Дефолтный метод робота: {robot.GetRobotType()}");

            Console.WriteLine($"Информация о роботе: {robot.GetInfo()}");

            IFlyingRobot flyingRobot = new Quadcopter();
            Console.WriteLine($"Дефолтный метод летающего робота: {flyingRobot.GetRobotType()}");

            Console.WriteLine("Компоненты робота:");
            foreach (string component in quadcopter.GetComponents())
            {
                Console.WriteLine(component);
            }
        }
    }
}
