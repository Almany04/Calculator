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
            double num1 = GetValidNumber();

            // Második szám bekérése opcionálisan
            Console.Write("Kérlek, add meg a második számot (integrálásnál és deriválásnál nem szükséges): ");
            string secondInput = Console.ReadLine();
            double num2 = 0;
            bool secondInputValid = double.TryParse(secondInput, out num2);

            // Művelet kiválasztása és érvényesítése
            Console.WriteLine("Milyen műveletet szeretnél elvégezni?");
            Console.WriteLine("Használd a következő jeleket: +, -, *, /, ^ (hatványozás), sqrt (négyzetgyök), int (integrálás), der (deriválás).");
            string operation = GetValidOperation();

            // Művelet végrehajtása és eredmény megjelenítése
            double eredmeny = Calculate(num1, num2, operation, secondInputValid);
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
    static double GetValidNumber()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Érvénytelen szám. Kérlek, adj meg egy érvényes számot!");
            }
        }
    }

    // Művelet kiválasztása és validálása
    static string GetValidOperation()
    {
        string[] validOperations = { "+", "-", "*", "/", "^", "sqrt", "int", "der" };
        while (true)
        {
            string operation = Console.ReadLine();
            if (Array.Exists(validOperations, op => op == operation))
            {
                return operation;
            }
            else
            {
                Console.WriteLine("Érvénytelen művelet. Kérlek, válassz a következő lehetőségek közül: +, -, *, /, ^, sqrt, int, der");
            }
        }
    }

    // Művelet végrehajtása
    static double Calculate(double num1, double num2, string operation, bool secondInputValid)
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
            case "^":
                return Math.Pow(num1, num2);
            case "sqrt":
                if (num1 < 0)
                {
                    throw new ArgumentException("A négyzetgyök alatti szám nem lehet negatív!");
                }
                return Math.Sqrt(num1);
            case "int": // Egyszerű polinom integrálás (pl. ax^n -> (a/n+1)x^(n+1))
                return IntegratePolynomial(num1);
            case "der": // Egyszerű polinom deriválás (pl. ax^n -> n*ax^(n-1))
                return DerivePolynomial(num1);
            default:
                throw new InvalidOperationException("Ismeretlen művelet!");
        }
    }

    // Egyszerű polinom integrálás (ax^n -> (a/n+1)x^(n+1))
    static double IntegratePolynomial(double coefficient)
    {
        Console.WriteLine("Kérlek, add meg az x kitevőjét (n): ");
        double exponent = GetValidNumber();
        if (exponent == -1)
        {
            throw new InvalidOperationException("Az integrálás során a kitevő nem lehet -1.");
        }
        return coefficient / (exponent + 1);
    }

    // Egyszerű polinom deriválás (ax^n -> n*ax^(n-1))
    static double DerivePolynomial(double coefficient)
    {
        Console.WriteLine("Kérlek, add meg az x kitevőjét (n): ");
        double exponent = GetValidNumber();
        return coefficient * exponent;
    }
}
