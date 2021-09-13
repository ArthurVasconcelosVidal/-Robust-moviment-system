using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterMovimentState { 
    onGround,
    inJump,
    isFalling
}

public class MovimentManager : MonoBehaviour{
    [Header("Player Manager")]
    [SerializeField] PlayerManager playerManager;

    [Header("Gravity Variables")]
    [SerializeField] Vector3 groundedGravityForce = new Vector3(0,-.5f,0);
    [SerializeField] Vector3 normalGravityForce = new Vector3(0,-9.8f,0);
    [SerializeField] Vector3 jumpGravityForce = new Vector3(0,1,0);

    [Header("Moviment Variables")]
    [SerializeField] CharacterMovimentState characterState;
    [SerializeField] float movimentVelocity;
    [SerializeField] Vector2 stickDirection;

    //JumpVariables
    [Header("Jump Variables")]
    [SerializeField] float jumpHeight;
    [SerializeField] float timeToMaxHeight;

    //Verlet Integration
    [Header("Verlet Integration (DEBUG)")]
    [SerializeField] Vector3 aceleration;
    Vector3 oldPosition;
    [SerializeField] Vector3 currentPosition;

    void FixedUpdate(){

        GravityAplication();

        if (playerManager.GetInputManager().LeftStickPerforming(out stickDirection)){
            Vector3 finalDir = RelativeToCamDirection(stickDirection);
            MeshRotation(finalDir);
            aceleration += finalDir * (movimentVelocity / Time.fixedTime);
        }

        currentPosition += transform.position - oldPosition + aceleration * Time.fixedDeltaTime;
        oldPosition = currentPosition;

        playerManager.GetRigidbody().MovePosition(currentPosition);
    }

    void GravityAplication() {
        if (playerManager.IsGrounded()) {
            characterState = CharacterMovimentState.onGround;
            aceleration = groundedGravityForce;
        }
        else
            aceleration = normalGravityForce;
    }

    void MeshRotation(Vector3 direction) {
        playerManager.GetMeshObject().transform.rotation = Quaternion.LookRotation(direction.normalized, transform.up);
    }

    Vector3 RelativeToCamDirection(Vector2 stickDir) {
        Vector3 relativeToCamF = Vector3.ProjectOnPlane(Camera.main.transform.forward, transform.up);
        Vector3 relativeToCamR = Vector3.ProjectOnPlane(Camera.main.transform.right, transform.up);
        Vector3 finalRelativeToCam = relativeToCamF.normalized * stickDir.y + relativeToCamR.normalized * stickDir.x;
        return finalRelativeToCam;
    }

    public void Jump() {
        StartCoroutine("JumpBehaviour");
    }

    IEnumerator JumpBehaviour() {
        //DoSomething
        yield return new WaitUntil(() => playerManager.IsGrounded());
        //DoSomething
    }

    public CharacterMovimentState ReturnCharacterMovimentState() {
        return characterState;
    }
}
