using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ع�״̬����
/// </summary>
public class RunState : BaseState
{
    public override E_AI_State AIState => E_AI_State.Run;

    public RunState(StateMachine machine) : base(machine)
    {

    }

    public override void EnterState()
    {
        Debug.Log("����ع�״̬");
        //����ع�״̬ʱ ����ai���� �ص��Լ��ĳ����㼴��
        stateMachine.aiObj.Move(stateMachine.aiObj.bornPos);
    }

    public override void QuitState()
    {

    }

    public override void UpdateState()
    {
        //�ж��Ƿ�ص��˳�����
        //���������� ���뵽 Ѳ��״̬����
        if(Vector3.Distance(stateMachine.aiObj.nowPos, stateMachine.aiObj.bornPos) <= 0.5f)
        {
            stateMachine.ChangeState(E_AI_State.Patrol);
        }
    }
}
