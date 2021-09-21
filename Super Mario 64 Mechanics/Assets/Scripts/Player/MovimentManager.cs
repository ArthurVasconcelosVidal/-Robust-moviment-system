using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterMovimentState{
    onGround,
    inJump,
    isFalling
}

struct JumpForces{
    public float maxJumpTime;
    public float maxJumpHeight;
    public float timeToApex; 
    public float jumpGravity; 
    public float iniJumpVelocity;

    public JumpForces(float maxJumpTime, float maxJumpHeight){
        this.maxJumpTime = maxJumpTime;
        this.maxJumpHeight = maxJumpHeight;
        timeToApex = maxJumpTime / 2;
        jumpGravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        iniJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }
}

public class MovimentManager : MonoBehaviour{
    [Header("Player Manager")]
    [SerializeField] PlayerManager playerManager;

    [Header("Gravity Variables")]
    [SerializeField] float groundedGravityForce = -.5f;
    [SerializeField] float normalGravityForce = -9.8f;
    [SerializeField] float maxGravityForce = 100;
    [SerializeField] float minGravityForce = -100;
    [SerializeField] Vector3 gravityForce; //Serialized for Debug

    [Header("Moviment Variables")]
    [SerializeField] CharacterMovimentState characterState; //Serialized for Debug
    [SerializeField] float movimentVelocity;
    [SerializeField] [Range(1, 50)] float rotationSpeed = 25;
    [SerializeField] Vector2 stickDirection; //Serialized for Debug

    //JumpVariables
    [Header("Jump Variables")]
    JumpForces firstJump = new JumpForces(0.5f, 5);
    JumpForces secondJump = new JumpForces(0.6f, 7);
    JumpForces thirdJump = new JumpForces(0.7f, 9);
    float jumpGravity;
    float fallMultiplier = 1;
    int jumpCount = 0;
    bool inJump = false;
    bool toNextJump = false;

    void FixedUpdate(){
        SetCharacterState();
        GravityAplication();

        stickDirection = playerManager.GetInputManager().LeftStickPerforming();
        Vector3 finalDirection = RelativeToCamDirection(stickDirection);
        if (finalDirection != Vector3.zero) MeshRotation(finalDirection);

        Vector3 moviment = finalDirection * movimentVelocity;
        moviment += gravityForce;

        playerManager.GetCharacterController().Move(moviment * Time.fixedDeltaTime);
    }

    void GravityAplication() {
        switch (characterState){
            case CharacterMovimentState.onGround:
                gravityForce.y = groundedGravityForce;
                break;
            case CharacterMovimentState.inJump:
                gravityForce.y += jumpGravity * fallMultiplier * Time.fixedDeltaTime;
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
        SetJump();

        switch (jumpCount){
            case 1:
                jumpGravity = firstJump.jumpGravity;
                gravityForce.y = firstJump.iniJumpVelocity;
                break;
            case 2:
                jumpGravity = secondJump.jumpGravity;
                gravityForce.y = secondJump.iniJumpVelocity;
                break;
            case 3:
                jumpGravity = thirdJump.jumpGravity;
                gravityForce.y = thirdJump.iniJumpVelocity;
                break;
        }

        yield return new WaitForSeconds(0.1f);
        //Diverssificador de gravidade 
        //Melhorar, atualmente o jogador precisa ficar segurando o botão por todo o pulo, deve haver um limite em tempo do botão pressionado para que o pulo seja maximo
        yield return new WaitUntil(() => playerManager.GetCharacterController().isGrounded);
        //Melhorar o sistema de condição, o terceiro pulo só pode acontecer se o personagem estiver se mexendo
        inJump = false;
        toNextJump = true;
        float timeToResetJump = 2;
        Invoke("ToNextJump", timeToResetJump);
    }

    void SetJump() {
        int totalJumps = 3;

        if (jumpCount < totalJumps && toNextJump)
            jumpCount++;
        else {
            jumpCount = 1;
            toNextJump = false;
        }
    }

    void ToNextJump() {
        if (characterState != CharacterMovimentState.inJump)
            toNextJump = false;
    }

    public CharacterMovimentState GetCharacterMovimentState() {
        return characterState;
    }
}
