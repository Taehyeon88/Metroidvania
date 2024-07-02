using UnityEngine;

public class Timer
{
    private float duration;              //���۽ð�
    private float remainingTimer;        //�����ð�
    private bool isRunning;              //���������� �Ǵ�

    public Timer(float duration)         //Ŭ���� ������ [Ŭ������ ������� �� �ʱ�ȭ]
    {
        this.duration = duration;
        this.remainingTimer = duration;
        this.isRunning = false;
    }

    public void Start()                     //��ŸƮ �����ֱ⿡�� ����Ҷ� ���� ���� ���ִ� �Լ�
    {
        this.remainingTimer = duration;
        this.isRunning = true;
    }

    public void Update(float deltaTime)      //Uptate �Լ����� DeltaTime�� �޾ƿ´�
    {
        if (isRunning)                       //�������̸�
        {
            remainingTimer -= deltaTime;     //�޾ƿ� DeltaTime�� ���ҽ�Ų��
            if (remainingTimer <= 0)         //�ð��� 
            {
                isRunning = false;            //���� ����
                remainingTimer = 0;           //���� �ð� 0
            }
        }
    }

    public bool IsRunning()                 //������ Ȯ�� �Լ�
    {
        return isRunning;                   //���� ���� ����
    }

    public float GetRemainingTime()         //�����ִ� �ð� �Լ�Ȯ��
    {
        return remainingTimer;              //�ð� ���� ����
    }
    public void Reset()                     //�ʱ�ȭ �����ִ� �Լ�
    {
        this.remainingTimer = duration;
        this.isRunning = false;
    }
}
