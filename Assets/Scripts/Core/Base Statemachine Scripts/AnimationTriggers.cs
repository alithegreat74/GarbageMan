using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    public Entity entity=>GetComponentInParent<Entity>();


    private void TriggerAnimation()
    {
        entity.statemachine.currentState.TriggerAnimation();
    }
}
