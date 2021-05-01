/*This Code is for Lesson 2
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballControl : MonoBehaviour
{
    //Speed Control Variable
    public float speed = 15f;

    //Create a Variable  to Countdown for the life of the Object
    public float countTimer = 5f;

    //Create a Variable  for Rigidbody 
    Rigidbody bullet_Rigidbody;

    //Create a Variable  for Rigidbody 
    Rigidbody cone_Rigidbody;

    //The Layer of all the Objects that can Be Hit by Paintball
    public LayerMask canBeHit;

    //Prefab GameObject of the Paintball Splatter 
    public GameObject Splatter_Prefab;

    //Create a Variable  for Renderer
    Renderer paintballRend;
    Renderer splatterRend;

    //Create Color Variable 
    private Color randColor;

    //Create Scale Variable 
    private float randScale;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the connections to the Rigidbody
        bullet_Rigidbody = GetComponent<Rigidbody>();

        //Applys Instanct Onetime Force to the Object Once using Impulse 
        bullet_Rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);

        //Gets the connections to the Paintball's Renderer
        paintballRend = GetComponent<Renderer>();

        //Generate Random Color Vaule
        randColor = RandomColor();

        //Generate Random Scale Vaule
        randScale = RandomScale();

        //Set Paintball to the Random Color
        paintballRend.material.color = randColor;
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
    private void FixedUpdate()
    {
        toHit();
    }

    void toHit()
    {
        //Creates a RaycastHit Check to dectect if we Hit an Object
        //A variable to hold the information returned from our ray
        RaycastHit checkHit = new RaycastHit();

        //Draws the Raycast in Sence view 
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.1f, Color.red);

        //Check the Raycast intersects any objects in the canBeHit Layer
        if (Physics.Raycast(transform.position, transform.forward, out checkHit, 1f, canBeHit))
        {
            //Check it Fit
            Debug.Log("Hit :");

            //Creates a Splatter Object at location of Hit (Y+0.001f)
            GameObject Paintball_Splatter = Instantiate(Splatter_Prefab, checkHit.point + 
            checkHit.normal * 0.001f, Quaternion.identity) as GameObject;
            
            //Rotates Splatter Object to normal(Face) of the Object Hit
            Paintball_Splatter.transform.LookAt(checkHit.point + checkHit.normal);

            //Set Random Scale to Splatter
            Paintball_Splatter.transform.localScale = new Vector3(randScale, randScale, randScale);

            //Gets the connections to the Paintball's Renderer
            splatterRend = Paintball_Splatter.GetComponentInChildren<Renderer>();
            Debug.Log(randColor);
            splatterRend.material.SetColor("_Color", randColor);

            //Change Parent to the Object Hit
            Paintball_Splatter.transform.parent = checkHit.transform;

            //Check if Hit Target 
            if (checkHit.collider.tag == "Target") 
            {
                hitTarget(checkHit,Paintball_Splatter);
            }

            //Check if Hit Cone 
            if (checkHit.collider.tag == "Cone") 
            {
                
            }

            hitTarget(checkHit);

            //Destroyes the Paintball
            Destroy(gameObject);
        }
    }

    private Color RandomColor()
    {
        // A different random value is used for each color component (if
        // the same is used for R, G and B, a shade of grey is produced).
        Color tempColor = new Color( 
            Random.Range(0f, 1.0f),
            Random.Range(0f, 1.0f),
            Random.Range(0f, 1.0f),
            1.0f
        );
        return tempColor;
    }

    private float RandomScale()
    {
        float scaleXY = Random.Range(0.1f, 0.9f);

        //Splatter.transform.localScale = new Vector3(scaleXY, 1, scaleXY);
        return scaleXY;
    }

    private void hitTarget(RaycastHit checkHit, GameObject Paintball_Splatter){
        
        //Create Important Variables
        float distance;
        float scaleHit;
        int score;
        
        //Get the Distance of Hit Point from Center of Target
        distance = Vector2.Distance(Paintball_Splatter.transform.localPosition, new Vector2(0.0f, 0.0f)) * 100.0f;
        
        //Get the Scale of the Object
        scaleHit = checkHit.transform.localScale.x;

        //Calulate Score
        score = (23 - Mathf.RoundToInt(distance));

        //Round Score to a Whole Number
        score = Mathf.RoundToInt((score / scaleHit));

        if(score < 0)
        {
            score = score * -1;
        }
        
        //Send the Score to the Player's Score Variable
        PlayerPaintballControl.score = PlayerPaintballControl.score + score;
        //Debug.Log("score :" + score);
    }

    private void hitTarget(RaycastHit checkHit){
        //Gets the connections to the Rigidbody
        cone_Rigidbody = checkHit.rigidbody;

        //Applys Instanct Onetime Force to the Object Once using Impulse 
        cone_Rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
