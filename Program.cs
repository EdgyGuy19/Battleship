using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt_3
{

    class Program
    {
        static void Main(string[] args)
        {
            /*string[,] koordinater = new string[6, 4];
            koordinater[0, 0] = "A1";
            koordinater[0, 1] = "A2";
            koordinater[0, 2] = "A3";
            koordinater[0, 3] = "A4";
            koordinater[1, 0] = "B1";
            koordinater[1, 1] = "B2";
            koordinater[1, 2] = "B3";
            koordinater[1, 3] = "B4";
            koordinater[2, 0] = "C1";
            koordinater[2, 1] = "C2";
            koordinater[2, 2] = "C3";
            koordinater[2, 3] = "C4";
            koordinater[3, 0] = "D1";
            koordinater[3, 1] = "D2";
            koordinater[3, 2] = "D3";
            koordinater[3, 3] = "D4";
            koordinater[4, 0] = "E1";
            koordinater[4, 1] = "E2";
            koordinater[4, 2] = "E3";
            koordinater[4, 3] = "E4";
            koordinater[5, 0] = "F1";
            koordinater[5, 1] = "F2";
            koordinater[5, 2] = "F3";
            koordinater[5, 3] = "F4";*/

            string alfabetet = "ABCDEF";
            string siffror = "1234";



            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int kartBredd = 6;
            int kartHöjd = 4;
            string[,] spelarensKarta = new string[kartBredd, kartHöjd];
            string[,] datornsKarta = new string[kartBredd, kartHöjd];
            bool[,] spelarensSkott = new bool[kartBredd, kartHöjd];
            bool[,] datornsSkott = new bool[kartBredd, kartHöjd];
            Random slump = new Random();
            string filnamn = "vinnaren";
            bool fusk = false;

            //Randomizer för placering
            int bredd = slump.Next(kartBredd);
            int höjd = slump.Next(kartHöjd);
            int bredd2 = slump.Next(kartBredd);
            int höjd2 = slump.Next(kartHöjd);

            string val = "";
            while (val != "3")
            {
                Rittning();
                Console.WriteLine("1. Spela Sänkaskepp");
                Console.WriteLine("2. Visa senaste vinnaren");
                Console.WriteLine("3. Avsluta");
                val = Console.ReadLine();
                Console.Clear();
                switch(val)
                {
                    case "1":
                        SkapaKartorna();
                        PlaceraSkepp();
                        SpelaSänkaSkepp();
                        break;
                   
                    case "2":
                        string filinnehål = File.ReadAllText(filnamn);
                        if (File.Exists(filnamn))
                        {
                            Console.WriteLine("Winner List");
                            Console.WriteLine("_______________________________________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine($"Senaste vinnaren: {filinnehål}");
                        }
                        else
                        {
                            Console.WriteLine("Ingen har vunnit än");
                        }
                        break;
                    case "3":
                        break;
                    case "FUSK1":
                        fusk = true;
                        break;
                    case "FUSK2":
                        fusk = false;
                        break;
                }
            }

            // Fyller spelarens och datorns kartor med tomma rutor
            void SkapaKartorna()
            {
                for (int y = 0; y < kartHöjd; y++)
                {
                    for (int x = 0; x < kartBredd; x++)
                    {
                        spelarensKarta[x, y] = "O";
                        datornsKarta[x, y] = "O";
                        spelarensSkott[x, y] = false;
                        datornsSkott[x, y] = false;
                        Console.Write(datornsKarta[x, y]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            
            
             void Rittning()
            {
                Console.WriteLine("                                     |__");
                Console.WriteLine("                                     |\\/");
                Console.WriteLine("                                     ---");
                Console.WriteLine("                                     / | [");
                Console.WriteLine("                              !      | |||");
                Console.WriteLine("                            _/|     _/|-++'");
                Console.WriteLine("                        +  +--|    |--|--|_ |-");
                Console.WriteLine("                     { /|__|  |/\\__|  |--- |||__/");
                Console.WriteLine("                    +---------------___[}-_===_.'____                 /\\");
                Console.WriteLine("                ____`-' ||___-{]_| _[}-  |     |_[___\\==--            \\/   _");
                Console.WriteLine(" __..._____--==/___]_|__|_____________________________[___\\==--____,------' .7");
                Console.WriteLine("|                                                                     BB-61/");
                Console.WriteLine(" \\_________________________________________________________________________|");
                Console.WriteLine();
                Console.WriteLine("_______________________________________________________________________________________________________________________");
                Console.WriteLine();
            }

            // Placerar X på några av spelarens och datorns platser
            void PlaceraSkepp()
            {
                test();
                test();
                datornsKarta[bredd, höjd] = "X";
                datornsKarta[bredd2, höjd2] = "X";
                if (datornsKarta[bredd2, höjd2] == datornsKarta[bredd, höjd])  // VARFÖR FUNGERAR INTE MED WHILE
                {
                    datornsKarta[bredd2, höjd2] = "X";
                }

            }

            // Ritar ut spelarens och datorns kartor
            void RitaSpelplanen()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Rittning();
                Console.WriteLine("Spelarens karta");
                for (int y = 0; y < kartHöjd; y++)
                {
                    Console.Write(siffror[y]);
                    for (int x = 0; x < kartBredd; x++)
                    {
                        if (datornsSkott[x, y] == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(spelarensKarta[x, y]);

                        // Återställ färgen till grå
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.WriteLine();
                }
                Console.Write(" " + alfabetet);
                Console.WriteLine();
                Console.WriteLine();

                // Rita datorns karta
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Datorns karta");
                for (int y = 0; y < kartHöjd; y++)
                {
                    Console.Write(siffror[y]);
                    for (int x = 0; x < kartBredd; x++)
                    {
                        // Endast rutor som spelaren har skjutit på syns
                        if (spelarensSkott[x, y] == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(datornsKarta[x, y]);
                        }
                        else if (fusk == true)
                        {
                            Console.Write(datornsKarta[x, y]);
                        }
                        else
                        {
                            Console.Write("-");
                        }

                        // Återställ färgen till grå
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.WriteLine();
                }
                Console.Write(" " + alfabetet);
                Console.WriteLine();
            }

            // Kollar om spelaren har vunnit
            bool HarSpelarenVunnit()
            {
                for (int y = 0; y < kartHöjd; y++)
                {
                    for (int x = 0; x < kartBredd; x++)
                    {
                        if (datornsKarta[x, y] == "X" && spelarensSkott[x, y] == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            // Kollar om datorn har vunnit
            bool HarDatornVunnit()
            {
                for (int y = 0; y < kartHöjd; y++)
                {
                    for (int x = 0; x < kartBredd; x++)
                    {
                        if (spelarensKarta[x, y] == "X" && datornsSkott[x, y] == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            // Läser in ett heltal från användaren
            int ReadInt()
            {
                int heltal;
                while (int.TryParse(Console.ReadLine(), out heltal) == false)
                {
                    Console.WriteLine("Du skrev inte in ett heltal. Försök igen.");
                }
                return heltal;
            }

            void SpelaSänkaSkepp()
            {
                bool harNågonVunnit = false;
                while (harNågonVunnit == false)
                {
                    Console.Clear();
                    Rittning();
                    RitaSpelplanen();
                    Console.WriteLine("Var vill du skjuta? (X)");
                    int x = ReadInt();
                    if (x < 1 || x > 6) //KANSKE GÖRA DET I READINT?????
                    {
                        Console.WriteLine("Talet får inte vara större än 6 och mindre än 1. Testa igen.");
                        x = ReadInt();
                    }
                    Console.WriteLine("Var vill du skjuta? (Y)");
                    int y = ReadInt();
                    if (y < 1 || y > 4)     //KANSKE GÖRA DET I READINT?????
                    {
                        Console.WriteLine("Talet får inte vara större än 4 och mindre än 1. Testa igen.");
                        y = ReadInt();
                    }
                    spelarensSkott[x - 1, y - 1] = true;
                    datornsSkott[slump.Next(kartBredd), slump.Next(kartHöjd)] = true;

                    if (HarSpelarenVunnit() && HarDatornVunnit())
                    {
                        Console.Clear();
                        Rittning();
                        RitaSpelplanen();
                        Console.WriteLine("Oavgjort");
                        Console.ReadKey();
                        harNågonVunnit = true;
                        Console.Clear();
                    }

                    else if (HarSpelarenVunnit())
                    {
                        Console.Clear();
                        Rittning();
                        RitaSpelplanen();
                        Console.WriteLine("Spelaren vann");
                        Console.WriteLine("Skriv in ditt namn");
                        Console.ForegroundColor = ConsoleColor.White;
                        string senasteVinnaren = Console.ReadLine();
                        File.WriteAllText(filnamn, senasteVinnaren);
                        Console.ReadKey();
                        harNågonVunnit = true;
                        Console.Clear();
                    }
                    else if (HarDatornVunnit())
                    {
                        Console.Clear();
                        Rittning();
                        RitaSpelplanen();
                        Console.WriteLine("Datorn vann");
                        string senasteVinnaren = "Datorn";
                        File.WriteAllText(filnamn, senasteVinnaren);
                        Console.ReadKey();
                        harNågonVunnit = true;
                        Console.Clear();
                    }
                }
            }

            void test()
            {
                val = "";
                Console.Clear();
                Rittning();
                for (int y = 0; y < kartHöjd; y++)
                {
                    Console.Write(siffror[y]);
                    for (int x = 0; x < kartBredd; x++)
                    {
                        if (datornsSkott[x, y] == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(spelarensKarta[x, y]);

                        // Återställ färgen till grå
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.WriteLine();
                }
                Console.Write(" " + alfabetet);
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Skriv in koordinaten för den valda rutan");
                val = Console.ReadLine().ToUpper();
                switch(val)
                {
                    case "A1":
                        spelarensKarta[0, 0] = "X";
                        break;
                    case "A2":
                        spelarensKarta[0, 1] = "X";
                        break;
                    case "A3":
                        spelarensKarta[0, 2] = "X";
                        break;
                    case "A4":
                        spelarensKarta[0, 3] = "X";
                        break;
                    case "B1":
                        spelarensKarta[1, 0] = "X";
                        break;
                    case "B2":
                        spelarensKarta[1, 1] = "X";
                        break;
                    case "B3":
                        spelarensKarta[1, 2] = "X";
                        break;
                    case "B4":
                        spelarensKarta[1, 3] = "X";
                        break;
                    case "C1":
                        spelarensKarta[2, 0] = "X";
                        break;
                    case "C2":
                        spelarensKarta[2, 1] = "X";
                        break;
                    case "C3":
                        spelarensKarta[2, 2] = "X";
                        break;
                    case "C4":
                        spelarensKarta[2, 3] = "X";
                        break;
                    case "D1":
                        spelarensKarta[3, 0] = "X";
                        break;
                    case "D2":
                        spelarensKarta[3, 1] = "X";
                        break;
                    case "D3":
                        spelarensKarta[3, 2] = "X";
                        break;
                    case "D4":
                        spelarensKarta[3, 3] = "X";
                        break;
                    case "E1":
                        spelarensKarta[4, 0] = "X";
                        break;
                    case "E2":
                        spelarensKarta[4, 1] = "X";
                        break;
                    case "E3":
                        spelarensKarta[4, 2] = "X";
                        break;
                    case "E4":
                        spelarensKarta[4, 3] = "X";
                        break;
                    case "F1":
                        spelarensKarta[5, 0] = "X";
                        break;
                    case "F2":
                        spelarensKarta[5, 1] = "X";
                        break;
                    case "F3":
                        spelarensKarta[5, 2] = "X";
                        break;
                    case "F4":
                        spelarensKarta[5, 3] = "X";
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }



            Console.ReadKey();
        }
    }
}
