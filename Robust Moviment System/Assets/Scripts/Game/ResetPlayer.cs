using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour{
    [SerializeField] GameObject player;
    [SerializeField] GameObject resetPoint;

    void OnTriggerEnter(Collider other){
        if (other.gameObject == player) {
            player.GetComponent<MovimentManager>().enabled = false;
            player.transform.position = resetPoint.transform.position;
            Invoke("SetMovimentTrue", 0.1f);
        }
    }

    void SetMovimentTrue() {
        player.GetComponent<MovimentManager>().enabled = true;
    }
}
