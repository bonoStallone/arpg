using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public override E_AI_State AIState => E_AI_State.Chase;

    //���ڼ���������֡ ǰ��Ŀ���һ��
    private int index;


    public ChaseState(StateMachine machine) : base(machine)
    {

    }

    public override void EnterState()
    {
        Debug.Log("����׷��״̬");
        index = 0;
    }

    public override void QuitState()
    {
        //�뿪׷��״̬ʱ ��ai����ͣ����
        stateMachine.aiObj.StopMove();
    }

    public override void UpdateState()
    {
        //�Ϳ���ͨ�������߶��� �õ����Ƶ� ai���� �������в��� ����
        //stateMachine.aiObj
        //׷���߼� ������ai���� ��ͣ�ĳ������ǵ�Ŀ������ƶ�����

        //��ͣ����ai���� ����Ŀ���ƶ�����
        if(index % 10 == 0)
            stateMachine.aiObj.Move(stateMachine.aiObj.targetObjPos);

        ++index;

        //��Ҫע�⣺һ������� ���ǻ���Ҫ���� �泯�� ������Ŀ��� �ٹ���
        //��������������˼�� Ӧ����ôȥ�ж��泯����ص��߼�

        //���Լ���Ŀ��λ��С�����Լ��Ĺ�����Χ����ô���Ǿ�Ӧ������ ׷��״̬
        //���빥��״̬
        if (Vector3.Distance(stateMachine.aiObj.nowPos, stateMachine.aiObj.targetObjPos) <= stateMachine.aiObj.atkRange)
        {
            stateMachine.ChangeState(E_AI_State.Atk);
        }

        //��׷������� ���ֳ����� ���ǵ������� ��Ӧ���л����ع��״̬
        stateMachine.CheckChangeRun();
    }
}
