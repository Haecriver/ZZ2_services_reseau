using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLayer;

namespace TP1_ServicesReseau
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager businessManager = new BusinessManager();

            int input;
            bool end = false;
            IEnumerable<string> res;

            while (!end)
            {
                Console.Out.WriteLine("Menu");
                Console.Out.WriteLine("1 - All matches");
                Console.Out.WriteLine("2 - All stades");
                Console.Out.WriteLine("3 - All siths");
                Console.Out.WriteLine("4 - Jedi 3 F 50 HP");
                Console.Out.WriteLine("5 - Match 200 places siths");
                Console.Out.WriteLine("6 - Play !");
                Console.Out.WriteLine("7 - Exit");
                input = int.Parse(Console.In.ReadLine());
                switch (input)
                {
                    case 1:
                        /* List<Match> = businessManager.getAllMatches();
                         Console.Out.Write(businessManager.toString());*/

                        Console.Out.WriteLine("Si quelqu'un pouvait m'expliquer le question demandee sur le sujet, merci ...");

                        break;
                    case 2:
                        res = businessManager.getStringStades();
                        foreach (String el in res)
                        {
                            Console.Out.WriteLine(el);
                        }
                        break;
                    case 3:
                        res = businessManager.getStringObscurJedis();       //Ce sont des Sith pas des jedis obscurs !!
                        foreach (String el in res)
                        {
                            Console.Out.WriteLine(el);
                        }
                        break;
                    case 4:
                        res = businessManager.getStringJedis(3,50);
                        foreach (String el in res)
                        {
                            Console.Out.WriteLine(el);
                        }
                        break;
                    case 5:
                        res = businessManager.getStringSithMatchesOver200();
                        foreach (String el in res)
                        {
                            Console.Out.WriteLine(el);
                        }
                        break;
                    case 6:
                        businessManager.playTestMatch(); 
                        break;
                    case 7:
                        end = true;
                        break;
                    default:
                        Console.Out.WriteLine("Bad input");
                        break;
                }
            }
        }
    }
}
