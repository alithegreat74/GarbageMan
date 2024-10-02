using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    protected void TriggerAnimation()
    {
        Debug.Log("trigger called");

        player.statemachine.currentState.TriggerAnimation();
    }


    private void Attack()
    {
        Vector2 input = InputHandling.InputHandler.move.GetValue();

        Collider[] colldiers;

        if (input == Vector2.zero)
            colldiers = Physics.OverlapSphere
                (new Vector3(player.transform.position.x + player.attackDistance * player.facingRight, player.transform.position.y, player.transform.position.z), player.attackRange);
        else
            colldiers = Physics.OverlapSphere
                (new Vector3(player.transform.position.x + player.attackDistance * input.x, player.transform.position.y, player.transform.position.z + player.attackDistance * input.y), player.attackRange);

        foreach (Collider collider in colldiers)
        {
            if (collider.gameObject.layer != LayerMask.NameToLayer("Enemy"))
                continue;

            var stats = collider.GetComponent<Stats>();
            stats.TakeDamage(player.stats);
        }
    }

}
