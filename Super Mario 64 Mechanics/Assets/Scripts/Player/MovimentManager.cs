using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterMovimentState{
    onGround,
    inJump,
    isFalling
}

public class MovimentManager : MonoBehaviour{
    [Header("Player Manager")]
    [SerializeField] PlayerManager playerManager;

    [Header("Gravity Variables")]
    [SerializeField] float groundedGravityForce = -.5f;
    [SerializeField] float normalGravityForce = -9.8f;
    [SerializeField] float maxGravityForce = 100;
    [SerializeField] float minGravityForce = -100;
    [SerializeField] Vector3 gravityForce;

    [Header("Moviment Variables")]
    [SerializeField] CharacterMovimentState characterState;
    [SerializeField] float movimentVelocity;
    [SerializeField] [Range(1, 50)] float rotationSpeed = 25;
    [SerializeField] Vector2 stickDirection;

    //JumpVariables
    [Header("Jump Variables")]
    [SerializeField] float maxJumpTime;
    [SerializeField] float maxJumpHeight;
    [SerializeField] bool inJump;

    [SerializeField] float timeToApex;
    float jumpGravity;
    [SerializeField]float iniJumpVelocity;

    void Awake(){
        SetJumpVariabeles();
    }

    void FixedUpdate(){
        SetJumpVariabeles();//debug
        SetCharacterState();
        GravityAplication();

        stickDirection = playerManager.GetInputManager().LeftStickPerforming();
        Vector3 finalDirection = RelativeToCamDirection(stickDirection);
        if (finalDirection != Vector3.zero) MeshRotation(finalDirection);

        finalDirection += gravityForce;

        playerManager.GetCharacterController().Move(finalDirection * movimentVelocity * Time.fixedDeltaTime);

        //aceleration = aceleration * (Vector3.one);
        //playerManager.GetRigidbody().MovePosition(transform.position + finalDirection * movimentVelocity * Time.deltaTime);
    }

    void SetJumpVariabeles() {
        timeToApex = maxJumpTime / 2;
        jumpGravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        iniJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void GravityAplication() {
        switch (characterState){
            case CharacterMovimentState.onGround:
                gravityForce.y = groundedGravityForce;
                break;
            case CharacterMovimentState.inJump:
                gravityForce.y += jumpGravity * Time.fixedDeltaTime;
                break;
            case CharacterMovimentState.isFalling:
                gravityForce.y += normalGravityForce * Time.fixedDeltaTime;
                break;
        }

        gravityForce.y = Mathf.Clamp(gravityForce.y, minGravityForce, maxGravityForce);
    }

    void SetCharacterState() {
        if (playerManager.GetCharacterController().isGrounded && !inJump)
            characterState = CharacterMovimentState.onGround;
        else if (inJump)
            characterState = CharacterMovimentState.inJump;
        else
            characterState = CharacterMovimentState.isFalling;
    }

    void MeshRotation(Vector3 direction) {
        Quaternion newRotation = Quaternion.LookRotation(direction.normalized, transform.up);
        playerManager.GetMeshObject().transform.rotation = Quaternion.Slerp(playerManager.GetMeshObject().transform.rotation, newRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    Vector3 RelativeToCamDirection(Vector2 stickDir) {
        Vector3 relativeToCamF = Vector3.ProjectOnPlane(Camera.main.transform.forward, transform.up);
        Vector3 relativeToCamR = Vector3.ProjectOnPlane(Camera.main.transform.right, transform.up);
        Vector3 finalRelativeToCam = relativeToCamF.normalized * stickDir.y + relativeToCamR.normalized * stickDir.x;
        return finalRelativeToCam;
    }

    public void Jump(){
        if (characterState == CharacterMovimentState.onGround){
            StartCoroutine("JumpBehaviour");
        }
    }

    IEnumerator JumpBehaviour() {
        inJump = true;
        gravityForce.y = iniJumpVelocity;
        yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() => playerManager.GetCharacterController().isGrounded);
        inJump = false;
    }

    public CharacterMovimentState ReturnCharacterMovimentState() {
        return characterState;
    }
}
