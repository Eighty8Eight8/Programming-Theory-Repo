using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : EnemyScript
{
    public Rigidbody enemyOneRB;
    public override void FollowPlayer()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;

        enemyOneRB.AddForce(moveDirection * speed, ForceMode.Impulse);
        Debug.Log("Enemy 1");
    }
    private void Update()
    {
        FollowPlayer();
    }
}
