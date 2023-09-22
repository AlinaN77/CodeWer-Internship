using System;
using System.Collections.Generic;

namespace exercitiu2
{
    class Program
    {
        static void Main(string[] args)
        {   
            Carne sunca = new Carne(7m, 0.03m);
            Planta salata = new Planta(1m, 0.03m);
            decimal distanta = 200;
            int count1 = 0;
            int count2 = 0;

            bool continua = true;
            Carnivor lup = new Carnivor(Animal.TipAnimal.Lup, "lup", 70m, 85.0m, new Animal.Dimensiune(1.5m, 0.7m, 1.2m));
            Ierbivor oaie = new Ierbivor(Animal.TipAnimal.Oaie, "oaie", 40m, 15.0m, new Animal.Dimensiune(1m, 0.7m, 1m));
            Omnivor urs = new Omnivor(Animal.TipAnimal.Urs, "urs", 100m, 70.0m, new Animal.Dimensiune(2m, 0.5m, 3m));

            Animal pisica = Animal.CreeazaAnimal(Animal.TipAnimal.Pisica, "pisica", 7m, new Animal.Dimensiune(0.3m, 0.2m, 0.1m), 30);
            Animal veverita = Animal.CreeazaAnimal(Animal.TipAnimal.Veverita, "veverita", 3m, new Animal.Dimensiune(0.4m, 0.1m, 0.1m), 10);
            Animal vaca = Animal.CreeazaAnimal(Animal.TipAnimal.Vaca, "vaca", 3m, new Animal.Dimensiune(2m, 0.9m, 2.6m), 15);

            

            List<Animal> listAnimale = new List<Animal>();

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int tipAnimal = random.Next(0, 6);

                switch ((Animal.TipAnimal)tipAnimal)
                {
                    case Animal.TipAnimal.Lup:
                        listAnimale.Add(lup);
                        break;
                    case Animal.TipAnimal.Oaie:
                        listAnimale.Add(oaie);
                        break;
                    case Animal.TipAnimal.Urs:
                        listAnimale.Add(urs);
                        break;
                    case Animal.TipAnimal.Veverita:
                        listAnimale.Add(veverita);
                        break;
                    case Animal.TipAnimal.Pisica:
                        listAnimale.Add(pisica);
                        break;
                    case Animal.TipAnimal.Vaca:
                        listAnimale.Add(vaca);
                        break;
                }
            }

            while (continua)
            {
                Console.WriteLine("\nMeniu:");
                Console.WriteLine("1. Hraneste lupul");
                Console.WriteLine("2. Hraneste oaia");
                Console.WriteLine("3. Hraneste ursul");
                Console.WriteLine("4. Detaliile animalelor");
                Console.WriteLine("5. Lista random de animale");
                Console.WriteLine("6. Numarul animalelor ce mananca");
                Console.WriteLine("7. Iesire");

                int optiune = Convert.ToInt32(Console.ReadLine());

                switch (optiune)
                {
                    case 1:
                        Console.WriteLine("Alege mancarea lupului:");
                        Console.WriteLine("1. Salata");
                        Console.WriteLine("2. Sunca");
                        int hranaLup = Convert.ToInt32(Console.ReadLine());
                        if (hranaLup == 1)
                        {
                            lup.Mananca(salata);
                            continue;
                        }
                        else if (hranaLup == 2)
                        {
                            Console.WriteLine("Cate bucati de sunca mananca lupul?");
                            int input = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < input; i++)
                            {
                                lup.Mananca(sunca);
                                
                            }
                            double masa = (double)sunca.Greutate * input;
                            if (masa >= (1.0 / 8.0) * (double)lup.Greutate)
                            {
                                Console.WriteLine("Lupul mananca");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Optiune invalida.");
                        }
                        lup.Alearga(distanta);
                        break;
                    case 2:
                        Console.WriteLine("Alege mancarea oii:");
                        Console.WriteLine("1. Salata");
                        Console.WriteLine("2. Sunca");
                        int hranaOaie = Convert.ToInt32(Console.ReadLine());
                        if (hranaOaie == 1)
                        {
                            Console.WriteLine("Cate bucati de salata solicitati sa ii dati oii");
                            int input2 = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < input2; i++)
                            {
                                oaie.Mananca(salata);
                            }
                            double masa = (double)salata.Greutate * input2;
                            if (masa >= (1.0 / 8.0) * (double)oaie.Greutate)
                            {
                                Console.WriteLine("Oaia mananca");
                            }
                        }
                        else if (hranaOaie == 2)
                        {
                            oaie.Mananca(sunca);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Optiune invalida.");
                        }
                        oaie.Alearga(distanta);
                        break;
                    case 3:
                        Console.WriteLine("Alege mancarea ursului:");
                        Console.WriteLine("1. Salata");
                        Console.WriteLine("2. Sunca");
                        int hranaUrs = Convert.ToInt32(Console.ReadLine());
                        if (hranaUrs == 1)
                        {
                            Console.WriteLine("Cate bucati de salata solicitati sa ii dati");
                            int input3 = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < input3; i++)
                            {
                                urs.Mananca(salata);
                            }
                            double masa = (double)salata.Greutate * input3;
                            if (masa >= (1.0 / 8.0) * (double)urs.Greutate)
                            {
                                Console.WriteLine("Ursul mananca");
                            }
                        }
                        else if (hranaUrs == 2)
                        {
                            Console.WriteLine("Cate bucati de sunca solicitati sa ii dati");
                            int input4 = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < input4; i++)
                            {
                                urs.Mananca(sunca);
                            }
                            double masa = (double)sunca.Greutate * input4;
                            if (masa >= (1 / 8) * (double)urs.Greutate)
                            {
                                Console.WriteLine("Ursul mananca");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Optiune invalida.");
                        }
                        urs.Alearga(distanta);
                        break;
                    case 4:
                        Console.WriteLine("Selectati animalul:");
                        Console.WriteLine("1.Lup");
                        Console.WriteLine("2.Oaie");
                        Console.WriteLine("3.Urs");

