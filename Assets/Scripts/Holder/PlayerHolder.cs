using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Holders/Player Holder")]
    public class PlayerHolder : ScriptableObject {

        public string[] startingCards;
        //public SO.TransformVariable handGrind;
        //public SO.TransformVariable downGrind;

        //[System.NonSerialized]
        //public List<CardInstance> handCards = new List<CardInstance>();
        //[System.NonSerialized]
        //public List<CardInstance> cardsDown = new List<CardInstance>();
    }
}
