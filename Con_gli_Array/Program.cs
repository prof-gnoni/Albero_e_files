using System;
using System.IO;

class Program
{
    static int[] vettore = new int[100];
    static int contatore = 0;
    static string file = "vettore.txt";

    static void Inserisci(int valore)
    {
        if (contatore >= vettore.Length)
        {
            Console.WriteLine("Vettore pieno!");
            return;
        }
        vettore[contatore] = valore;
        contatore++;
        Console.WriteLine($"Inserito: {valore}");
    }

    static void Stampa()
    {
        if (contatore == 0)
        {
            Console.WriteLine("Il vettore è vuoto.");
            return;
        }
        Console.Write("Vettore: ");
        for (int i = 0; i < contatore; i++)
            Console.Write(vettore[i] + " ");
        Console.WriteLine();
    }

    static void SalvaSuFile()
    {
        using (StreamWriter sw = new StreamWriter(file))
        {
            for (int i = 0; i < contatore; i++)
                sw.WriteLine(vettore[i]);
        }
        Console.WriteLine($"Vettore salvato in: {file}");
    }

    static void CaricaDaFile()
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File non trovato!");
            return;
        }
        contatore = 0;
        string[] righe = File.ReadAllLines(file);
        foreach (string riga in righe)
        {
            if (int.TryParse(riga, out int valore))
                Inserisci(valore);
        }
        Console.WriteLine($"Vettore caricato da: {file}");
    }

    // === RIEMPIMENTO CASUALE ===
    static void RiempiCasuale()
    {
        Console.Write("Quanti numeri vuoi generare? (max 100): ");
        if (!int.TryParse(Console.ReadLine(), out int quanti) || quanti <= 0 || quanti > 100)
        {
            Console.WriteLine("Valore non valido!");
            return;
        }

        contatore = 0; // reset vettore
        Random rnd = new Random();
        for (int i = 0; i < quanti; i++)
        {
            int casuale = rnd.Next(1, 100); // numeri tra 1 e 99
            vettore[i] = casuale;
            contatore++;
        }
        Console.WriteLine($"Vettore riempito con {quanti} numeri casuali.");
        Stampa();
    }

    static void Main()
    {
        bool esci = false;
        while (!esci)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Inserisci numero");
            Console.WriteLine("2. Stampa vettore");
            Console.WriteLine("3. Salva su file");
            Console.WriteLine("4. Carica da file");
            Console.WriteLine("5. Riempi casualmente");
            Console.WriteLine("6. Esci");
            Console.Write("Scelta: ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci un numero: ");
                    if (int.TryParse(Console.ReadLine(), out int num))
                        Inserisci(num);
                    else
                        Console.WriteLine("Valore non valido!");
                    break;
                case "2":
                    Stampa();
                    break;
                case "3":
                    SalvaSuFile();
                    break;
                case "4":
                    CaricaDaFile();
                    break;
                case "5":
                    RiempiCasuale();
                    break;
                case "6":
                    esci = true;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}