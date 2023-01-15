using System.Runtime.Intrinsics.X86;

namespace MarekSoustavy;
public class App
{
    public void Run()
    {
        char PrintDeLimiterChar = '=';
        var functions = new AllYouNeed();
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        while (true)
        {
            //input shits
            Console.WriteLine("Vaše vstupní číslo: ");
            string str = Console.ReadLine();
            Console.WriteLine("V jaké soustavě je vaše vstupní číslo: ");
            int basse = SafelyConvertToInt(Console.ReadLine());
            Console.WriteLine("Do jaké soustavy chcete převést vaše číslo: ");
            int fbasse = SafelyConvertToInt(Console.ReadLine());

            var toDecimal = functions.toDeci(str, basse);
            var fromDecimal = functions.fromDeci(toDecimal, basse);

            //output shits
            if (fbasse == 10)
            {
                PrintDeLimiter(PrintDeLimiterChar);
                Console.WriteLine($"V {fbasse} soustavě by se ekvivalent čísla {str} ze soustavy {basse} zapsal jako {toDecimal}");
                PrintDeLimiter(PrintDeLimiterChar);
            }
            else
            {
                PrintDeLimiter(PrintDeLimiterChar);
                Console.WriteLine($"V {fbasse} soustavě by se ekvivalent čísla {str} ze soustavy {basse} zapsal jako {fromDecimal}");
                PrintDeLimiter(PrintDeLimiterChar);
            }
        }
    }
    public async void PrintDeLimiter(char x)
    {
        Console.WriteLine("");
        for (int i = 0; i < 30; i++)
        {
            Thread.Sleep(82);
            Console.Write(x);
        }
        Console.WriteLine("\n");
    }
    public int SafelyConvertToInt(string x)
    {
        if (int.TryParse(x, out int result))
        {
            return result;
        }
        return 10;
    }
}