using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakeManager : MonoBehaviour
{
    #region Singleton
    public static CameraShakeManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Start()
    {
        cinemachineVirtualCamera = Camera.current.GetComponent<CinemachineVirtualCamera>();
        StopShake();
    }
    public void Shake(ScreenShakeProfile profile)
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = profile.ShakeIntensity;

        timer = profile.ShakeTime;
    }

    public void ShakeWithoutProfile(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = intensity;

        timer = time;
    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;

        timer = 0f;
    }
    public void SetNewCam(CinemachineVirtualCamera virtualCamera)
    {
        cinemachineVirtualCamera = virtualCamera;
        StopShake();
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                StopShake();
        }
    }
}
