using System;
using System.IO;

// === NODO DELL'ALBERO ===
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

// === ALBERO BINARIO DI RICERCA ===
class Albero
{
    private Nodo radice;

    // Inserisce un valore nell'albero
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

    // Visita IN-ORDER: sinistra → radice → destra (stampa ordinato)
    public void StampaInOrder()
    {
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

    // Salva l'albero su file (in-order)
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

    // Carica i valori da file e li inserisce nell'albero
    public void CaricaDaFile(string percorso)
    {
        if (!File.Exists(percorso))
        {
            Console.WriteLine("File non trovato!");
            return;
        }

        string[] righe = File.ReadAllLines(percorso);
        foreach (string riga in righe)
        {
            if (int.TryParse(riga, out int valore))
                Inserisci(valore);
        }
        Console.WriteLine($"Albero caricato da: {percorso}");
    }
}

// === PROGRAMMA PRINCIPALE ===
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
            Console.WriteLine("5. Esci");
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
                    esci = true;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}