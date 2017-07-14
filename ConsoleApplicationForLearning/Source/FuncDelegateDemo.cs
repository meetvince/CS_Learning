using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForLearning.Source
{
    public class FuncDelegateDemo
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }
    }

    class MainProgramFunc
    {
        public void Main1()
        {
            var funcDelegateDemo = new FuncDelegateDemo();
            Func<int, int, int> demoFunc = new Func<int, int, int>(funcDelegateDemo.Sum);

            Console.WriteLine("Sum of 3, 5 using Func is :{0}",demoFunc(3,5));
            Console.ReadKey();
        }
    }
}
