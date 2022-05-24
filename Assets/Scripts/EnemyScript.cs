using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody enemyRB;
<<<<<<< Updated upstream
    private GameObject player;
=======
    public GameObject player;
    public float speed = 2.5f; 
>>>>>>> Stashed changes
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

    void ChangeIntoEnemy()
    {

    }
    void FollowPlayer()
    {
        float speed = 2.5f;
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;

        enemyRB.AddForce(moveDirection * speed, ForceMode.Impulse);
    }

    
}
