# 🌳 Albero Binario di Ricerca — Esercizi C# Console

Due implementazioni didattiche di un **albero binario di ricerca** in C#, per studenti di **quarta superiore** (indirizzo informatico).

---

## 📦 Progetti inclusi

| Progetto | Descrizione |
|---|---|
| 📁 `Albero_e_files` | Albero binario con classi `Nodo` e puntatori |
| 📁 `Con_gli_array` | Albero binario rappresentato con un array |

---

## ⚙️ Funzionalità (comuni a entrambi)

| Voce menu | Descrizione |
|---|---|
| 1. Inserisci numero | Aggiunge un valore alla struttura |
| 2. Stampa | Visualizza gli elementi (in-order) |
| 3. Salva su file | Scrive i dati in un file `.txt` |
| 4. Carica da file | Legge i dati dal file `.txt` |
| 5. Riempi casualmente | Genera N numeri casuali (1–99) |
| 6. Esci | Termina il programma |

---

## 🚀 Come eseguire

### Prerequisiti
- [.NET SDK](https://dotnet.microsoft.com/download) versione 6 o superiore

### Avvio
```bash
git clone https://github.com/tuo-username/tuo-repo.git
cd tuo-repo

# Progetto con nodi
cd AlberoConNodi
dotnet run

# Progetto con vettore
cd ../AlberoConVettore
dotnet run
```

---

## 📁 Struttura del repository

```
📦 tuo-repo
 ┣ 📁 Albero_e_files
 ┃  ┣ 📄 Program.cs
 ┃  ┗ 📄 albero.txt
 ┣ 📁 Con_gli_Array
 ┃  ┣ 📄 Program.cs
 ┃  ┗ 📄 vettore.txt
 ┗ 📄 README.md
```

---

## ▶️ Esempio di output — Albero_e_files

```
--- MENU ---
1. Inserisci numero  2. Stampa  3. Salva  4. Carica  5. Casuale  6. Esci
Scelta: 1
Inserisci un numero: 5
Inserito: 5

Scelta: 1
Inserisci un numero: 2
Inserito: 2

Scelta: 1
Inserisci un numero: 8
Inserito: 8

Scelta: 2
Albero ordinato: 2 5 8

Scelta: 3
Albero salvato in: albero.txt
```

### Contenuto di `albero.txt`
```
2
5
8
```

---

## ▶️ Esempio di output — Con_gliArray

```
--- MENU ---
1. Inserisci numero  2. Stampa  3. Salva  4. Carica  5. Casuale  6. Esci
Scelta: 5
Quanti numeri vuoi generare? (max 100): 4
Vettore riempito con 4 numeri casuali.
Vettore: 15 42 7 63

Scelta: 3
Vettore salvato in: vettore.txt
```

### Contenuto di `vettore.txt`
```
15
42
7
63
```

---

## 🔢 Formula — Albero con vettore

Un vettore può rappresentare un albero binario **senza usare classi o puntatori**.  
Per ogni elemento all'indice `i` vale:

| Relazione | Formula |
|---|---|
| Figlio sinistro | `2 * i + 1` |
| Figlio destro | `2 * i + 2` |
| Genitore | `(i - 1) / 2` |

### Esempio visivo

```
           [4]              ← indice 0
          /    \
       [2]      [6]         ← indici 1, 2
       / \      / \
     [1] [3]  [5] [7]      ← indici 3, 4, 5, 6
```

In un vettore diventa:

```
indice:   0   1   2   3   4   5   6
valore:  [4] [2] [6] [1] [3] [5] [7]
```

---

## ⚖️ Confronto: Nodi vs Vettore

| | AlberoConNodi | AlberoConVettore |
|---|---|---|
| **Struttura** | Classe `Nodo` con riferimenti | Semplice `int[]` |
| **Navigazione** | Puntatori sinistra/destra | Formula matematica |
| **Difficoltà** | ⭐⭐⭐ | ⭐⭐ |
| **Memoria** | Dinamica (cresce con i nodi) | Fissa (dimensione max fissa) |
| **Ordine inserimento** | Auto-organizzato | Ordine di inserimento |
| **Adatto per** | Capire la ricorsione | Capire gli array e le formule |

> 💡 **Quando usare quale?**  
> Il vettore è più semplice da implementare e ideale per alberi **completi** (tutti i livelli pieni).  
> I nodi sono più flessibili e scalano meglio con dati variabili.

---

## 🧠 Obiettivi didattici

- Array e gestione manuale degli indici
- Classi, oggetti e riferimenti
- Ricorsione (visita in-order)
- Lettura e scrittura su file (`StreamWriter`, `File.ReadAllLines`)
- Generazione di numeri casuali con `Random`
- Menu interattivo con `while` e `switch`

---

## 👨‍🏫 Note

Esercizio realizzato a scopo didattico per le classi quarte dell'indirizzo informatico.  
Liberamente modificabile e distribuibile.
