using System;
using LuhnAlgorythms;

namespace LuhnTestApp
{
    /// <summary>
    /// Liten applikation för att enkelt testa svenska personnummer.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Constructors;
                var _pn = new LuhnAlgorythm();
                string _svar = "Angivet personnummer är ";

                //Fråga till användare
                Console.WriteLine("Test av utläsning av 'bool' från personnummercheck. Ange ett personnummer: '");

                //Utvärdering av svaret från personnummerkontrollen.
                try
                {
                    if (_pn.CheckIfPersonalIdIsCorrect(Console.ReadLine()) == true)
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
