using System;

namespace ConsoleApplicationForLearning
{
    public class ActionDelegateDemo
    {
        public static void DisplayMessage(string message, ConsoleColor color, int printCount)
        {
            var tempColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            for(int i = 0; i < printCount; i++)
            {
                Console.WriteLine(message + "\n");
            }

            Console.ForegroundColor = tempColor;
        }
    }

    public class ActionMainProgram
    {
        public delegate void ActionDelegate(string msg, ConsoleColor color, int numTimes);

        public static void Main()
        {
            Action<string, ConsoleColor, int> myActionMethod = 
                new Action<string, ConsoleColor, int>(ActionDelegateDemo.DisplayMessage);

            myActionMethod("Hey there", ConsoleColor.DarkCyan, 5);
            Console.ReadKey();

            var del = new ActionDelegate(ActionDelegateDemo.DisplayMessage);
            del("Hey from delegate", ConsoleColor.Red, 3);
            Console.Read();
        }
    }
}
