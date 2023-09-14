/*2) Scrie un program care:
      a) citește de la tastatura o lista de numere (pot fi si numere reale) despărțite prin spațiu și le salvează într-un array
      b) parcurge array-ul și le afișează pe cele care nu sunt intregi
      c) cauta si afiseaza cel mai mic numar fara sa folosesti funcții din .NET (Math.Min)*/
using System;

class Program
{
    static void Main()
    {
        double[] array = new double[10];
        int i;

        Console.WriteLine("Introduceti elementele array-ului: ");
        for (i = 0; i < 10; i++)
        {
            Console.Write(" {0} : ", i); 
            array[i] = Convert.ToDouble(Console.ReadLine());
        }

        Console.Write("\nElements in array are: ");
        for (i = 0; i < 10; i++)
        {
            Console.Write("{0}  ", array[i]);
        }
        Console.Write("\n");
        Console.WriteLine("Numere reale din array sunt:"); 

        for (i = 0; i < 10; i++)
        {
            if (array[i] % 1 != 0)
                Console.WriteLine(" {0} ", array[i]);
        }

        double min = array[0];
        for (i = 0; i < 10; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        Console.WriteLine("Minim:" + min); 
    }
}