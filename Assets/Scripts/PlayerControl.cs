using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody playerRB;
    public GameObject enemy;
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
         MoveForward();
    }

    public void MoveForward() //user moves the ball forward or from side to side
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
            StartCoroutine(PowerUpCountdownRoutine());
    		enemy.gameObject.transform.position = other.transform.position; // changes enemy position to the position of an object
    	}
    }
    IEnumerator PowerUpCountdownRoutine()
    {
    	yield return new WaitForSeconds(1);
    	enemy.gameObject.SetActive(true); //sets enemy active in 1 second
    }

    private void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.CompareTag("Enemy"))
    	{
            gameManager.GameOver();
    	}

        if(collision.gameObject.CompareTag("Gates")&&isKeyPicked)
        {
            Debug.Log("You Won");
        }
    }
}
 