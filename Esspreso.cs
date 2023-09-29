using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static int Volum = 0;
    static int lapte = 0;

    static void Main()
    {
        bool exitRequested = false;
        int espresso = 60;
        bool incalzitor = false;

        while (!exitRequested)
        {
            bool sensor = false;
            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;


            int menuStartX = centerX - 10;
            int menuStartY = centerY - 4;

            Console.Clear();
            Console.SetCursorPosition(menuStartX, menuStartY);
            Console.WriteLine("Welcome to Coffe Machine");
            Console.SetCursorPosition(menuStartX, Console.CursorTop + 1);
            Console.WriteLine("1. Incepe sa faci caffea");
            Console.SetCursorPosition(menuStartX, Console.CursorTop + 1);
            Console.WriteLine("2. Vreau ceai");

            int numar;
            int raspuns;
            int cafea;


            if (int.TryParse(Console.ReadLine(), out numar))
            {
                Console.Clear();

                int responseStartX = centerX - 10;
                int responseStartY = centerY - 2;

                Console.SetCursorPosition(responseStartX, responseStartY);

                switch (numar)
                {
                    case 1:


                        Boiler boiler = new Boiler();
                        boiler.VerificareApa(ref Volum);

                        Boiler blapte = new Boiler();
                        blapte.VerificaVolumLapte(ref lapte);

                        do
                        {
                            Console.Clear(); // Clear the console
                            Console.SetCursorPosition(responseStartX, responseStartY);
                            Console.WriteLine("Ati introdus cana?");
                            int daX = centerX - 5;
                            int daY = Console.CursorTop + 1;
                            int nuX = centerX - 5;
                            int nuY = daY + 1;

                            Console.SetCursorPosition(daX, daY);
                            Console.WriteLine("1. Da");

                            Console.SetCursorPosition(nuX, nuY);
                            Console.WriteLine("2. Nu");

                            if (int.TryParse(Console.ReadLine(), out raspuns))
                            {
                                centerX = Console.WindowWidth / 2;
                                centerY = Console.WindowHeight / 2;
                                int switchStartY = centerY - 2;

                                Console.SetCursorPosition(responseStartX, switchStartY);
                                switch (raspuns)
                                {
                                    case 1:
                                        sensor = true;
                                        break;
                                    case 2:
                                        sensor = false;
                                        break;
                                    default:
                                        Console.WriteLine("Optiune invalida");
                                        break;
                                }

                                if (sensor == true)
                                {

                                    Console.Clear();
                                    int menuCenterX = centerX - 10;
                                    int menuCenterY = centerY - 2;

                                    Console.SetCursorPosition(menuCenterX, menuCenterY);
                                    Console.WriteLine("Ce tip de cafea doriti?");
                                    Console.SetCursorPosition(menuCenterX, menuCenterY + 1);
                                    Console.WriteLine("1. Americano");
                                    Console.SetCursorPosition(menuCenterX, menuCenterY + 2);
                                    Console.WriteLine("2. FlatWhite");
                                    Console.SetCursorPosition(menuCenterX, menuCenterY + 3);
                                    Console.WriteLine("3. Noisette");

                                    if (int.TryParse(Console.ReadLine(), out cafea))
                                    {
                                        switch (cafea)
                                        {
                                            case 1:
                                                incalzitor = true;
                                                TimerManager fierbereapa = new TimerManager();
                                                fierbereapa.StartTimer();
                                                Volum -= (espresso + 90);

                                                break;
                                            case 2:
                                                incalzitor = true;
                                                TimerManager incalzirelapte = new TimerManager();
                                                incalzirelapte.StartTimer(15);
                                                Volum -= espresso;
                                                lapte -= 120;
                                                break;
                                            case 3:
                                                incalzitor = true;
                                                TimerManager fierberelapte = new TimerManager();
                                                fierberelapte.StartTimer(20);
                                                Volum -= espresso;
                                                lapte -= 30;
                                                break;

                                        }

                                    }

                                    Console.ReadLine();
                                    break; 
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(responseStartX, switchStartY);
                                    Console.WriteLine("Va rugam sa adaugati cana");
                                    System.Threading.Thread.Sleep(3000);
                                }
                            }
                        } while (true);

                        break;

                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(responseStartX, responseStartY);
                        Console.WriteLine("Prepararea ceaiului e in alt program :)");
                        Console.ReadLine(); 
                        break; 

                    default:
                        Console.SetCursorPosition(responseStartX, responseStartY);
                        Console.WriteLine("Optiune invalida");
                        break;
                }
            }
            if (numar != 1)
            {
               
                break;
            }
            else
            { 
              
            Console.Clear();
            Console.SetCursorPosition(menuStartX, menuStartY);
            Console.Write("Doriti sa mai faceti o cafea? (Da/Nu): ");
            exitRequested = !Console.ReadLine().Trim().Equals("Da", StringComparison.OrdinalIgnoreCase);

            }
           

        }
    }



}

