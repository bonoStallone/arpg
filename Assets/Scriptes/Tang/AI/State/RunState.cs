using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 回归状态处理
/// </summary>
public class RunState : BaseState
{
    public override E_AI_State AIState => E_AI_State.Run;

    public RunState(StateMachine machine) : base(machine)
    {

    }

    public override void EnterState()
    {
        Debug.Log("进入回归状态");
        //进入回归状态时 命令ai对象 回到自己的出生点即可
        stateMachine.aiObj.Move(stateMachine.aiObj.bornPos);
    }

    public override void QuitState()
    {

    }

    public override void UpdateState()
    {
        //判断是否回到了出生点
        //到达出生点后 进入到 巡逻状态即可
        if(Vector3.Distance(stateMachine.aiObj.nowPos, stateMachine.aiObj.bornPos) <= 0.5f)
        {
            stateMachine.ChangeState(E_AI_State.Patrol);
        }
    }
}
