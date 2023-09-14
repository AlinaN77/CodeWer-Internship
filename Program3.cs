/*
 * 3) Scrie un program care:
      a) citește de la tastatura 3 nume de persoane (ex. George Ion Maria)
      b) afișează pe cate o linie ce caracter a apărut în fiecare nume și de cate ori indiferent ca-i cu litera mica sau mare*/

using System;

class Program
{
    static void Main()
    {
        string[] names = new string[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Nume {i + 1}: ");
            names[i] = Console.ReadLine();
        }
        Console.WriteLine();

        foreach (string name in names)
        {
            foreach (char letter in name)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();

            // Calculăm și afișăm numărul de apariții ale fiecărei litere în nume
            Console.Write("Numărul de aparitii : ");
            foreach (char letter in "abcdefghijklmnopqrstuvwxyz")
            {
                int count = CountLetter(name.ToLower(), letter);
                if (count > 0)
                {
                    Console.Write(letter + "-" + count + " ");
                }
            }
            Console.WriteLine("\n");
        }
    }
    static int CountLetter(string text, char letter)
    {
        int count = 0;
        foreach (char c in text)
        {
            if (c == letter)
            {
                count++;
            }
        }
        return count;
    }
}
