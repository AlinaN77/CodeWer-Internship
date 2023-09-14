/*
 1) Scrie un program care:
     a) citește de la tastatura un număr cu minim de 3 cifre dacă numărul are mai puțin de 3 cifre, îi spune utilizatorului acest lucru și îi cere alt număr
     b) dacă numărul este corect, calculeaza valoarea in oglinda (ex 441 in oglinda este 144)
     c) verifica și îi spune userului dacă numărul dat în oglinda este pătrat perfect (ex 144 = 12 * 12 - ok)
*/

using System;
using System.Globalization;
using System.Runtime.CompilerServices;

int og = 0;// variabila pentru oglindirea numarului
Console.WriteLine("Introduceti un numar: ");
for (int numar = 0; numar <= 100; numar++)
{

    numar = Convert.ToInt32(Console.ReadLine());
    if (numar <= 100)
    {
        Console.WriteLine("Numarul introdus are mai putin de 3 cifre. Reintroduceti numarul");
    }
    else
    {
        while (numar > 0)
        {

            og = og * 10 + numar % 10;
            numar = numar / 10;

        }
        Console.WriteLine(og);
        double sqrt = Math.Sqrt(og);
        if (sqrt % 1 == 0)
            Console.WriteLine("Numarul Oglindit este un patrat perefct din: " + sqrt);
        else
            Console.WriteLine("Numarul Oglindit nu este un patrat perefct");
        break;
    }
}
