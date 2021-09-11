using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentManager : MonoBehaviour{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float velocity;
    [SerializeField] Vector2 stickDir;

    void FixedUpdate(){
        if (playerManager.GetInputManager().LeftStickPerforming(out stickDir)){
            Vector3 finalDir = RelativeToCamDirection(stickDir);
            MeshRotation(finalDir);
            playerManager.GetRigidbody().MovePosition(transform.position + finalDir.normalized * velocity * Time.fixedDeltaTime);
        }
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
}
