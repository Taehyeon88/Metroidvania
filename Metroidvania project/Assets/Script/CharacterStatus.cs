using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    //====================================================================================================
    //생성값 설정
    //====================================================================================================

    public int hp = 10;                        //플레이어 생명
    public bool invincible = false;            //무적 상태
    public bool canMove = true;                //이동가능 상태
    public bool isDashing = false;             //대시 상태
    public bool canDash = true;                //대시 가능 상태 여부
    public float mDashForce = 25f;             //대시 힘의 량, 변수앞의 M은 내부에서 쓰기 위해서

    //====================================================================================================
    //타이머 생성값
    //====================================================================================================

    public Timer stunTimer = new Timer(0.25f);             //스턴타이머 0.25초 /  생성자를 불러올 때는 new를 붙여준다.
    public Timer invincibilityTimer = new Timer(1f);       //무적타이머 1초
    public Timer moveTimer = new Timer(0f);
    public Timer checkTimer = new Timer(0f);
    public Timer endSlidingTimer = new Timer(0f);
    public Timer deadTimer = new Timer(1.5f);
    public Timer dashCooldownTimer = new Timer(0.6f);
    void Start()
    {

    }

    void Update()
    {
        //====================================================================================================
        //타이머 업데이트
        //====================================================================================================

        float deltaTime = Time.deltaTime;
        stunTimer.Update(deltaTime);
        invincibilityTimer.Update(deltaTime);
        moveTimer.Update(deltaTime);
        checkTimer.Update(deltaTime);
        endSlidingTimer.Update(deltaTime);
        deadTimer.Update(deltaTime);
        dashCooldownTimer.Update(deltaTime);

        //====================================================================================================
        //타이머 상태체크
        //====================================================================================================

        if (!stunTimer.IsRunning())                           //스턴 타이머 동작 체크
        {
            canMove = true;
        }

        if (!invincibilityTimer.IsRunning())                   //무적 타이머 동작 체크
        {
            invincible = false;
        }

        if (!moveTimer.IsRunning())                            //이동 타이머 동작 체크
        {
            canMove = true;
        }

        if (isDashing && !dashCooldownTimer.IsRunning())        //대사 타이머 동작 체크
        {
            isDashing = false;
            canMove = true;
            canDash = true;
        }
        if (deadTimer.GetRemainingTime() <= 0)                  //죽음 이후 처리
        {
            //씬 처리 등등 해준다.
        }
    }

    public void StartDash(float dashDuration)
    {
        //animator.SetBool("IsDashing", true);
        isDashing = true;
        canMove = false;
        canDash = false;
        dashCooldownTimer = new Timer(dashDuration);              //새로운 타이머설정
        dashCooldownTimer.Start();
    }

    public void ApplyDamage(int damage, Vector3 position)         //데미지를 받을 때 잠시 무적시간을 주고 스턴처리
    {
        if (!invincible)
        {
            //animator.SetBool("Hit", true);
            hp -= damage;

            if (hp <= 0)
            {
                deadTimer.Start();
            }
            else
            {
                stunTimer.Start();
                invincibilityTimer.Start();
            }
        }
    }
}
