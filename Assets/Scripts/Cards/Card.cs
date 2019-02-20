using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Making Card Object for the Game

namespace SA

{
    [CreateAssetMenu(menuName = "Card")]
    public class Card : ScriptableObject
    {
        public string cardName; // Card Name Place Holder
        public Sprite art; //Art Sprite in the Scene
        public string cardDetails; //Card Effects
        public string cardFlavour; //Card Details
        public string source; // Crediting the source of the card art
        [System.NonSerialized]
        public int instId;
    }
}