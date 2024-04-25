using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    ///Àë¿ª¹¥»÷¾àÀëÌõ¼þ
    /// </summary>
    public class AwayPlayerTrigger : FSMTrigger
    {
        public override bool HandleTrigger(BaseFSM fsm)
        {
            if (fsm.targetTF == null)
            {
                return false;
            }

            float dis = Vector3.Distance(fsm.transform.position, fsm.targetTF.position);
            if (dis > fsm.AttackDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void Init()
        {
            TriggerID = FSMTriggerID.AwayPlayer;
        }
    }
}