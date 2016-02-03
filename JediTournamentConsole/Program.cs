using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntitiesLayer;
using BusinessLayer;

namespace JediTournamentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager businessManager = new BusinessManager();
            int input;
            bool end = false;
            IEnumerable<string> res;

            Console.Out.WriteLine("Test connection");
            Jedi jedi = businessManager.testBDD();
            Console.Out.WriteLine(jedi.ToString());

            // TEST CARACTERISTIQUE

            List<Caracteristique> caracts = businessManager.getCaracteristique();

            List<Caracteristique> cj = new List<Caracteristique>();
            cj.Add(new Caracteristique( EDefCaracteristique.Sante, "TEST JEDI 1", ETypeCaracteristique.Jedi, 90));

            List<Caracteristique> cs = new List<Caracteristique>();
            cs.Add(new Caracteristique( EDefCaracteristique.Chance, "TEST STADE 1", ETypeCaracteristique.Stade, 10));

            //Test ajout
            caracts.Add(new Caracteristique(EDefCaracteristique.Chance,"TEST CARACT 1",ETypeCaracteristique.Jedi,0));
            caracts.Add(cj[0]);
            caracts.Add(cs[0]);
            //Test suppression
            caracts.Remove(caracts[2]);
            //Test update
            caracts[2].Nom = "toto";
            businessManager.updateCaracteristique(caracts);

            // TEST UTILISATEUR

           List<Utilisateur> users = businessManager.getUtilisateur();
           //Test ajout
           users.Add(new Utilisateur("jean", "jaque", "j", "j"));
           //Test suppression
           users.Remove(users[2]);
           //Test update
           users[0].Prenom = "toto";
           businessManager.updateUtilisateur(users);

            
            //    TEST JEDI

            List<Jedi> jedis = businessManager.getJedis();

            //Test ajout jedi
            jedis.Add(new Jedi("Michel", false, cj));

            //Test suppression Jedi
            jedis.Remove(jedis[1]);
            //Test update Jedi
            jedis[2].Nom = "Stan Smith";
            //Test suppression Caract
            jedis[2].Caracteristiques.Remove(jedis[2].Caracteristiques[0]);
            //Test ajout Caract
            jedis[2].Caracteristiques.Add(cj[0]);
            //Test update Caract
            jedis[2].Caracteristiques[1].Nom = "TEST JEDI 3";

            businessManager.updateJedi(jedis);

            //  TEST STADES

            List<Stade> stades = businessManager.getStades();
            //Test ajout stade
            stades.Add(new Stade(300, "Jakku", cs));

            //Test suppression stade
            stades.Remove(stades[1]);
            //Test update stade
            stades[2].Planete = "Ta maman";
            //Test suppression Caract
            stades[2].Caracteristiques.Remove(jedis[2].Caracteristiques[0]);
            //Test ajout Caract
            stades[2].Caracteristiques.Add(cs[0]);
            //Test update Caract
            stades[2].Caracteristiques[1].Nom = "TEST STADE 3";

            businessManager.updateStades(stades);

            //  TEST MATCH

            List<Match> matches = businessManager.getMatches();
            //Test ajout
            matches.Add(new Match(jedis[0], jedis[2], EPhaseTournoi.Finale, stades[0]));
            matches.Add(new Match(jedis[0], jedis[2], EPhaseTournoi.Finale, stades[0]));
            //Test suppression
            matches.Remove(matches[0]);
            //Test update
            matches[0].Jedi1 = jedis[1];

            businessManager.updateMatch(matches);



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
