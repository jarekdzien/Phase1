using System;
using System.Collections.Generic;

namespace Phase1Section6._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Observer Pattern=========");
            Tesla tesla = new Tesla("tesla", 190.00M);
            tesla.addWatcher(new Person("person 1", tesla));
            tesla.addWatcher(new Person("person 2", tesla));
            tesla.addWatcher(new Person("person 3", tesla));

            Console.WriteLine(tesla.setPrice(210.14M));

            Console.WriteLine("Template Method Pattern=========");
            Transport car1 = new Car();
            Console.WriteLine(car1.run());

            Transport plane1 = new Plane();
            Console.WriteLine(plane1.run());

            Console.WriteLine("Strategy Pattern=========");
            Calculate calc1 = new Calculate();
            calc1.setNumber(90);
            calc1.setDouble(new Addition());
            Console.WriteLine(calc1.doDouble());
            calc1.setDouble(new Multiply());
            Console.WriteLine(calc1.doDouble());
        }
    }



    ///////////////////////////Observer Pattern////////////////////////////////////


    abstract class StockType
    {

        private string name;
        private decimal price;
        private List<Watcher> watchers = new List<Watcher>();
        public StockType(string n, decimal p)
        {
            name = n;
            price = p;
        }

        public void addWatcher(Watcher w)
        {
            watchers.Add(w);
        }

        public void removeWatcher(Watcher w)
        {
            watchers.Remove(w);
        }

        public void sendNotifications()
        {
            foreach (Watcher w in watchers)
            {
                w.notify(this);
            }
        }

        public string setPrice(decimal p)
        {
            this.price = p;
            sendNotifications();
            return "Price changed to " + p.ToString();
        }

        public string getName() { return name; }
        public decimal getPrice() { return price; }

    }


    interface Watcher
    {
        void notify(StockType st);
    }

    class Tesla : StockType
    {

        public Tesla(string name, decimal price) : base(name, price)
        {

        }
    }

    class Person : Watcher
    {
        private string name;
        private Tesla tesla;

        public Person(string name, Tesla st)
        {
            this.name = name;
            tesla = st;

        }

        public void notify(StockType st)
        {
            Console.WriteLine("Stock " + st.getName() + " price is now " + st.getPrice());
        }


    }

    ///////////////////////////Template Method Pattern////////////////////////////////////

    abstract class Transport
    {
        protected string name;

        public abstract string startEngine();
        public abstract string moveForward();
        public abstract string stopEngine();

        public string run()
        {
            string val = "";
            val += startEngine();
            val += "\n";
            val += moveForward();
            val += "\n";
            val += stopEngine();
            val += "\n";

            return val;
        }
    }

    class Car : Transport
    {
        public override string startEngine()
        {
            return "Turn key in ignition";
        }
        public override string moveForward()
        {
            return "Put in gear and accelerate";
        }
        public override string stopEngine()
        {
            return "Put gear in neutral and turn off ignition";
        }
    }

    class Plane : Transport
    {
        public override string startEngine()
        {
            return "Start Engines";
        }
        public override string moveForward()
        {
            return "Pull yoke back and thrust engines to take off";
        }
        public override string stopEngine()
        {
            return "Put flaps down and wheels down and land plane";
        }
    }

    ///////////////////////////Strategy Pattern////////////////////////////////////
    ///
    abstract class Double
    {
        public abstract int doSum(int a);
    }

    class Addition : Double
    {
        public override int doSum(int a)
        {
            return a + a;
        }

    }

    class Multiply : Double
    {
        public override int doSum(int a)
        {
            return a * 2;
        }

    }

    class Calculate
    {

        private int number;
        private Double _double;

        public void setDouble(Double d)
        {
            _double = d;
        }

        public void setNumber(int a)
        {
            number = a;
        }

        public int doDouble()
        {
            return _double.doSum(number);
        }
    }
}
