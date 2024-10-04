using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{

    private void FixedUpdate()
    {
        if (Player.instance == null)
            return;

        transform.position=Player.instance.transform.position;
    }
}
