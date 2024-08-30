using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1.OOP
{
    public interface IAnimal
    {
      // string Name { get; }

       void Eat();
    }

    public  class Animal
    {
         public string Name = "animal";
         public virtual void Eat()
         {
            Console.WriteLine($"{Name} Is Eat");
         }

         public virtual void Eat2()
         {
             Console.WriteLine($"{Name} Is Eat2");
        }

    }


    public class Dog : Animal,IAnimal
    {
        //public string Name = "Mydog";
        public Dog()
        {
            //base.Name = "Animal.Dog";
            this.Name = "Dog";
        }
        public override  void Eat()
        {
            Console.WriteLine($"{Name} In Dog Is Eat");
        }
        public  void Eat2()
        {
            Console.WriteLine($"{Name} In Dog Is Eat2");
        }
    }
}
