using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    int randTarget;
    public GameObject OrbitTarget;
    
    // Start is called before the first frame update

    float posX1 = 0.0f; 
    float posX2 = 0.0f;

    //Sets the Movement Speed for the Platform
    public float movespeed = 4.0f;
    //Boolean for Movement Direction
    bool moveRight = true;


    void Start()
    {
       randTarget = Random.Range(1,3);
        posX1 = transform.position.x;
        posX2 = transform.position.x+30;
        //transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (randTarget)
        {
            case 1:
                //moveHorizontal();
                //moveOrbit();
                break;
            case 2:
                ///moveOrbit();
                //moveVertical();
                break;
            default:
                //moveOrbit();
                break;
        }
    }

    private void moveOrbit()
    {   
        transform.RotateAround(OrbitTarget.transform.position, Vector3.left, 20 * Time.deltaTime);
    }
   

    private void moveVerticla()
    {
        throw new System.NotImplementedException();
    }

    private void moveHorizontal()
    {
        throw new System.NotImplementedException();
    }
}
