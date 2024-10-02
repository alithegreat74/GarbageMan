using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{

    private void FixedUpdate()
    {
        transform.position=Player.instance.transform.position;
    }
}
