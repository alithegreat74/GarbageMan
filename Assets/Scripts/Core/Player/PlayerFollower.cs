using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{

    private void LateUpdate()
    {
        transform.position=Player.instance.transform.position;
    }
}
