using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LuhnAlgorythms;

namespace LuhnTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Constructors;
                bool _pnCheck;
                LuhnAlgorythm _pn = new LuhnAlgorythm();
                string _svar = "Angivet personnummer är ";

                //Fråga till användare
                Console.WriteLine("Test av utläsning av 'bool' från personnummercheck. Ange ett personnummer: '");
                string personNummer = Console.ReadLine();

                //Utvärdering av svaret från personnummerkontrollen.
                try
                {
                    _pnCheck = _pn.CheckIfPersonalIdIsCorrect(personNummer);
                    if (_pnCheck == true)
                    {
                        _svar = _svar + "givetvis korrekt.";

                    }
                    else
                    {
                        _svar = _svar + "tyvärr ogiltigt.";
                    }

                    Console.WriteLine(_svar);
                    Console.WriteLine("Vänligen tryck på 'enter' för att försöka igen!!!");
                    Console.ReadLine();

                }
                catch
                {
                    //Catchkod för att ta hand om FormatException behöver göras här...
                    Console.WriteLine("'" + _svar + "' är ett felaktigt personnummer. Nummret måste innehålla 10 siffror!!!");
                }


            }

        }

    }
}
