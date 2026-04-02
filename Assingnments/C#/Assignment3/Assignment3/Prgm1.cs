using System;

internal class Prgm1
{
    static void Main(string[] args)
    {
        Acc();
    }

    public static void Acc()
    {
        Accounts a1 = new Accounts(10001, "Sivaguru S", "Savings", 10000);

        a1.Transaction('D', 1000);
        a1.Transaction('W', 5000);
        a1.Show();
    }
}

class Accounts
{
    private int acc_no;
    private string cust_name;
    private string acc_type;
    private float balance;

    public Accounts(int a, string n, string t, float b)
    {
        acc_no = a;
        cust_name = n;
        acc_type = t;
        balance = b;
    }
    public void Credit(float amt)
    {
        balance += amt;
        Console.WriteLine("Amount Credited: " + amt);
    }

    public void Debit(float amt)
    {
        if (amt > balance)
        {
            Console.WriteLine("Transaction Failed: Insufficient Funds");
        }
        else
        {
            balance -= amt;
            Console.WriteLine("Amount Debited: " + amt);
        }
    }
        public void Transaction(char type, float amt)
    {
        char t = char.ToUpper(type);

        if (t == 'D')
            Credit(amt);
        else if (t == 'W')
            Debit(amt);
        else
            Console.WriteLine("Invalid Transaction Type");
}

    public void Show()
    {
        Console.WriteLine("Account Number : " + acc_no);
        Console.WriteLine("Customer Name  : " + cust_name);
        Console.WriteLine("Account Type   : " + acc_type);
        Console.WriteLine("Balance        : " + balance);
        Console.WriteLine("------------------------");
    }
}