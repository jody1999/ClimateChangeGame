using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SA
{
    public class NetworkManager : Photon.PunBehaviour
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


        public StringVariable logger; // Need Scriptable object library
        public GameEvent onConnected;
        public GameEvent failedToConnect;
        public GameEvent loggerUpdated;


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

        private void Start()
        {
            PhotonNetwork.autoCleanUpPlayerObjects = false;
            PhotonNetwork.autoJoinLobby = false;
            PhotonNetwork.automaticallySyncScene = false;
            Init();
            

        }

        public void Init()
        {
            PhotonNetwork.ConnectUsingSettings("1"); // Connect to the network
            logger.value = "Connecting"; // Logger
            loggerUpdated.Raise();
        }

        #region My Calls
        public void OnPlayGame()
        {
            JoinRandomRoom(); // JOIN  A RANDOM ROOM TO START PLAYING BY CALLING JoinRandomRoom method.

        }
        void JoinRandomRoom()

        {

            PhotonNetwork.JoinRandomRoom();
        }

        public void CreateRoom()
        {
            RoomOptions room = new RoomOptions();
            room.MaxPlayers = 2;
            PhotonNetwork.CreateRoom(RandomString(256 ), room, TypedLobby.Default);
        }
        private System.Random random = new System.Random();

        public string RandomString(int length)
        {
            const string chars = "";//Add random string here
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

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
                // Creating Starting Hand
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

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            logger.value = "Connected";
            loggerUpdated.Raise();
            onConnected.Raise();
        }
        public override void OnFailedToConnectToPhoton(DisconnectCause cause)
        {
            base.OnFailedToConnectToPhoton(cause);
            logger.value = "Failed to Connect";
            loggerUpdated.Raise();
            failedToConnect.Raise();
        }

        //Overriding the failed random join room.
        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            base.OnPhotonRandomJoinFailed(codeAndMsg);
            CreateRoom();
        }
        public override void OnCreatedRoom()
        {
            base.OnCreatedRoom();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
        }

        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
        }
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