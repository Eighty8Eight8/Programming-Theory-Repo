using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INHERITANCE
public class EnemyOne : EnemyScript
{
    [SerializeField]
    private Rigidbody enemyOneRB;
    public override void FollowPlayer()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;

        enemyOneRB.AddForce(moveDirection * speed, ForceMode.Impulse);
        Debug.Log("Enemy 1"); //POLYMOPHISM
    }
    private void Update()
    {
        FollowPlayer();
    }
}
