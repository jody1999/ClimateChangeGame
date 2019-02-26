using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    [CreateAssetMenu(menuName ="Turns/Battle Phase Player")]
    public class BattlePhase : Phase
    {
        public override bool IsComplete()
        {
            if (forceExit)
            {
                forceExit = false;
                return true;
            }
            return false;
        }

        protected bool isInit;

        public override void OnStartPhase()
        {

        }
        public override void OnEndPhase()
        {

        }
    }
}
