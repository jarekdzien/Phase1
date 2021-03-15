using System;
using System.Collections.Generic;

namespace Phase1Section6._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Abstract Factory Pattern======");
            MyKitchen k = new MyKitchen();
            k.createItems();
            List<KitchenItem> items = k.getItems();
            foreach (KitchenItem ki in items)
            {
                Console.WriteLine(ki.print());
            }

            Console.WriteLine("Singleton Pattern======");
            ThisApplication app1 = ThisApplication.Instance();
            app1.setName("App1");
            Console.WriteLine(app1.getName());
            ThisApplication app2 = ThisApplication.Instance();
            app2.setName("App2");
            Console.WriteLine(app2.getName());
            Console.WriteLine(app1.getName() + " = " + app2.getName());

            Console.WriteLine("Prototype Pattern======");
            BookingType seat1 = new Booking();
            seat1.setSeat("14b");
            Console.WriteLine(seat1.getSeat());
            BookingType seat2 = seat1.clone();
            Console.WriteLine(seat2.getSeat());
        }
    }

    /// <summary>
    /// //////////////////////////////abstract factory design //////////////////////////////
    /// </summary>
    abstract class KitchenItem
    {

        public abstract string print();
    }

    class Spoon : KitchenItem
    {
        public override string print() { return "Spoon"; }
    }
    class Pan : KitchenItem
    {
        public override string print() { return "Pan"; }
    }
    class Kettle : KitchenItem
    {
        public override string print() { return "Kettle"; }
    }
    class Glass : KitchenItem
    {
        public override string print() { return "Glass"; }
    }

    abstract class Kitchen
    {
        protected List<KitchenItem> mItems = new List<KitchenItem>();

        public List<KitchenItem> getItems()
        {
            return mItems;
        }

        public abstract void createItems();
    }

    class MyKitchen : Kitchen
    {
        public override void createItems()
        {
            mItems.Add(new Spoon());
            mItems.Add(new Pan());
            mItems.Add(new Glass());
        }
    }


    ///////////////////////////////////////// singleton ////////////////////////////////
    class ThisApplication
    {
        private static ThisApplication _instance;
        private string name = "ThisApplication";
        protected ThisApplication()
        { }
        public static ThisApplication Instance()
        {
            if (_instance == null)
            {
                _instance = new ThisApplication();
            }
            return _instance;
        }

        public string getName() { return name; }

        public void setName(string n) { name = n; }
    }

    /// //////////////////////////////prototype//////////////////////////////
    /// 
    abstract class BookingType
    {
        private string mSeat;
        public void setSeat(string s) { mSeat = s; }
        public abstract BookingType clone();
        public string getSeat() { return mSeat; }

    }

    class Booking : BookingType
    {
        public override BookingType clone()
        {
            return this.MemberwiseClone() as BookingType;
        }
    }

}
