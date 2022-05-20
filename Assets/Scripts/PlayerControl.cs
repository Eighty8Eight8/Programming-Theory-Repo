using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
         MoveForward();
    }

    public void MoveForward()
    {   
        float speed = 3.0f;
        float horizontalInput =  Input.GetAxis("Horizontal");
        float verticalInput =  Input.GetAxis("Vertical");
        playerRB.AddForce(Vector3.right * horizontalInput * -speed, ForceMode.Impulse);
        playerRB.AddForce(Vector3.forward * verticalInput * -speed, ForceMode.Impulse);        
    }
}
 