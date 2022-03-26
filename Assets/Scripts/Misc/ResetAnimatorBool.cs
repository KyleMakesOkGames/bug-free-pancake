using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimatorBool : StateMachineBehaviour
{
    public string isUsingRightHand;
    public bool isUsingRightHandStatus = false;

    public string isUsingLeftHand;
    public bool isUsingLeftHandStatus = false;

    public string isInteractingBool = "isInteracting";
    public bool isInteractingStatus = false;

    public string isRotatingWithRootMotion = "isRotatingWithRootMotion";
    public bool isRotatingWithRootMotionStatus= false;

    public string canRotateBool = "canRotate";
    public bool canRotateStatus = true;

    public string isMirroredBool = "isMirrored";
    public bool isMirroredStatus = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(isInteractingBool, isInteractingStatus);
        animator.SetBool(isRotatingWithRootMotion, isRotatingWithRootMotionStatus);
        animator.SetBool(canRotateBool, canRotateStatus);
        animator.SetBool(isUsingRightHand, isUsingRightHandStatus);
        animator.SetBool(isUsingLeftHand, isUsingLeftHandStatus);
        animator.SetBool(isMirroredBool, isMirroredStatus);
    }
}