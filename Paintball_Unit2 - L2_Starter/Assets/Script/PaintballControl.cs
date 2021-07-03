using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballControl : MonoBehaviour
{
    //Speed Control Variable
    public float speed = 15f;
    
    //Create a Varibable to Countdown for the life of the Object
    public float countTimer = 5f;

    //Create a Varibable for Rigidbody 
    Rigidbody bullet_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the connections to the Rigidbody
        bullet_Rigidbody = GetComponent<Rigidbody>();

        //Applys Instanct Onetime Force to the Object Once using Impulse 
        bullet_Rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //Subtract Seconds from Countdown Variable
        //Time.deltaTime is The interval in seconds from the last frame to the current one
        countTimer -= Time.deltaTime;

        //When Countdown Variable reaches Zero
        if (countTimer <= 0f)
        {
            //Destroy Object
            Destroy(gameObject);
        }
    }
    
}
