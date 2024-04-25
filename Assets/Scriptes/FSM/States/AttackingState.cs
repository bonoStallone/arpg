using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 攻击状态类
    /// </summary>
    public class AttackingState : FSMState
    {
        protected override void Init()
        {
            StateID = FSMStateID.Attacking;
        }

        public override void EnterState(BaseFSM fsm)
        {
            base.EnterState(fsm);
            fsm.anim.SetBool(fsm.chStatus.animParams.attack,true);
        }

        public override void Action(BaseFSM fsm)
        {
            base.Action(fsm);

            AnimatorStateInfo aniS = fsm.anim.GetCurrentAnimatorStateInfo(0);

            if (aniS.IsName(fsm.chStatus.animParams.idle))
            {
                fsm.anim.SetBool(fsm.chStatus.animParams.attack, true);
            }
        }


        public override void ExitState(BaseFSM fsm)
        {
            base.ExitState(fsm);
            fsm.anim.SetBool(fsm.chStatus.animParams.attack, false);
        }
    }
}