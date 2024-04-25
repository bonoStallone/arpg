using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkState : BaseState
{
    public override E_AI_State AIState => E_AI_State.Atk;

    //下一次攻击的时间
    private float nextAtkTime;

    //下次攻击等待的时间
    private float waitTime = 2f;

    public AtkState(StateMachine machine):base(machine)
    {

    }

    public override void EnterState()
    {
        Debug.Log("进入攻击状态了");
        //进入攻击状态时 认为此时此刻就要攻击
        nextAtkTime = Time.time;
    }

    public override void QuitState()
    {
        
    }

    public override void UpdateState()
    {
        //进入AI状态后 不停的让ai对象去攻击即可
        if (Time.time >= nextAtkTime)
        {
            stateMachine.aiObj.Atk();
            nextAtkTime = Time.time + waitTime;
        }

        //如果目标和我的距离过远了，我们应该去切换到追逐状态 ，追到了再继续打它
        if (Vector3.Distance(stateMachine.aiObj.nowPos, stateMachine.aiObj.targetObjPos) > stateMachine.aiObj.atkRange)
        {
            stateMachine.ChangeState(E_AI_State.Chase);
        }

        //我们可以利用向量和四元数相关知识 让ai对象看向目标对象 也可以简单粗暴的用LookAt
        //我们在这里只是举例子 就使用LookAt来节约一些事件 之后 大家可以根据自己的需求去进行制作
        stateMachine.aiObj.objTransform.LookAt(stateMachine.aiObj.targetObjPos + Vector3.up * 0.5f);


        //在追逐过程中 发现超出了 我们的最大距离 就应该切换到回归的状态
        stateMachine.CheckChangeRun();
    }
}
