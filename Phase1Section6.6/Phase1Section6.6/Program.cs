using System;
using System.Collections;
using System.Collections.Generic;

namespace Phase1Section6._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adapter Pattern====");
            India india = new India(new WorkAbroad());
            Console.WriteLine(india.startWork());

            Console.WriteLine("Bridge Pattern====");

            Invoice invoice = new Invoice();
            invoice.setCustomer("Acem Inc");
            invoice.setId("AUY77");

            InvoiceItem item1 = new InvoiceItem();
            item1.setValues("item 1", 1, 34.00M, 34.00M);
            invoice.addItem(item1);
            InvoiceItem item2 = new InvoiceItem();
            item2.setValues("item 2", 3, 54.00M, 54.00M * 2);
            invoice.addItem(item2);
            InvoiceItem item3 = new InvoiceItem();
            item3.setValues("item 3", 4, 50.00M, 50.00M * 5);
            invoice.addItem(item3);
            Console.WriteLine("Invoice total=" + invoice.getTotal());

            Console.WriteLine("Proxy Pattern====");

            BankProxy proxy = new BankProxy();
            Console.WriteLine(proxy.deposit());
            Console.WriteLine(proxy.widthdraw());
            Console.WriteLine(proxy.getBalance());

            Console.WriteLine("Decorator Pattern====");
            Teacher t1 = new Teacher();
            t1.setName("Teacher 1");
            t1.setSubjects("English, Math, Geography");
            Console.WriteLine(t1.name() + ", " + t1.subjects() + ", " + t1.designation());

            Teacher t2 = new Teacher();
            t2.setName("Teacher 2");
            t2.setSubjects("English");
            Console.WriteLine(t2.name() + ", " + t2.subjects() + ", " + t2.designation());

            ClassTeacherType ct = new ClassTeacherType(t2);
            ct.setGrade("4");
            ct.setName("Class Teacher 1");
            ct.setSubjects("Physics");
            Console.WriteLine(ct.name() + ", " + ct.grade() + ", " + ct.designation());

            SeniorSchoolClassTeacher sct = new SeniorSchoolClassTeacher(ct);
            Console.WriteLine(sct.name() + ", " + sct.grade() + ", " + sct.designation());

            Console.WriteLine("Composite Pattern====");

            MyFile file1 = new MyFile { isFolder = false, name = "File1", size = 109 };
            Console.WriteLine(file1.name + " file created");
            MyFile file2 = new MyFile { isFolder = false, name = "File2", size = 1109 };
            Console.WriteLine(file2.name + " file created");
            MyFile folder1 = new MyFile { isFolder = true, name = "Folder1", size = 0 };
            Console.WriteLine(folder1.name + " folder created");
            folder1.addFile(new MyFile { isFolder = false, name = "SubFile1", size = 109 });
            folder1.addFile(new MyFile { isFolder = false, name = "SubFile2", size = 109 });
            Console.WriteLine("Files in folder:");
            List<IFile> list = folder1.getList();

            foreach (IFile f in list)
            {
                Console.WriteLine(f.name);
            }

            SymLink label = new SymLink { isFolder = false, name = "System", size = 0 };
            folder1.addFile(label);
            Console.WriteLine("Added Symlink to folder:");
            Console.WriteLine(folder1.getFile(2).name);


        }
    }

    /////////////////////Adapter ////////////////////////////

    interface IWorkAbroad
    {
        string doWork();
    }

    class India
    {
        private readonly IWorkAbroad _workAbroad;

        public India(IWorkAbroad work)
        {
            _workAbroad = work;
        }

        public string startWork()
        {
            return _workAbroad.doWork();
        }
    }

    class China
    {
        public string workHere()
        {
            return "You are working in China";
        }
    }

    class WorkAbroad : IWorkAbroad
    {
        readonly China _china = new China();
        public string doWork()
        {
            return _china.workHere();
        }
    }


    /////////////////////Bridge ////////////////////////////
    ///
    abstract class InvoiceItemType
    {
        protected string name;
        protected int qty;
        protected decimal rate;
        protected decimal price;

        public abstract decimal getPrice();
        public abstract string getName();
        public abstract int getQty();
        public abstract decimal getRate();

        public abstract void setValues(string name, int qty, decimal rate, decimal price);

    }

    class InvoiceItem : InvoiceItemType
    {
        public override decimal getPrice() { return price; }
        public override string getName() { return name; }
        public override int getQty() { return qty; }
        public override decimal getRate() { return qty; }

        public override void setValues(string name, int qty, decimal rate, decimal price)
        {
            this.name = name; this.qty = qty; this.rate = rate; this.price = price;
        }
    }

    abstract class InvoiceType
    {
        protected string id;
        protected string customer;
        protected List<InvoiceItemType> _items;

        public abstract void addItem(InvoiceItemType item);
        public abstract void setCustomer(string name);
        public abstract void setId(string id);
        public abstract List<InvoiceItemType> getItems();
        public abstract decimal getTotal();
    }

    class Invoice : InvoiceType
    {
        public Invoice()
        {
            _items = new List<InvoiceItemType>();
        }
        public override void addItem(InvoiceItemType item)
        {
            _items.Add(item);
        }
        public override void setCustomer(string name)
        {
            this.customer = name;
        }
        public override void setId(string id)
        {
            this.id = id;
        }
        public override List<InvoiceItemType> getItems()
        {
            return _items;
        }
        public override decimal getTotal()
        {
            decimal total = 0.00M;

            foreach (InvoiceItemType i in _items)
            {
                total += i.getPrice();
            }

            return total;
        }
    }

    /////////////////////Proxy ////////////////////////////

    interface IBank
    {
        string deposit();
        string withdraw();
        decimal getBalance();
    }

    class Bank
    {
        public string deposit() { return "deposited"; }
        public string widthdraw() { return "withdraw"; }
        public decimal getBalance() { return 4500.00M; }
    }

    class BankProxy
    {
        private Bank _bank = new Bank();

        public string deposit() { return _bank.deposit(); }
        public string widthdraw() { return _bank.widthdraw(); }
        public decimal getBalance() { return _bank.getBalance(); }
    }

    /////////////////////Decorator ////////////////////////////

    abstract class TeacherType
    {
        protected string mSubjects;
        protected string mName;
        public abstract string subjects();
        public abstract void setSubjects(string s);
        public abstract string name();
        public abstract void setName(string n);
        public abstract string designation();
    }

    class Teacher : TeacherType
    {
        public override string subjects()
        {
            return mSubjects;
        }
        public override void setSubjects(string s)
        {
            mSubjects = s;
        }

        public override void setName(string n)
        {
            mName = n;
        }

        public override string name()
        {
            return mName;
        }

        public override string designation()
        {
            return "Subject teacher";
        }
    }

    class ClassTeacherType : TeacherType
    {
        protected TeacherType _teacherType;
        protected string whichGrade;

        public ClassTeacherType(TeacherType tt) : base()
        {
            _teacherType = tt;
        }


        public override void setSubjects(string s)
        {
            _teacherType.setSubjects(s);
        }

        public override void setName(string n)
        {
            _teacherType.setName(n);
        }

        public override string name()
        {
            return _teacherType.name();
        }

        public override string subjects()
        {
            return _teacherType.subjects();
        }

        public virtual void setGrade(string g)
        {
            whichGrade = g;
        }
        public virtual string grade()
        {
            return whichGrade;
        }

        public override string designation()
        {
            return "Class teacher";
        }
    }

    class SeniorSchoolClassTeacher : ClassTeacherType
    {
        private ClassTeacherType _classTeacherType;
        public SeniorSchoolClassTeacher(ClassTeacherType tt) : base(tt)
        {
            _classTeacherType = tt;
        }
        public override string designation()
        {
            string val = base.designation();
            return val += " of Senior School ";
        }

        public override string grade()
        {
            return _classTeacherType.grade();
        }

    }

    /////////////////////Composite ////////////////////////////
    ///
    interface IFile
    {
        string name { get; set; }
        long size { get; set; }
        bool isFolder { get; set; }
    }

    class MyFile : IFile, IEnumerable<IFile>
    {
        private List<IFile> mFiles = new List<IFile>();
        public string name { get; set; }
        public long size { get; set; }
        public bool isFolder { get; set; }

        public string addFile(IFile f)
        {
            isFolder = true;
            mFiles.Add(f);
            return f.name + " added";
        }

        public string removeFile(IFile f)
        {
            mFiles.Remove(f);
            return f.name + " removed";
            if (mFiles.Count == 0)
                isFolder = false;
        }

        public IFile getFile(int i)
        {
            return mFiles[i];
        }

        public IEnumerator<IFile> GetEnumerator()
        {
            foreach (IFile f in mFiles)
            {
                yield return f;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<IFile> getList()
        {
            return mFiles;
        }
    }

    class SymLink : IFile
    {
        public string name { get; set; }
        public long size { get; set; }
        public bool isFolder { get; set; }
    }

}
