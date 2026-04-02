using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prgm3
{

    public static void Sales()
    {
        Saledetails s1 = new Saledetails(1, 101, 250, 2, "01-04-2026");
        s1.Sales();
        s1.ShowData();
    }
}
class Saledetails
{
    int salesno;
    int productno;
    double price;
    int qty;
    string dateofsale;
    double totalamount;
    public Saledetails(int s, int p, double pr, int q, string d)
    {
        salesno = s;
        productno = p;
        price = pr;
        qty = q;
        dateofsale = d;
    }

    public void Sales()
    {
        totalamount = qty * price;
    }

    public void ShowData()
    {
        Console.WriteLine("Sales ID : "+salesno);
        Console.WriteLine("Product ID : "+productno);
        Console.WriteLine("Product Price : "+price);
        Console.WriteLine("Product Quntity : "+qty);
        Console.WriteLine("Sales Date : "+dateofsale);
        Console.WriteLine("Total Amount : "+totalamount);
    }

}
