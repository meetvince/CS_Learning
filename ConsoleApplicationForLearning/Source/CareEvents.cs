using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForLearning.Source
{
    class CarEvents
    {
        public delegate void CarEngineHandler(string msg);

        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        public int MaxSpeed { get; set; }
        public int CurrSpeed { get; set; }
        public string PetName { get; set; }
        public bool CarIsDead { get; set; }

        public CarEvents()
        {
            MaxSpeed = 100;
            CarIsDead = false;
        }

        public CarEvents(int max, int curr, string pet)
        {
            MaxSpeed = max;
            CurrSpeed = curr;
            PetName = pet;            
        }

        public void Accelerate(int delta)
        {
            if (CarIsDead)
            {
                Exploded("Car is dead!!!");
            }
            else
            {
                CurrSpeed += delta;
                if (CurrSpeed >= MaxSpeed)
                {
                    CarIsDead = true;
                }
                else if(MaxSpeed-CurrSpeed<=10)
                {
                    AboutToBlow("Careful!!! Car is about to blow");
                }
                else
                {
                    Console.WriteLine("Current speed is : {0}",CurrSpeed);
                }
            }
        }
    }
}
