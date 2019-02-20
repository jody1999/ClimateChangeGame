using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    public class NetworkManager : MonoBehaviour
    {
        public bool isMaster; // No need to check --> 1 v 1


        public static NetworkManager singleton;

        List<MultiplayerHolder> multiplayerHolders = new List<MultiplayerHolder>();
        public MultiplayerHolder GetHolder(int photonId)

        {
            for (int i = 0; i < multiplayerHolders.Count; i++)
            {
                if (multiplayerHolders[i].ownerId == photonId)
                {
                    return multiplayerHolders[i];
                }
            }
            return null;

        }

        public Card GetCard(int instId, int ownerId)
        {
            MultiplayerHolder h = GetHolder(ownerId);
            return h.GetCard(instId);
        }

        ResourcesManager rm;

        int cardInstanceIDs;

        private void Awake()
        {
            if (singleton == null)
            {
                rm = Resources.Load("ResourceManager") as ResourcesManager;
                singleton = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else { Destroy(this.gameObject); }
        }

        #region My Calls
        //Master Only
        public void PlayerJoined(int photonId, string [] cards)
        {
            MultiplayerHolder m = new MultiplayerHolder();
            m.ownerId = photonId;
            for (int i = 0; i < cards.Length-1; i++)
            {
                Card c = CreateCardMaster(cards[i]);
                if (c == null) { continue; }
                m.RegisterCard(c);
                //RPC into client
            }
    

        }
        Card CreateCardMaster(string cardId) //Creating card after drawing
        {
            Card card = rm.GetCardInstance(cardId);
            card.instId = cardInstanceIDs;
            cardInstanceIDs++;
            return card;
        }
        Card CreateCardClient(string cardId, int instId) //each card client is recorded depending on the carditself.
        {
            Card card = rm.GetCardInstance(cardId);
            card.instId = instId;
            return card;

        }

        void CreateCardClient_call(string cardId, int instId, int photonId)
        {
            Card c = CreateCardClient(cardId, instId);
            if (c != null)

            {
                MultiplayerHolder h = GetHolder(photonId);
                h.RegisterCard(c);

            }
        }


        #endregion

        //Calling Player ID
        #region PhotonCallbacks 
        #endregion


        #region RPCs
        #endregion
    }



    public class MultiplayerHolder
    {
        public int ownerId;
        Dictionary < int, Card> cards = new Dictionary<int, Card>();
        public void RegisterCard(Card c) //onwer of cards
        {
            cards.Add(c.instId, c);

        }

        public Card GetCard(int instId) //Cards available on the field
        {
            Card r = null;
            cards.TryGetValue(instId, out r);
            return r;
            
        }
    }
     
}