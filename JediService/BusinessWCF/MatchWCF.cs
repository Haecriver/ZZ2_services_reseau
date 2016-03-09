using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class MatchWCF : EntityObjectWCF
    {
        private JediWCF jedi1;
        private JediWCF jedi2;
        private EPhaseTournoi phaseTournoi;
        private JediWCF jediVainqueur;
        private StadeWCF stade;

        public MatchWCF(Match match) : base(match)
        {
            this.jedi1 = new JediWCF(match.Jedi1);
            this.jedi2 = new JediWCF(match.Jedi2);
            if (match.JediVainqueur != null)
            {
                this.jediVainqueur = new JediWCF(match.JediVainqueur);
            }
            this.stade = new StadeWCF(match.Stade);
            this.phaseTournoi = match.PhaseTournoi;
        }
        
        [DataMember]
        public EPhaseTournoi PhaseTournoi
        {
            get { return phaseTournoi; }
            set { phaseTournoi = value; }
        }

        [DataMember]
        public JediWCF Jedi1
        {
            get { return jedi1; }
            set { jedi1 = value; }
        }

        [DataMember]
        public JediWCF Jedi2
        {
            get { return jedi2; }
            set { jedi2 = value; }
        }

        [DataMember]
        public JediWCF JediVainqueur
        {
            get { return jediVainqueur; }
            set { jediVainqueur = value; }
        }

        [DataMember]
        public StadeWCF Stade
        {
            get { return stade; }
            set { stade = value; }
        }

        public Match toMatch()
        {
            return new Match(Id, jedi1.toJedi(), Jedi2.toJedi(), phaseTournoi, stade.toStade());
        }
    }
}