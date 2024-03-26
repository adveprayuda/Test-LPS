using System;
using System.Collections.Generic;

namespace ApplicationAnalysis
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //no1
            Application application = GetApplication();
            Console.WriteLine("Nomor 1 = " + application?.@protected?.shieldLastRun.ToString());

            //no2
            var info = GetInfo();
            var path = info.Path;
            var name = info.Name;
            Console.WriteLine("Nomor 2 = " + $"{path} {name}");

            //no 3
            var laptop = new Laptop("macOs");
            Console.WriteLine("Nomor 3 = ");
            Console.WriteLine(laptop.os);

            Console.WriteLine("type to modify the os:");
            string a = Console.ReadLine();
            laptop.ModifyOS(a);
            Console.WriteLine("After modifying the value : " + laptop.os);

            //no 4
            Console.WriteLine("Nomor 4 : ");
            int count = 0;
            while (true)
            {
                
                var myList = new List<Product>(); // membuat list baru di dalam loop
                //populate list dengan 1000 bilangan
                for (int i = 0; i< 1000; i++ )
                {
                    myList.Add(new Product(Guid.NewGuid().ToString(), i));
                }
                Console.WriteLine("Total Product : " + myList.Count);
                for (int i = 0; i < Math.Min(5, myList.Count); i++)
                {
                    //print 5 konten pertama dari setiap iterasi
                    Console.WriteLine("SKU : " + myList[i].SKU + ", Price : " + myList[i].Price);
                }
                myList.Clear(); //mencegah memory leak
                count++;
                if (count == 5) { break; } //mencegah infintite loop untuk tujuan presentasi
            }

            //no 5
            Console.WriteLine("Nomor 5 : ");
            count = 0;
            var publisher = new EventPublisher();
            while (true)
            {
                var subscriber = new EventSubscriber(publisher);
                Console.WriteLine(subscriber);
                count++;
                if (count == 5) { break; } //sama seperti nomor 4
            }

            //no 6
            Console.WriteLine("Nomor 6 : ");
            var rootNode = new TreeNode();
            //old code
            //while (true)
            //{
            //    //create a new subtree of 10000 nodes
            //    var newNode = new Treenode();
            //    for (int i = 0; i<10000; i++)
            //    {
            //        var childNode = new Treenode();
            //        Console.WriteLine(i + ": " + childNode);
            //        newNode.AddChild(childNode);
            //    }
            //    rootNode.AddChild(newNode);
            //}
            while (true)
            {
                if (rootNode.CountChildren() < 100)
                {
                    var newNode = CreateSubtree(10000);
                    rootNode.AddChild(newNode);
                    Console.WriteLine(newNode.ToString());
                }
                else
                {
                    break;
                }
            }

            //no 7
            Console.WriteLine("Nomor 7 : ");
            for (int i = 0; i<1000000 ; i++) 
            { 
                Cache.Add(i, new object()); 
            }
            Console.WriteLine("Cache Populated");
            Console.ReadLine();

        }
        #region nomor 1
        public class Application
        {
            public ProtectedClass @protected { get; set; }
        }

        public class ProtectedClass
        {
            public DateTime shieldLastRun { get; set; }
        }
        static Application GetApplication()
        {
            // You need to implement this method to return an instance of the Application class
            // For demonstration purposes, let's create a sample instance
            return new Application
            {
                @protected = new ProtectedClass
                {
                    shieldLastRun = DateTime.Now.AddDays(-1) // Example value for shieldLastRun
                }
            };
        }
        #endregion nomor 1

        #region nomor 2

        public static ApplicationInfo GetInfo()
        {
            var application = new ApplicationInfo
            {
                Path = "C:/apps/",
                Name = "Shield.exe"
            };
            return application;
        }

        public class ApplicationInfo
        {
            public string Path { get; set; }
            public string Name { get; set; }
        }

        #endregion nomor 2

        #region nomor 3
        class Laptop
        {
            private string _os;
            public Laptop(string os) { _os = os; }

            public string os { get { return _os; } private set { _os = value; } }

            public void ModifyOS(string newOs) { _os = newOs; }
        }
        #endregion nomor 3
              
        #region nomor 5
        class EventPublisher
        {
            public event EventHandler myEvent;
            public void RaiseEvent()
            {
                myEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        class EventSubscriber : IDisposable
        //implement interface IDisposable
        {
            private readonly EventPublisher _publisher;
            public EventSubscriber(EventPublisher publisher)
            {
                //publisher.myEvent += OnMyEvent; //code lama
                _publisher = publisher;
                _publisher.myEvent += OnMyEvent;
            }
            private void OnMyEvent(object sender, EventArgs e)
            {
                Console.WriteLine("MyEvent Raised");
            }

            public void Dispose()
            {
                _publisher.myEvent -= OnMyEvent;
            }
        }
        #endregion nomor 5

        #region nomor 6

        static TreeNode CreateSubtree(int numNodes)
        {
            var newNode = new TreeNode();
            for (int i = 0; i < numNodes; i++)
            {
                var childeNode = new TreeNode();
                newNode.AddChild(childeNode);
            }
            return newNode;
        }

        #endregion nomor 6

    }

    #region nomor 4

    class Product
    {
        public Product(string sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }
        public string SKU { get; set; }
        public decimal Price { get; set; }
    }

    #endregion nomor 4

    #region nomor 6

    class TreeNode
    {
        private readonly List<TreeNode> _children = new List<TreeNode>();
        public void AddChild(TreeNode child)
        {
            _children.Add(child);
        }

        public int CountChildren()
        {
            return _children.Count;
        }
    }

    #endregion nomor 6

    #region nomor 7

    class Cache
    {
        private static Dictionary<int, object> _cache = new Dictionary<int, object>();
        private static LinkedList<int> _accessOrder = new LinkedList<int>();
        private static int _capacity = 10000; // set kapasitas cache
        public static void Add(int key, object value) 
        { 
            //_cache.Add(key, value); //code lama 
            if (_cache.ContainsKey(key))
            {
                _cache[key] = value;
                _accessOrder.Remove(key);
            }
            else
            {
                if (_cache.Count >= _capacity)
                {
                    int leastRecentlyUsed = _accessOrder.First.Value;
                    _accessOrder.RemoveFirst();
                    _cache.Remove(leastRecentlyUsed);
                }
                _cache.Add(key, value);
            }
            _accessOrder.AddLast(key);
        }
        public static object Get(int key) 
        {
            if (_cache.ContainsKey(key))
            {
                _accessOrder.Remove(key);
                _accessOrder.AddLast(key);
                return _cache[key];
            }
            return null; //return null jika key tidak ditemukan di cache
        }
        
    }
    #endregion nomor 7


}
