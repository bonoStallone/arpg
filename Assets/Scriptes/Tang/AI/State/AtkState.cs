using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkState : BaseState
{
    public override E_AI_State AIState => E_AI_State.Atk;

    //��һ�ι�����ʱ��
    private float nextAtkTime;

    //�´ι����ȴ���ʱ��
    private float waitTime = 2f;

    public AtkState(StateMachine machine):base(machine)
    {

    }

    public override void EnterState()
    {
        Debug.Log("���빥��״̬��");
        //���빥��״̬ʱ ��Ϊ��ʱ�˿̾�Ҫ����
        nextAtkTime = Time.time;
    }

    public override void QuitState()
    {
        
    }

    public override void UpdateState()
    {
        //����AI״̬�� ��ͣ����ai����ȥ��������
        if (Time.time >= nextAtkTime)
        {
            stateMachine.aiObj.Atk();
            nextAtkTime = Time.time + waitTime;
        }

        //���Ŀ����ҵľ����Զ�ˣ�����Ӧ��ȥ�л���׷��״̬ ��׷�����ټ�������
        if (Vector3.Distance(stateMachine.aiObj.nowPos, stateMachine.aiObj.targetObjPos) > stateMachine.aiObj.atkRange)
        {
            stateMachine.ChangeState(E_AI_State.Chase);
        }

        //���ǿ���������������Ԫ�����֪ʶ ��ai������Ŀ����� Ҳ���Լ򵥴ֱ�����LookAt
        //����������ֻ�Ǿ����� ��ʹ��LookAt����ԼһЩ�¼� ֮�� ��ҿ��Ը����Լ�������ȥ��������
        stateMachine.aiObj.objTransform.LookAt(stateMachine.aiObj.targetObjPos + Vector3.up * 0.5f);


        //��׷������� ���ֳ����� ���ǵ������� ��Ӧ���л����ع��״̬
        stateMachine.CheckChangeRun();
    }
}
