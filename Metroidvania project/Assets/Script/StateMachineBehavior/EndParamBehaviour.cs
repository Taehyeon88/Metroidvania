using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndParamBehaviour : StateMachineBehaviour
{
    public string parameter = "IsAttacking";

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //애니메이션이 종료되고 전환되는  시점에서 선언한 애니메이션 파라미터 값은 true --> false 시킨다.
        animator.SetBool(parameter, false);
    }
}
