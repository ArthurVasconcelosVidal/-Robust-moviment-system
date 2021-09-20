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

    [Header("Moviment Variables")]
    [SerializeField] CharacterMovimentState characterState;
    [SerializeField] float movimentVelocity;
    [SerializeField] Vector2 stickDirection;

    //JumpVariables
    [Header("Jump Variables")]
    [SerializeField] float maxJumpTime;
    [SerializeField] float maxJumpHeight;
    [SerializeField] bool inJump;

    [SerializeField] float timeToApex;
    float jumpGravity;
    [SerializeField]float iniJumpVelocity;
    

    //Verlet Integration
    [Header("Verlet Integration (DEBUG)")]
    [SerializeField] Vector3 aceleration;
    Vector3 oldPosition;
    [SerializeField] Vector3 currentPosition;

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
        //aceleration = aceleration * (Vector3.one);

        playerManager.GetRigidbody().MovePosition(transform.position + finalDirection * movimentVelocity * Time.deltaTime);
    }

    void SetJumpVariabeles() {
        timeToApex = maxJumpTime / 2;
        jumpGravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        iniJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void GravityAplication() {
        switch (characterState){
            case CharacterMovimentState.onGround:
                aceleration.y = groundedGravityForce;
                break;
            case CharacterMovimentState.inJump:
                aceleration.y += jumpGravity * Time.fixedDeltaTime;
                break;
            case CharacterMovimentState.isFalling:
                aceleration.y += normalGravityForce * Time.fixedDeltaTime;
                break;
        }

        aceleration.y = Mathf.Clamp(aceleration.y, minGravityForce, maxGravityForce);
        playerManager.GetRigidbody().velocity = aceleration;
    }

    void SetCharacterState() {
        if (IsGrounded() && !inJump)
            characterState = CharacterMovimentState.onGround;
        else if (inJump)
            characterState = CharacterMovimentState.inJump;
        else
            characterState = CharacterMovimentState.isFalling;
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

    public void Jump(){
        if (characterState == CharacterMovimentState.onGround){
            StartCoroutine("JumpBehaviour");
        }
    }

    IEnumerator JumpBehaviour() {
        inJump = true;
        aceleration.y = iniJumpVelocity;
        yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() => IsGrounded());
        inJump = false;
    }

    public CharacterMovimentState ReturnCharacterMovimentState() {
        return characterState;
    }

    bool IsGrounded(){
        RaycastHit hitGround;
        if (Physics.Raycast(transform.position, -transform.up, out hitGround, playerManager.GetCollider().bounds.extents.y + 0.1f) && hitGround.transform.gameObject.tag.Contains("Ground"))
            return true;
        else
            return false;
    }
}
