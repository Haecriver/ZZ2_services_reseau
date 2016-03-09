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
        void addJedi(JediWCF j);

        [OperationContract]
        void addMatch(MatchWCF j);

        [OperationContract]
        void addStade(StadeWCF j);

        [OperationContract]
        void addTournoi(TournoiWCF j);

        [OperationContract]
        void addCracteristique(CaracteristiqueWCF j);

        [OperationContract]
        void deleteJedi(JediWCF j);

        [OperationContract]
        void deleteMatch(MatchWCF j);

        [OperationContract]
        void deleteStade(StadeWCF j);

        [OperationContract]
        void deleteTournois(TournoiWCF j);

        [OperationContract]
        void deleteCaracteristique(CaracteristiqueWCF j);

        [OperationContract]
        void updateJedi(JediWCF j);

        [OperationContract]
        void updateMatch(MatchWCF j);

        [OperationContract]
        void updateStade(StadeWCF j);

        [OperationContract]
        void updateTournois(TournoiWCF j);

        [OperationContract]
        void updateCaracteristique(CaracteristiqueWCF j);
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
}
