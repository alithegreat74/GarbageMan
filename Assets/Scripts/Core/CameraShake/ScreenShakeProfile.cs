using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScreenShake Profile/New Profile")]
public class ScreenShakeProfile : ScriptableObject
{
    public float ShakeIntensity = 1f;
    public float ShakeTime = 0.2f;
}
