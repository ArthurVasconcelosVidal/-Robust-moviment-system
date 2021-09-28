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
    Vector3 gravityForce;

    [Header("Moviment Variables")]
    [SerializeField] AnimationCurve movimentProgressionCurve; //Tempo deve descrever o tempo da progressão e o outro eixo ira descrever a evaluação dessa progressão 
    [SerializeField] float normalMovimentVelocity;
    [SerializeField] float runningMovimentVelocity;
    CharacterMovimentState characterState;
    bool isRunning;
    float movimentVelocity;
    float movimentProgression; 
    float movimentPercent;
    [SerializeField] [Range(0, 50)] float normalRotationSpeed = 25;
    float rotationSpeed = 25; 
    
    //JumpVariables
    [Header("Jump Variables")]
    [SerializeField] float timeToResetJump = 2;
    [SerializeField] [Range(0, 0.99f)] float toLastJumpMovVelocity;
    [SerializeField] float inJumpCharacterRotation = 2;
    int actualJump = 0; 
    float jumpGravity; 
    bool inJump = false; 
    bool toNextJump = false; 
    JumpForces[] jumpsList = new JumpForces[3];

    void Awake(){
        jumpsList[0] = new JumpForces(0.5f, 5); //Jump configuration
        jumpsList[1] = new JumpForces(0.7f, 7); //Jump configuration
        jumpsList[2] = new JumpForces(0.8f, 10); //Jump configuration
        
        rotationSpeed = normalRotationSpeed;
    }

    void FixedUpdate(){
        SetCharacterState();
        GravityAplication();

        IsRunning();

        Vector2 stickDirection = playerManager.GetInputManager().LeftStickPerforming();
        Vector3 finalDirection = RelativeToCamDirection(stickDirection);
        Vector3 moviment = Vector3.zero;

        if (finalDirection != Vector3.zero) { 
            MeshRotation(finalDirection);
            moviment = (playerManager.GetMeshObject().transform.forward * movimentVelocity) * movimentProgression;
        }

        movimentPercent = Mathf.InverseLerp(0, movimentVelocity, moviment.magnitude);
        if (!isRunning) playerManager.GetAnimationManager().SetMovimentVelocity(movimentPercent);
        else playerManager.GetAnimationManager().SetMovimentVelocity(movimentPercent * 2);

        moviment += gravityForce;

        playerManager.GetCharacterController().Move(moviment * Time.fixedDeltaTime);
    }

    /*
    void BlaBla(Vector3 oldDirection, Vector3 newDirection) {
        float angle = Vector3.Angle(oldMovimentDirection, newDirection);
        Debug.Log(angle);
    }*/

    public void StartMovimentProgression() {
        StopCoroutine("MovimentProgression");
        StartCoroutine("MovimentProgression");
    }

    IEnumerator MovimentProgression() {
        float maxTime = movimentProgressionCurve.keys[movimentProgressionCurve.length-1].time;
        float time = 0;
        movimentProgression = 0;
        while (time < maxTime){
            movimentProgression = movimentProgressionCurve.Evaluate(time);
            time += Time.fixedDeltaTime;
            yield return null;
        }
        yield return null;
    }

    void GravityAplication() {
        switch (characterState){
            case CharacterMovimentState.onGround:
                gravityForce.y = groundedGravityForce;
                playerManager.GetAnimationManager().SetOnGround();//Tirar daqui
                break;
            case CharacterMovimentState.inJump:
                float fallMultiplier = 1;
                if ( !playerManager.GetInputManager().IsActionButton() && gravityForce.y > 0)  fallMultiplier = 1.8f;
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

    void IsRunning() {
        isRunning = playerManager.GetInputManager().IsWestButton();
        if (isRunning && characterState == CharacterMovimentState.onGround){
            movimentVelocity = runningMovimentVelocity;
        }
        else if (characterState == CharacterMovimentState.onGround) {
            movimentVelocity = normalMovimentVelocity;
        }
    } 

    public void Jump(){
        if (characterState == CharacterMovimentState.onGround)
            StartCoroutine("JumpBehaviour");
    }

    IEnumerator JumpBehaviour() {
        inJump = true;
        actualJump = SetJump();

        jumpGravity = jumpsList[actualJump].jumpGravity;
        gravityForce.y = jumpsList[actualJump].iniJumpVelocity;
        rotationSpeed = inJumpCharacterRotation;
        playerManager.GetAnimationManager().SetJumpAnim(actualJump + 1);

        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => playerManager.GetCharacterController().isGrounded);

        rotationSpeed = normalRotationSpeed;

        inJump = false;
        toNextJump = true;
        StopCoroutine("ToNextJump");
        StartCoroutine("ToNextJump");
    }

    int SetJump(){
        if (actualJump < jumpsList.Length - 1 && toNextJump){
            if (actualJump == jumpsList.Length - 2 && movimentPercent < toLastJumpMovVelocity) actualJump = 0;
            else actualJump++;
        }
        else actualJump = 0;

        return actualJump;
    }

    IEnumerator ToNextJump() {
        yield return new WaitForSeconds(timeToResetJump);
        if (characterState != CharacterMovimentState.inJump)
            toNextJump = false;
    }

    public CharacterMovimentState GetCharacterMovimentState() {
        return characterState;
    }
}
