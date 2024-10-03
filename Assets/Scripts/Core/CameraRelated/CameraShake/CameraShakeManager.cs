using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace CameraRelated
{
    public class CameraShakeManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _currentCameraRef;
        private static CinemachineVirtualCamera _currentCamera;

        private static float _timer;
        private static CinemachineBasicMultiChannelPerlin _cbmcp;

        private void Start()
        {
            _currentCamera = _currentCameraRef;
            StopShake();
        }

        public static void ShakeWithoutProfile(float intensity, float time)
        {
            _cbmcp = _currentCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _cbmcp.m_AmplitudeGain = intensity;
            _timer = time;
        }

        private void StopShake()
        {
            CinemachineBasicMultiChannelPerlin _cbmcp = _currentCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            _cbmcp.m_AmplitudeGain = 0f;
            _timer = 0f;
        }

        private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0)
                    StopShake();
            }
        }
    }

}