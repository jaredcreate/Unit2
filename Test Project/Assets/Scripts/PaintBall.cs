using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBall : MonoBehaviour
{
    public GameObject Paintball_Splatter_Prefab;
    public float speed = 15f;
    public float countTimer = 5f;
    public LayerMask canBeHit;
    private bool hitTrue = false;
    private Collider m_Collider;

    public GameObject playerObject;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = countTimer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        timer -= Time.deltaTime;
        if(timer<= 0f)
        {
            Destroy(gameObject);
        }
        if (hitTrue == false)
        {
            hit();
        }
    }
    void hit()
    {
        RaycastHit hasHit = new RaycastHit();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.1f, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hasHit, 0.5f, canBeHit))
        {
            float distance;
            float scaleHit;
            int score;
            //Debug.Log(hasHit.point.x - hasHit.transform.localPosition.x);
            //hasHit.point
            GameObject Paintball_Splatter = Instantiate(Paintball_Splatter_Prefab, hasHit.point + hasHit.normal * 0.001f,Quaternion.identity) as GameObject;
            Paintball_Splatter.transform.LookAt(hasHit.point + hasHit.normal);
            Paintball_Splatter.transform.parent = hasHit.transform;
            hitTrue = true;
            //string name = hasHit.collider.name;
            //Debug.Log("name :" + name);
            if (hasHit.collider.tag == "Target") 
            {
                distance = Vector2.Distance(Paintball_Splatter.transform.localPosition, new Vector2(0.0f, 0.0f)) * 100.0f;
                scaleHit = hasHit.transform.localScale.x;
                score = (23 - Mathf.RoundToInt(distance));
                score = Mathf.RoundToInt((score / scaleHit));
                if(score < 0)
                {
                    score = score * -1;
                }
                Debug.Log("score :" + score);
                //playerObject.GetComponent<Player>().setScore(score);
                
                //GUI_Script.SetScore(score);
            }
            Destroy(gameObject);
        }
    }
    




}
