using System;
using System.IO;

class Nodo
{
    public int Valore;
    public Nodo Sinistra;
    public Nodo Destra;

    public Nodo(int valore)
    {
        Valore = valore;
        Sinistra = null;
        Destra = null;
    }
}

class Albero
{
    private Nodo radice;

    public void Inserisci(int valore)
    {
        radice = InserisciRicorsivo(radice, valore);
    }

    private Nodo InserisciRicorsivo(Nodo nodo, int valore)
    {
        if (nodo == null)
            return new Nodo(valore);

        if (valore < nodo.Valore)
            nodo.Sinistra = InserisciRicorsivo(nodo.Sinistra, valore);
        else if (valore > nodo.Valore)
            nodo.Destra = InserisciRicorsivo(nodo.Destra, valore);

        return nodo;
    }

    public void StampaInOrder()
    {
        if (radice == null)
        {
            Console.WriteLine("L'albero è vuoto.");
            return;
        }
        Console.Write("Albero ordinato: ");
        InOrder(radice);
        Console.WriteLine();
    }

    private void InOrder(Nodo nodo)
    {
        if (nodo == null) return;
        InOrder(nodo.Sinistra);
        Console.Write(nodo.Valore + " ");
        InOrder(nodo.Destra);
    }

    public void SalvaSuFile(string percorso)
    {
        using (StreamWriter sw = new StreamWriter(percorso))
        {
            SalvaRicorsivo(radice, sw);
        }
        Console.WriteLine($"Albero salvato in: {percorso}");
    }

    private void SalvaRicorsivo(Nodo nodo, StreamWriter sw)
    {
        if (nodo == null) return;
        SalvaRicorsivo(nodo.Sinistra, sw);
        sw.WriteLine(nodo.Valore);
        SalvaRicorsivo(nodo.Destra, sw);
    }

    public void CaricaDaFile(string percorso)
    {
        if (!File.Exists(percorso))
        {
            Console.WriteLine("File non trovato!");
            return;
        }

        radice = null; // reset albero
        string[] righe = File.ReadAllLines(percorso);
        foreach (string riga in righe)
        {
            if (int.TryParse(riga, out int valore))
                Inserisci(valore);
        }
        Console.WriteLine($"Albero caricato da: {percorso}");
    }

    // === RIEMPIMENTO CASUALE ===
    public void RiempiCasuale()
    {
        Console.Write("Quanti numeri vuoi generare? (max 100): ");
        if (!int.TryParse(Console.ReadLine(), out int quanti) || quanti <= 0 || quanti > 100)
        {
            Console.WriteLine("Valore non valido!");
            return;
        }

        radice = null; // reset albero
        Random rnd = new Random();
        for (int i = 0; i < quanti; i++)
        {
            int casuale = rnd.Next(1, 100);
            Inserisci(casuale);
        }
        Console.WriteLine($"Albero riempito con {quanti} numeri casuali.");
        StampaInOrder();
    }
}

class Program
{
    static void Main()
    {
        Albero albero = new Albero();
        string file = "albero.txt";
        bool esci = false;

        while (!esci)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Inserisci numero");
            Console.WriteLine("2. Stampa albero");
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
                        albero.Inserisci(num);
                    else
                        Console.WriteLine("Valore non valido!");
                    break;
                case "2":
                    albero.StampaInOrder();
                    break;
                case "3":
                    albero.SalvaSuFile(file);
                    break;
                case "4":
                    albero.CaricaDaFile(file);
                    break;
                case "5":
                    albero.RiempiCasuale();
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