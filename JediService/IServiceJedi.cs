using JediService.BusinessWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace JediService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceJedi
    {

        [OperationContract]
        List<JediWCF> getAllJedi();

        [OperationContract]
        List<MatchWCF> getAllMatch();

        [OperationContract]
        List<StadeWCF> getAllStade();

        [OperationContract]
        List<TournoiWCF> getAllTournoi();

        [OperationContract]
        List<CaracteristiqueWCF> getAllCaracteristique();

        [OperationContract]
        void addJedi(JediWCF jedi);

        [OperationContract]
        void addMatch(MatchWCF match);

        [OperationContract]
        void addStade(StadeWCF stade);

        [OperationContract]
        void addTournoi(TournoiWCF tournoi);

        [OperationContract]
        void addCracteristique(CaracteristiqueWCF caract);

        [OperationContract]
        void deleteJedi(JediWCF jedi);

        [OperationContract]
        void deleteMatch(MatchWCF match);

        [OperationContract]
        void deleteStade(StadeWCF stade);

        [OperationContract]
        void deleteTournois(TournoiWCF tournoi);

        [OperationContract]
        void deleteCaracteristique(CaracteristiqueWCF caract);

        [OperationContract]
        void updateJedi(JediWCF jedi);

        [OperationContract]
        void updateMatch(MatchWCF match);

        [OperationContract]
        void updateStade(StadeWCF stade);

        [OperationContract]
        void updateTournois(TournoiWCF tournoi);

        [OperationContract]
        void updateCaracteristique(CaracteristiqueWCF caract);

        [OperationContract]
        TournoiWCF playTournoi(TournoiWCF tournoi);
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
}
