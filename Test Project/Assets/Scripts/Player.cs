using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Paintball_Prefab;
    public GameObject Player_Camera;
    public int scoreCount = 0;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
            GameObject Paintball_Obj = Instantiate(Paintball_Prefab);
            Paintball_Obj.transform.position = Player_Camera.transform.position + Player_Camera.transform.forward;
            Paintball_Obj.transform.forward = Player_Camera.transform.forward;
            Paintball_Obj.transform.parent = transform;
    }
    
    public void setScore(int updateScore)
    {
        scoreCount = scoreCount + updateScore;
    }
}
