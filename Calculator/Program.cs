using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Szia, üdvözöllek a Számológép programomban!");

            // Első szám bekérése és érvényesítése
            Console.Write("Kérlek, add meg az első számot: ");
            int num1 = GetValidNumber();

            // Második szám bekérése és érvényesítése
            Console.Write("Kérlek, add meg a második számot: ");
            int num2 = GetValidNumber();

            // Művelet kiválasztása és érvényesítése
            Console.WriteLine("Milyen műveletet szeretnél elvégezni?");
            Console.WriteLine("Kérlek, ha összeadást akkor +, ha osztást akkor /, ha szorzást akkor *, ha kivonást akkor - adj meg.");
            string answer = GetValidOperation();

            // Művelet végrehajtása és eredmény megjelenítése
            int eredmeny = Calculate(num1, num2, answer);
            Console.WriteLine($"Az eredmény nem más, mint: {eredmeny}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("A program véget ért. Nyomj meg egy gombot a kilépéshez.");
            Console.ReadLine();
        }
    }

    // Szám bekérés és validálás
    static int GetValidNumber()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Érvénytelen szám. Kérlek, adj meg egy érvényes egész számot!");
            }
        }
    }

    // Művelet kiválasztása és validálása
    static string GetValidOperation()
    {
        string[] validOperations = { "+", "-", "*", "/" };
        while (true)
        {
            string operation = Console.ReadLine();
            if (Array.Exists(validOperations, op => op == operation))
            {
                return operation;
            }
            else
            {
                Console.WriteLine("Érvénytelen művelet. Kérlek, válassz a következő lehetőségek közül: +, -, *, /");
            }
        }
    }

    // Művelet végrehajtása
    static int Calculate(int num1, int num2, string operation)
    {
        switch (operation)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Nem lehet nullával osztani!");
                }
                return num1 / num2;
            default:
                throw new InvalidOperationException("Ismeretlen művelet!");
        }
    }
}
