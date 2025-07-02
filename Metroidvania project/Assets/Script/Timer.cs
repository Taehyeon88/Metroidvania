using UnityEngine;

public class Timer
{
    private float duration;              //동작시간
    private float remainingTimer;        //남은시간
    private bool isRunning;              //동작중인지 판단

    public Timer(float duration)         //클래스 생성자 [클래스가 만들어질 때 초기화]
    {
        this.duration = duration;
        this.remainingTimer = duration;
        this.isRunning = false;
    }

    public void Start()                     //스타트 생명주기에서 사용할때 동작 시작 해주는 함수
    {
        this.remainingTimer = duration;
        this.isRunning = true;
    }

    public void Update(float deltaTime)      //Uptate 함수에서 DeltaTime을 받아온다
    {
        if (isRunning)                       //동작중이면
        {
            remainingTimer -= deltaTime;     //받아온 DeltaTime을 감소시킨다
            if (remainingTimer <= 0)         //시간이 
            {
                isRunning = false;            //동작 중지
                remainingTimer = 0;           //남은 시간 0
            }
        }
    }

    public bool IsRunning()                 //동작중 확인 함수
    {
        return isRunning;                   //동작 상태 리턴
    }

    public float GetRemainingTime()         //남아있는 시간 함수확인
    {
        return remainingTimer;              //시간 상태 리턴
    }
    public void Reset()                     //초기화 시켜주는 함수
    {
        this.remainingTimer = duration;
        this.isRunning = false;
    }
}
