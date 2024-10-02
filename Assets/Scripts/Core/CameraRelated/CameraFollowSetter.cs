using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSetter : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<CinemachineVirtualCamera>().Follow = Player.instance.follower.transform;
    }
}