                        int alegere = Convert.ToInt32(Console.ReadLine());
                        if (alegere == 1)
                        {
                            Console.WriteLine(lup);
                        }
                        else if (alegere == 2)
                        {
                            Console.WriteLine(oaie);
                        }
                        else if (alegere == 3)
                        {
                            Console.WriteLine(urs);
                        }
                        else
                        {
                            Console.WriteLine("Alegere invalida");
                        }
                        break;
                    case 5:
                        foreach (var animal in listAnimale)
                        {
                            Console.WriteLine($"\n{animal}");
                            if (animal is Carnivor)
                            {
                                Console.WriteLine($"{animal.Nume} mananca carne.");
                                ((Carnivor)animal).Mananca(sunca);
                                count1++;
                            }
                            else if (animal is Ierbivor)
                            {
                                Console.WriteLine($"{animal.Nume} mananca plante.");
                                ((Ierbivor)animal).Mananca(salata);
                                count2++;
                            }
                            else if (animal is Omnivor)
                            {
                                Console.WriteLine($" {animal.Nume} mananca carne si plante.");
                                ((Omnivor)animal).Mananca(sunca);
                                ((Omnivor)animal).Mananca(salata);
                                count1++;
                                count2++;
                            }
                        }
                        break;
                    case 6:
                        Console.WriteLine("Animale care mananca:" + listAnimale.Count);
                        Console.WriteLine("Animale care mananca carne:" + count1);
                        Console.WriteLine("Animale care mananca plante:" + count2);
                        break;
                    case 7:
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Nu exista asemenea optiune. Mai incerarti");
                        break;
                }
            }
        }
    }

    abstract class Mancare
    {
        public decimal Greutate { get; set; }
        private decimal energie;
        public decimal Energie
        {
            get { return energie; }
            set
            {
                if (value >= 0 && value <= 0.05m)
                {
                    energie = value;
                }
                else
                {
                    Console.WriteLine("Valoarea trebuie sa fie intre 0 si 0.05");
                }
            }
        }

        protected Mancare(decimal greutate, decimal energie)
        {
            Greutate = greutate;
            Energie = energie;
        }
    }

    class Carne : Mancare
    {
        public Carne(decimal greutate, decimal energie) : base(greutate, energie)
        {

        }
    }

    class Planta : Mancare
    {
        public Planta(decimal greutate, decimal energie) : base(greutate, energie)
        {

        }
    }

    abstract class Animal
    {
        public enum TipAnimal
        {
            Lup,
            Urs,
            Oaie,
            Veverita,
            Pisica,
            Vaca
        }

        public TipAnimal Tip { get; protected set; }
        public Dimensiune Dimensiuni { get; protected set; }
        public string Nume { get; set; }
        public decimal Greutate { get; protected set; }
        public decimal Viteza { get; protected set; }
        private static int numarAnimale = 0;

        public struct Dimensiune
        {
            public decimal Lungime { get; }
            public decimal Latime { get; }
            public decimal Inaltime { get; }

            public Dimensiune(decimal lungime, decimal latime, decimal inaltime)
            {
                Lungime = lungime;
                Latime = latime;
                Inaltime = inaltime;
            }
        }

        public Animal(TipAnimal tip, string nume, decimal greutate, decimal viteza, Dimensiune dimensiune)
        {
            Tip = tip;
            Nume = nume;
            Greutate = greutate;
            Viteza = viteza;
            Dimensiuni = dimensiune;
            numarAnimale++;
        }

        public static int NumarAnimale
        {
            get { return numarAnimale; }
        }

        public void Numara()
        {
            Console.WriteLine("Numarul total: " + numarAnimale);
        }

        protected List<Mancare> stomac = new List<Mancare>();

        public abstract bool MancarePotrivita(Mancare mancare);

        public void Mananca(Mancare mancare)
        {
            if (MancarePotrivita(mancare))
            {
                stomac.Add(mancare);
            }
            else
            {
                Console.WriteLine("Acest animal nu accepta acest tip de mancare");
            }
        }

        public static Animal CreeazaAnimal(TipAnimal tip, string nume, decimal greutate, Dimensiune dimensiune, decimal viteza)
        {
            switch (tip)
            {
                case TipAnimal.Lup:
                    return new Carnivor(TipAnimal.Lup, nume, greutate, viteza, dimensiune);
                case TipAnimal.Urs:
                    return new Omnivor(TipAnimal.Urs, nume, greutate, viteza, dimensiune);
                case TipAnimal.Oaie:
                    return new Ierbivor(TipAnimal.Oaie, nume, greutate, viteza, dimensiune);
                case TipAnimal.Pisica:
                    return new Omnivor(TipAnimal.Pisica, nume, greutate, viteza, dimensiune);
                case TipAnimal.Veverita:
                    return new Ierbivor(TipAnimal.Veverita, nume, greutate, viteza, dimensiune);
                case TipAnimal.Vaca:
                    return new Ierbivor(TipAnimal.Vaca, nume, greutate, viteza, dimensiune);
                default:
                    throw new ArgumentException("Tip de animal necunoscut.");
            }
        }
    }

    class Carnivor : Animal
    {
        public Carnivor(TipAnimal tip, string nume, decimal greutate, decimal viteza, Dimensiune dimensiune)
            : base(tip, nume, greutate, viteza, dimensiune)
        {

        }

        public override bool MancarePotrivita(Mancare mancare)
        {
            return mancare is Carne;
        }

        public decimal Energie()
        {
            decimal sumaEnergieMancare = 0m;

            foreach (var mancare in stomac)
            {
                sumaEnergieMancare += mancare.Energie;
            }

            decimal nivelEnergie = 0.2m - (1m / 5m) * (sumaEnergieMancare / stomac.Count) + sumaEnergieMancare;
            Console.WriteLine("Nivelul de energie a lupului este: " + nivelEnergie + "%");

            return nivelEnergie;
        }

        public void Alearga(decimal distanta)
        {
            double timp = (double)distanta / ((double)Viteza / (double)Energie());
            Console.WriteLine("Lupul va alerga distanta in: " + timp);
        }

        public override string ToString()
        {
            return $"Tip animal: Carnivor\nNume: {Nume}\nGreutate: {Greutate} kg\nDimensiuni: {Dimensiuni.Lungime} x {Dimensiuni.Latime} x {Dimensiuni.Inaltime}\nViteza: {Viteza} m/s";
        }
    }

    class Ierbivor : Animal
    {
        public Ierbivor(TipAnimal tip, string nume, decimal greutate, decimal viteza, Dimensiune dimensiune)
            : base(tip, nume, greutate, viteza, dimensiune)
        {

        }

        public override bool MancarePotrivita(Mancare mancare)
        {
            return mancare is Planta;
        }

        public decimal Energie()
        {
            decimal sumaEnergieMancare = 0m;

            foreach (var mancare in stomac)
            {
                sumaEnergieMancare += mancare.Energie;
            }

            decimal nivelEnergie = 0.5m - (1m / 3m) * (sumaEnergieMancare / stomac.Count) + sumaEnergieMancare;
            Console.WriteLine("Nivelul de energie a oii este: " + nivelEnergie + "%");

            return nivelEnergie;
        }

        public void Alearga(decimal distanta)
        {
            double timp = (double)distanta / ((double)Viteza / (double)Energie());
            Console.WriteLine("Oaia va alerga distanta in: " + timp);
        }

        public override string ToString()
        {
            return $"Tip animal: Ierbivor\nNume: {Nume}\nGreutate: {Greutate} kg\nDimensiuni: {Dimensiuni.Lungime} x {Dimensiuni.Latime} x {Dimensiuni.Inaltime}\nViteza: {Viteza} m/s";
        }
    }

    class Omnivor : Animal
    {
        public Omnivor(TipAnimal tip, string nume, decimal greutate, decimal viteza, Dimensiune dimensiune)
            : base(tip, nume, greutate, viteza, dimensiune)
        {

        }

        public override bool MancarePotrivita(Mancare mancare)
        {
            return mancare is Carne || mancare is Planta;
        }

        public decimal Energie()
        {
            decimal sumaEnergieMancare = 0m;

            foreach (var mancare in stomac)
            {
                sumaEnergieMancare += mancare.Energie;
            }

            decimal coeficientGreutate = 1m;

            foreach (var mancare in stomac)
            {
                if (mancare is Planta)
                {
                    coeficientGreutate = 1m / 2m;
                    break;
                }
            }

            decimal nivelEnergie = 0.35m + coeficientGreutate * Greutate * (sumaEnergieMancare / stomac.Count) + sumaEnergieMancare;
            Console.WriteLine("Nivelul de energie al ursului este: " + nivelEnergie + "%");

            return nivelEnergie;
        }

        public void Alearga(decimal distanta)
        {
            double timp = (double)distanta / ((double)Viteza / (double)Energie());
            Console.WriteLine("Ursul va alerga distanta in: " + timp);
        }

        public override string ToString()
        {
            return $"Tip animal: Omnivor\nNume: {Nume}\nGreutate: {Greutate} kg\nDimensiuni: {Dimensiuni.Lungime} x {Dimensiuni.Latime} x {Dimensiuni.Inaltime}\nViteza: {Viteza} m/s";
        }
    }
}
