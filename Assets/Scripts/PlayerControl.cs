using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRB; //ENCAPSULATION
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject enemyOne;
    private GameManager gameManager;

    bool isKeyPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
         MoveForward(); //ABSTRACTION
    }

    private void MoveForward() //user moves the ball forward or from side to side
    {   
        float speed = 3.0f;
        float horizontalInput =  Input.GetAxis("Horizontal");
        float verticalInput =  Input.GetAxis("Vertical");
        playerRB.AddForce(Vector3.right * horizontalInput * -speed, ForceMode.Impulse);
        playerRB.AddForce(Vector3.forward * verticalInput * -speed, ForceMode.Impulse);        
    }

    private void OnTriggerEnter(Collider other) // when an objects is picked up it turns into enemy in...seconds
    {
    	if (other.CompareTag("PickUp"))
    	{
            isKeyPicked = true;
    		Destroy(other.gameObject);
            StartCoroutine(EnemyCountdownRoutine());
    		enemy.gameObject.transform.position = other.transform.position; // changes enemy position to the position of an object
    	}
        if (other.CompareTag("PickUpOne"))
    	{
            isKeyPicked = true;
    		Destroy(other.gameObject);
            StartCoroutine(EnemyOneCountdownRoutine());
    		enemyOne.gameObject.transform.position = other.transform.position; // changes enemy position to the position of an object
    	}
    }
    IEnumerator EnemyCountdownRoutine()
    {
    	yield return new WaitForSeconds(1);
    	enemy.gameObject.SetActive(true); //sets enemy active in 1 second
    }
    IEnumerator EnemyOneCountdownRoutine()
    {
    	yield return new WaitForSeconds(1);
    	enemyOne.gameObject.SetActive(true); //sets enemy active in 1 second
    }

    private void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("EnemyOne"))
    	{
            gameManager.GameOver();
    	}
        if(collision.gameObject.CompareTag("EnemyOne"))
    	{
            gameManager.GameOver();
    	}

        if(collision.gameObject.CompareTag("Gates")&&isKeyPicked)
        {
            Debug.Log("You Won");
        }
    }
}
 