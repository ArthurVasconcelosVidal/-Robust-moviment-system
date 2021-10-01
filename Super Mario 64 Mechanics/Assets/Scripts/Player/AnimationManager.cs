using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour{

    [SerializeField] Animator animator;


    public void SetJumpAnim(int jumpType) {
        animator.SetTrigger("Jump_" + jumpType);
    }

    public void SetOnGround() {
        animator.SetTrigger("OnGround");
    }

    public void SetMovimentVelocity(float movimentMagnitude) {
        animator.SetFloat("Velocity", movimentMagnitude);
    }

    public void RightTurnAnimation() {
        animator.SetTrigger("RightTurn");
    }
    public void LeftTurnAnimation() {
        animator.SetTrigger("LeftTurn");
    }
    public void HalfTurnAnimation() {
        animator.SetTrigger("Turn180");
    }
    public void onWallAnimation(bool state) {
        animator.SetBool("InWall", state);
    }
}