class Boiler
{
    public void VerificareApa(ref int Volum)
    {
        while (Volum < 200) 
        {
            int choice;
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            int centerX = consoleWidth / 2;
            int centerY = consoleHeight / 2;

            Console.Clear(); 

            PrintCentered("Alegeti cata apa doriti sa introduceti in boiler:", centerX, centerY);
            centerY++; 

            PrintCentered("1. 500 ml", centerX, centerY);
            centerY++; 

            PrintCentered("2. 600 ml", centerX, centerY);
            centerY++; 

            PrintCentered("3. 650 ml", centerX, centerY);
            centerY++; 

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Volum += 500;
                        Console.Clear();
                        centerY++; 
                        PrintCentered("Ati adaugat cu succes 500 ml de apa", centerX, centerY);
                        break;
                    case 2:
                        Volum += 600;
                        Console.Clear();
                        centerY++; 
                        PrintCentered("Ati adaugat cu succes 600 ml de apa", centerX, centerY);
                        break;
                    case 3:
                        Volum += 650;
                        Console.Clear();
                        centerY++; // Move to the next line
                        PrintCentered("Ati adaugat cu succes 650 ml de apa", centerX, centerY);
                        break;
                    default:
                        centerY++;
                        PrintCentered("Optiune inexistenta.", centerX, centerY);
                        break;
                }

                System.Threading.Thread.Sleep(1000); 
            }
            else 
            {
                centerY++; 
                PrintCentered("Optiune invalida. Va rugam alegeti 1, 2 sau 3.", centerX, centerY);
                
                System.Threading.Thread.Sleep(1000); 
            }
        }
    }

    public void VerificaVolumLapte(ref int lapte)
    {
        while (lapte < 200)
        {
            int choice;
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            int centerX = consoleWidth / 2;
            int centerY = consoleHeight / 2;

            Console.Clear(); 

            PrintCentered("Cat lapte doriti sa introduceti:", centerX, centerY);
            centerY++; 

            PrintCentered("1. 500 ml", centerX, centerY);
            centerY++; 

            PrintCentered("2. 600 ml", centerX, centerY);
            centerY++; 

            PrintCentered("3. 650 ml", centerX, centerY);
            centerY++; 

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        lapte += 500;
                        Console.Clear();
                        centerY++; 
                        PrintCentered("Ati adaugat cu succes 500 ml de lapte", centerX, centerY);
                        break;
                    case 2:
                        lapte += 600;
                        Console.Clear();
                        centerY++; 
                        PrintCentered("Ati adaugat cu succes 600 ml de lapte", centerX, centerY);
                        break;
                    case 3:
                        lapte += 650;
                        Console.Clear();
                        centerY++; 
                        PrintCentered("Ati adaugat cu succes 650 ml de lapte", centerX, centerY);
                        break;
                    default:
                        centerY++;
                        PrintCentered("Optiune inexistenta.", centerX, centerY);
                        break;
                }

                System.Threading.Thread.Sleep(1000); 
            }
            else 
            {
                centerY++; 
                PrintCentered("Optiune invalida. Va rugam alegeti 1, 2 sau 3.", centerX, centerY);

                System.Threading.Thread.Sleep(1000); 
            }


        }

    }
    private void PrintCentered(string message, int centerX, int centerY)
    {
        int messageX = centerX - message.Length / 2;
        Console.SetCursorPosition(messageX, centerY);
        Console.WriteLine(message);
    }
}


class TimerManager
{
    private Timer timer;
    private int elapsedTime = 0;

    public void StartTimer(int durationInSeconds = 10)
    {
        TimerCallback timerCallback = TimerCallbackMethod;
        timer = new Timer(timerCallback, null, 0, 1000);
        elapsedTime = 0;
        DurationInSeconds = durationInSeconds;
    }

    public void StopTimer()
    {
        timer.Dispose();
    }

    private void TimerCallbackMethod(object state)
    {
        elapsedTime++;
        Console.Clear();

        int artWidth = 16; 
        int artHeight = 7; 

        int centerX = (Console.WindowWidth - artWidth) / 2;
        int centerY = (Console.WindowHeight - artHeight) / 2;
        Console.Write($"Cafeaua se prepara. Va rugam sa asteptati:) : {elapsedTime} secunde");

        if (elapsedTime >= DurationInSeconds)
        {
            Console.Clear();
            StopTimer();

            Console.SetCursorPosition(centerX-2, centerY-2);
            Console.WriteLine(" Cafeaua dvs este gata");
            Console.WriteLine(" \n");
            Console.SetCursorPosition(centerX, centerY);
        Console.WriteLine("        ) ) )");
        Console.SetCursorPosition(centerX, centerY + 1);
        Console.WriteLine("      ( ( (");
        Console.SetCursorPosition(centerX, centerY + 2);
        Console.WriteLine("    |~~~~~~~~|");
        Console.SetCursorPosition(centerX, centerY + 3);
        Console.WriteLine("    |~~~~~~~~|)");
        Console.SetCursorPosition(centerX, centerY + 4);
        Console.WriteLine("    |~~~~~~~~|");
        Console.SetCursorPosition(centerX, centerY + 5);
        Console.WriteLine("   [__________]");
        }
    }

    public int DurationInSeconds { get; private set; }
}
