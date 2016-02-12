using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JediService.BusinessWCF
{
    [DataContract]
    public class MatchWCF
    {
        private Match match;
        public MatchWCF(Match match) {
            this.match = match;
        }
        
        [DataMember]
        public EPhaseTournoi PhaseTournoi
        {
            get { return match.PhaseTournoi; }
            set { match.PhaseTournoi = value; }
        }

        [DataMember]
        public JediWCF Jedi1
        {
            get { return new JediWCF(match.Jedi1); }
            set { match.Jedi1 = value.toJedi(); }
        }

        [DataMember]
        public JediWCF Jedi2
        {
            get { return new JediWCF(match.Jedi2); }
            set { match.Jedi2 = value.toJedi(); }
        }

        [DataMember]
        public JediWCF JediVainqueur
        {
            get { return new JediWCF(match.JediVainqueur); }
            set { match.JediVainqueur = value.toJedi(); }
        }

        [DataMember]
        public StadeWCF Stade
        {
            get { return new StadeWCF(match.Stade); }
            set { match.Stade = value.toStade(); }
        }
    }
}