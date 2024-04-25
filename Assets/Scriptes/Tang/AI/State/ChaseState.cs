using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public override E_AI_State AIState => E_AI_State.Chase;

    //用于计数，隔几帧 前往目标点一次
    private int index;


    public ChaseState(StateMachine machine) : base(machine)
    {

    }

    public override void EnterState()
    {
        Debug.Log("进入追逐状态");
        index = 0;
    }

    public override void QuitState()
    {
        //离开追逐状态时 让ai对象停下来
        stateMachine.aiObj.StopMove();
    }

    public override void UpdateState()
    {
        //就可以通过管理者对象 得到控制的 ai对象 对它进行操作 即可
        //stateMachine.aiObj
        //追逐逻辑 就是让ai对象 不停的朝向我们的目标进行移动即可

        //不停的让ai对象 朝向目标移动即可
        if(index % 10 == 0)
            stateMachine.aiObj.Move(stateMachine.aiObj.targetObjPos);

        ++index;

        //需要注意：一般情况下 我们还需要处理 面朝向 朝向了目标后 再攻击
        //这里可以留给大家思考 应该怎么去判断面朝向相关的逻辑

        //当自己和目标位置小于了自己的攻击范围，那么我们就应该脱离 追逐状态
        //进入攻击状态
        if (Vector3.Distance(stateMachine.aiObj.nowPos, stateMachine.aiObj.targetObjPos) <= stateMachine.aiObj.atkRange)
        {
            stateMachine.ChangeState(E_AI_State.Atk);
        }

        //在追逐过程中 发现超出了 我们的最大距离 就应该切换到回归的状态
        stateMachine.CheckChangeRun();
    }
}
