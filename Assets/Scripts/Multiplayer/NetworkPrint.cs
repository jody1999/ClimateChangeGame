using System.Collections;
using System.Collections.Generic;
using UnityEngine;





namespace SA
{

    public class NetworkPrint : Photon.MonoBehaviour
    {
        public int photonId;
        public bool isLocal;

        public string[] GetStartingCardIds()
        {
            return cardIds;
        }

        string[] cardIds;

        void onPhotonInstantiate(PhotonMessageInfo info)
        {
            photonId = photonView.ownerId;
            isLocal = photonView.isMine;
            object[] data = photonView.instantiationData;

            cardIds = (string[])data[0];


            MultiplayerManager.singleton.AddPlayer(this);
        }
    }
}
