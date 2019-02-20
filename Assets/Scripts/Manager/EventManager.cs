using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SA

{
    public class EventManager : MonoBehaviour
    {
        #region My Calls
        //Event of Dropping Card
        public void CardIsDroppedDown(int instId, int playerId )
        {
           Card c =  NetworkManager.singleton.GetCard(instId,playerId);

        }

        //Event of Drawing card from deck
        public void CardIsDrawnFromDeck(int instId, int playerId )
        {
            Card c = NetworkManager.singleton.GetCard(instId, playerId);
        }

        #endregion

    }

}