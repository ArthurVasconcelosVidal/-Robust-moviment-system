using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour{
    #region Cinemachine Camera
    [SerializeField] PlayerManager playerManager;
    [SerializeField] CinemachineFreeLook freeLookCM;
    [SerializeField] float camSpeedY = 1; //Default
    [SerializeField] float camSpeedX = 80; //Default
    #endregion

    void FixedUpdate(){
        CameraMoviment();
    }

    void CameraMoviment(){
        freeLookCM.m_XAxis.Value += playerManager.GetInputManager().RightStickPerforming().x * camSpeedX * Time.fixedDeltaTime;
        freeLookCM.m_YAxis.Value += playerManager.GetInputManager().RightStickPerforming().y * camSpeedY * Time.fixedDeltaTime;
    }
}
