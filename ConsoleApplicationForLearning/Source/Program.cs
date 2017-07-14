using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DelegatesEventsLambdas.Samples
{
    public class Car
    {
        public int MaxSpeed { get; set; }
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }
        public bool CarIsDead { get; set; }

        public Car()
        {
            MaxSpeed = 100;
        }

        public Car(int maxSpeed, string petName, int currSpeed)
        {
            MaxSpeed = maxSpeed;
            PetName = petName;
            CurrentSpeed = currSpeed;
        }

        public delegate void CarEngineHandler(string msgForCaller);

        private CarEngineHandler listOfHandlers;

        public void RegisterWithCarEngineHandler(CarEngineHandler methodToCall)
        {
            listOfHandlers = methodToCall;
        }

        public void Accelerate(int delta)
        {
            if (CarIsDead && listOfHandlers != null)
            {
                listOfHandlers("Car is Dead!!!");
            }
            else
            {
                CurrentSpeed += delta;

                if (((MaxSpeed - CurrentSpeed) <= 10) && ((MaxSpeed - CurrentSpeed) > 0) && listOfHandlers != null)
                {
                    listOfHandlers("Careful!!! About to explode");
                }
                else
                {
                    if (CurrentSpeed >= MaxSpeed && listOfHandlers != null)
                    {
                        CarIsDead = true;
                        listOfHandlers("Car is now dead!!!");
                    }
                    else
                    {
                        Console.WriteLine("Current Speed is " + CurrentSpeed);
                    }
                }
            }
        }
    }

    public class CarDemo
    {
        public static void Main1()
        {
            var c1 = new Car(100, "SlugBug", 60);

            c1.RegisterWithCarEngineHandler(OnCarEngineEvent);

            for (int i = 0; i < 5; i++)
            {
                c1.Accelerate(20);
                Console.ReadKey();
            }
        }

        private static void OnCarEngineEvent(string msgForCaller)
        {
            Console.WriteLine("Message from Car Engine :{0}", msgForCaller);
            Console.ReadKey();
        }
    }
}

public static class DemoDelegatesMethods
{
    public static int Add(int x, int y)
    {
        return x + y;
    }
    public static int Subtract(int x, int y)
    {
        return x - y;
    }
}
public class DemoDelegates
{
    public delegate int MyDelegate(int x, int y); //This can be defined outside a class;
    public static void Main()
    {
        MyDelegate myDelegate = new MyDelegate(DemoDelegatesMethods.Add);
        Console.WriteLine("Sum of 3, 5 is :{0}", myDelegate(3, 5));
    }
}