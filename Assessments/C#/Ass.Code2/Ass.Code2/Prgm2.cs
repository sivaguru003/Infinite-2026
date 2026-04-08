//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//internal class Prgm2
//{
//    class Products
//    {
//        public int ProdId;
//        public string ProdName;
//        public int Pri;
//    }
//    public static void Prod()
//    {
//        List<Products> productList = new List<Products>();
//        for (int i = 0; i < 10; i++)
//        {
//            Products p = new Products();
//            Console.WriteLine("\nEnter Product Details :  " + (i + 1));
//            Console.Write("Product ID: ");
//            p.ProdId = int.Parse(Console.ReadLine());
//            Console.Write("Product Name: ");
//            p.ProdName = Console.ReadLine();
//            Console.Write("Price: ");
//            p.Pri = int.Parse(Console.ReadLine());
//            productList.Add(p);
//        }

//        productList.Sort((p1, p2) => p1.Pri.CompareTo(p2.Pri));
//        Console.WriteLine("\nProducts sorted by Price:\n");
//        foreach (Products p in productList)
//        {
//            Console.WriteLine("ID: " + p.ProdId + ", Name: " + p.ProdName + ", Price: " + p.Pri);
//        }
//    }
//}

