using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class BattleResolve : Phase
    {
        public Element attackElement;
        public Element defenseElement;

        public override bool IsComplete()
        {            
            if (forceExit)
            {
                forceExit = false;
                return true;
            }
            return false;
        }

        public override void OnEndPhase()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStartPhase()
        {            
            PlayerHolder p = Settings.gameManager.currentPlayer;
            if(p.attackingCards.Count == 0)
            {
                forceExit = true;
                return;

            }
            for(int i = 0; i < p.attackingCards.Count; i++)
            {
                CardInstance inst = p.attackingCards[i];
                Card c = inst.viz.cards;
                CardProperties attack = c.GetProperty(attackElement);
                if(attack == null)
                {
                    Debug.LogError("This card cannot be attacked!");
                    continue;
                }
                //in Card.cs - line 14 add :
                //public CardProperties GetProperty(Element e){
                // for(int i = 0; i < properties.Length; i++){
                // { if(properties[i].element == e){
                //    return properties[i];
                //    } return null;
                //}

            }
        }
    }
}

