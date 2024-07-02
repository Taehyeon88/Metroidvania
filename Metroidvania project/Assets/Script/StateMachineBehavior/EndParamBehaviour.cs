using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndParamBehaviour : StateMachineBehaviour
{
    public string parameter = "IsAttacking";

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //�ִϸ��̼��� ����ǰ� ��ȯ�Ǵ�  �������� ������ �ִϸ��̼� �Ķ���� ���� true --> false ��Ų��.
        animator.SetBool(parameter, false);
    }
}
