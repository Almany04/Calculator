class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Szia, üdvözöllek a Számológép programomban! ");

        Console.WriteLine("Kérlek add meg az első számot: ");
        int num1=Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Kérlek add meg a második számot: ");

        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Milyen műveletet szeretnél elvégezni?");
        Console.WriteLine("Kérlek ha összeadást akkor +, ha osztást akkor /, ha szorzást akkor *, ha kivonást akkor - adj meg.");
        string answer="";
        answer=Console.ReadLine();
        int eredmeny=0;
        if (answer == "+")
        {
            eredmeny = num1 + num2;
        }
        else if (answer == "-")
        {
            eredmeny = num1 - num2;
        }
        else if (answer == "*")
        {
            eredmeny = num1 * num2;
        }
        else if (answer == "/")
        {
            eredmeny = num1 / num2;
        }
        else
        {
            Console.WriteLine("Nem tudom elvégezni ezt a műveletet!");

        }
        Console.WriteLine($"Az eredmény nem más mint: {eredmeny}");
        Console.ReadLine();
    }
}
