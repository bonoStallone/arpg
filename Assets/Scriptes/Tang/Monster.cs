using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour, IAIObj
{
    public GameObject bullet;

    //����Ѱ·���
    private NavMeshAgent navMeshAgent;

    //����Ҫʹ��AIģ��Ķ����� ����һ�� AI״̬������ ���ڿ���AI����
    private StateMachine aiStateMachine;

    private Vector3 nowObjPos;
    //����ǰ��λ��
    public Vector3 nowPos 
    {
        get
        {
            nowObjPos = this.transform.position;
            //Ϊ�˺�����AIģ��Ķ�λ������ͬ û�п��� Y�ϵ�λ�� ��Ҫ����xzƽ�����λ��
            nowObjPos.y = 0;
            return nowObjPos;
        }
    }

    //����λ��
    public Vector3 bornPos
    {
        get;
        set;
    }

    //AI��������ܹ���AIģ���ȡ��Transform �������ǽ�����ش���
    public Transform objTransform => this.transform;

    //�Լ��Ĺ�����Χ��Ŀǰ���ǿ���д�����Ժ� һ����ͨ�����ñ�������ݳ�ʼ��
    //����������������Լ�ʵ�ֶ�Ӧ�Ĺ�����Χ���򼴿ɣ�
    public float atkRange => 2;

    //���ڲ����õ�Ŀ�����
    //��������£�Ӧ��ͨ�����붯̬���ٳ�����Ѱ������������Ŀ�� ������������ǲ���
    //����ֱ��ͨ����ק���й���
    public Transform targetTransform;

    //�����������ڻ�����ȥ���� Ŀ�� ��������һ��Ŀ��λ��
    public Vector3 targetObjPos
    {
        get
        {
            //ע�⣺�����ȥy�����0.5 ����Ϊ����������������ӣ�����y��������0.5
            //Ϊ�����ϵ��� �������Ǽ�ȥ0.5
            return targetTransform.position - Vector3.up * 0.5f;
        }
    }

    private void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        //֮���԰�AI����Ҫ��ʼ�� �ŵ������൱�� ��Ҫԭ��
        //����Ϊ��ͬ���� ���ܻ���ڲ�ͬ��AI״̬����ͬ����ʼ״̬
        //��Щ��������Ϸ�� �������ñ������õ� ����һ��д�ڹ��ﴴ����

        //ע�⣺
        //���������� ����� ����������еĴ�������ķ����У���������Ŀǰû����ƹ��������
        //��ˣ����ǰ���һ����� ������ ����������������ں����� Ҳ����Start�У�Ҳ���Է���Awake)

        //��ʼ��AIģ�������״̬������
        aiStateMachine = new StateMachine();
        //��ai�����Լ� �������н��г�ʼ��
        aiStateMachine.Init(this);

        //����ҪʲôAI״̬ �Ͷ�̬��ӣ��Ժ�һ������� ��ͨ�����ñ������ȥ��ӣ�
        //ΪAI���Ѳ��״̬
        aiStateMachine.AddState(E_AI_State.Patrol);
        aiStateMachine.AddState(E_AI_State.Chase);
        aiStateMachine.AddState(E_AI_State.Atk);
        aiStateMachine.AddState(E_AI_State.Run);

        //��ʼ��������AI״̬�� �Ǿ���Ҫһ����ǰ��AI״̬
        //Ŀǰһ��ʼ���ö���ʱһ��Ѳ��״̬
        aiStateMachine.ChangeState(E_AI_State.Patrol);

        //����λ�� ���Ƕ���һ��ʼ���ڵ�λ��
        bornPos = this.transform.position;
    }

    private void Update()
    {
        //ai��صĸ��� ���� ai����� ֡���º��� ����� 
        aiStateMachine.UpdateState();
    }


    public void Atk()
    {
        //��ʱ��д ֮��д������AIʱ ��ȥд��
        print("����");

        //��̬�����Զ� ���伴��
        GameObject obj = Instantiate(bullet, this.transform.position + this.transform.forward + Vector3.up * 0.5f, this.transform.rotation);
        Destroy(obj, 5f);
    }

    public void ChangeAction(E_Action action)
    {
        print(action);
    }

    public void Move(Vector3 dirOrPos)
    {
        //����ֹͣ�ƶ�
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(dirOrPos);
    }

    public void StopMove()
    {
        //�÷�����ʱ��
        //navMeshAgent.Stop();
        //ֹͣ�ƶ�
        navMeshAgent.isStopped = true;
    }
}
