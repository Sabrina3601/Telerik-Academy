using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. 
//Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
//Kittens and tomcats are cats. All animals are described by age, name and sex. 
//Kittens can be only female and tomcats can be only male. Each animal produces a specific sound. 
//Create arrays of different kinds of animals and calculate the average age of each kind of animal
//using a static method (you may use LINQ).

namespace Task3
{
    class Test
    {
        static void Main()
        {
            //Creat Dogs and test it
            Console.WriteLine("Dogs:");
            Dog[] dogs = 
            { 
                new Dog("Sharo", 4, "Male"),
                new Dog("Roki", 5, "Male"),
                new Dog("Lassie", 2,"Female")
            };

            foreach (var dog in dogs)
            {
                Console.WriteLine(dog);  
            }
            Console.WriteLine("Avarage age of dogs is: {0}", Animals.AvarageAge(dogs));
            Console.WriteLine("Dogs makes:");
            dogs[0].SaySound();
            Console.WriteLine();

            //Creat cats and test it
            Console.WriteLine("Cats:");
            Cat[] cats = 
            { 
                new Cat("Masha", 2, "Female"),
                new Cat("Mara", 1, "Female"),
                new Cat("Maca", 7,"Female")
            };

            foreach (var cat in cats)
            {
                Console.WriteLine(cat);
            }
            Console.WriteLine("Avarage age of cat is: {0}", Animals.AvarageAge(cats));
            Console.WriteLine("Cats makes:");
            cats[0].SaySound();
            Console.WriteLine();

            //Creat Frog and Test it 
            Console.WriteLine("Frogs:");
            Frog[] frogs = 
            { 
                new Frog("FrogOne", 2, "Male"),
                new Frog("FrogTwo", 15, "Female"),
                new Frog("FrogThree", 12,"Male")
            };

            foreach (var frog in frogs)
            {
                Console.WriteLine(frog);
            }
            Console.WriteLine("Avarage age of frog is: {0}", Animals.AvarageAge(frogs));
            Console.WriteLine("Frogs makes:");
            frogs[0].SaySound();
            Console.WriteLine();

            //create kiitens and test it
            Console.WriteLine("Kittens:");
            Kitten[] kittens = 
            { 
                new Kitten("KittenOne", 1),
                new Kitten("KittenTwo", 1),
                new Kitten("KittenThree", 1)
            };

            foreach (var kitten in kittens)
            {
                Console.WriteLine(kitten);
            }
            Console.WriteLine("Avarage age of kitten is: {0}", Animals.AvarageAge(kittens));
            Console.WriteLine("Kittens makes:");
            kittens[0].SaySound();
            Console.WriteLine();

            //create tomcats and test it
            Console.WriteLine("Tomcats:");
            Tomcat[] tomcats = 
            { 
                new Tomcat("TomcatOne", 6),
                new Tomcat("TomcatTwo", 5),
                new Tomcat("TomacatThree", 8)
            };

            foreach (var tomcat in tomcats)
            {
                Console.WriteLine(tomcat);
            }
            Console.WriteLine("Avarage age of tomcats is: {0}", Animals.AvarageAge(tomcats));
            Console.WriteLine("Tomcats makes:");
            tomcats[0].SaySound();
        }
    }
}
