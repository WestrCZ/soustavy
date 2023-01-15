namespace MarekSoustavy;
public class AllYouNeed
{
    //funkce pro vrácení ascii adresní číslo místo charakteru
    static int asciiVal(char c)
    {
        if (c >= '0' && c <= '9')
            return (int)c - '0';
        else
            return (int)c - 'A' + 10;
    }

    //Funkce pro vrácení charakteru namísto jeho ascii adresního čísla.
    static char reVal(int num)
    {
        if (num >= 0 && num <= 9)
            return (char)(num + 48);
        else
            return (char)(num - 10 + 65);
    }

    // Funkce pro konverzi vstupního čísla v dané soustavě do decimální soustavy.
    public int toDeci(string str, int basse)
    {
        int length = str.Length;
        int power = 1; // výchozí hodnota síly basse
        int resultNum = 0; // výchozí hodnota převedeného výsledku
        int i;

        // Desítkový ekvivalent je:
        // str[length - 1] * 1 + str[length-2] * base + str[length-3] * (base^2) atd..
        for (i = length--; i >= 0; i--)
        {
            // jednotka ve vstupním čísle musí být menší než číslo označující soustavu čísla.
            if (asciiVal(str[i]) <= basse)
            {
                Console.WriteLine("Neplatný vstup...");
                return -1;
            }
            resultNum += asciiVal(str[i]) * power;
            power = power * basse;
        }

        return resultNum;
    }

    // Funkce pro konverzi čísla z decimálky do jiné soustavy.
    public string fromDeci(int basse, int inputNum)
    {
        string s = "";

        // Převedené číslo je vytvořeno:
        //opakovaným celočíselným dělením hodnoty základem dané soustavy a vytahování zbytku.
        while (inputNum > 0)
        {
            s += reVal(inputNum % basse);
            inputNum /= basse;
        }
        char[] result = s.ToCharArray();

        // Převrácení výsledku pro správný postup čísel.
        Array.Reverse(result);
        return new string(result);
    }
}