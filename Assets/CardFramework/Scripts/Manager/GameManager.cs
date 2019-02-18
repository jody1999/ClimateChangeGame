using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class GameManager : MonoBehaviour
    {
        public PlayerHolder currentPlayer;
        public State currentState;
        public GameObject cardPrefab;

        private void Start()
        {
            Settings.gameManager = this;
            CreateStartingCards();
        }

        void CreateStartingCards()
        {
            ResourcesManager rm = Settings.GetResourceManager();

            for(int i = 0; i < currentPlayer.startingCards.Length; zi++)
            {
                GameObject go = Instantiate(cardPrefab) as GameObject;
                CardViz v = go.GetComponent<CardViz>();
                v.LoadCard(rm.GetCardInstance(currentPlayer.startingCards[i]));
                Settings.SetParentForCard(go.transform, currentPlayer.handGrid.value)
            }
        }

        private void Update()
        {
            currentState.Tick(Time.deltaTime);
        }
    }
}