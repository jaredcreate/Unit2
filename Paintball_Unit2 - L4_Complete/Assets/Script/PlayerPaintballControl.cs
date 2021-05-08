/*This Code is for Lesson 2
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPaintballControl : MonoBehaviour
{
    public static int score =0;
    public int playerScore =0;
    //Connects to Paintball Object
    public GameObject Paintball_Prefab;

    
    //Connects to Cannonball Object*
    public GameObject Cannonball_Prefab;

    //public GameObject PlayerScript;

    //Connects to the Player's Camera
    public GameObject Player_Camera;



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get Mouse Button Left Click when Pressed Down
        if (Input.GetMouseButtonDown(0))
        {
            //Create Function that Creates the Paintball
            Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            //Create Function that Creates the Paintball
            Shoot_Cannonball();
        }


        if (Input.GetKeyDown(KeyCode.M))
        {
            //Changes the Scene to the Main Menu Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }

        playerScore = score;
    }
    void Shoot()
    {
        //Instantiate (Create New) Paintball as Paintball_Obj
        GameObject Paintball_Obj = Instantiate(Paintball_Prefab);

        //Change Paintball_Obj's Positions based on Player_Camera's position and 
        //in front of the Player_Camera
        Paintball_Obj.transform.position = Player_Camera.transform.position + Player_Camera.transform.forward;
        
        //Point in the Same Direction as Player_Camera Object
        Paintball_Obj.transform.forward = Player_Camera.transform.forward;

        //Remove Paintball_Obj as a Child of Player Object
        Paintball_Obj.transform.parent = null;
    }

    void Shoot_Cannonball()
    {
        //Instantiate (Create New) Cannonball as Cannonball_Obj
        GameObject Cannonball_Obj = Instantiate(Cannonball_Prefab);

        //Change Cannonball_Obj's Positions based on Player_Camera's position and 
        //in front of the Player_Camera
        Cannonball_Obj.transform.position = Player_Camera.transform.position + Player_Camera.transform.forward;
        
        //Point in the Same Direction as Player_Camera Object
        Cannonball_Obj.transform.forward = Player_Camera.transform.forward;

        //Remove Paintball_Obj as a Child of Player Object
        Cannonball_Obj.transform.parent = null;
    }
}
