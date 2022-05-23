using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody enemyRB;
    public GameObject player;
    public float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public virtual void FollowPlayer()
    {
        
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;

        enemyRB.AddForce(moveDirection * speed, ForceMode.Impulse);
    }

    
}
