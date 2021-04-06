using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSplater : MonoBehaviour
{

    private float countTimer = 50f;
    private float timer;
    Renderer rend;
    public GameObject Splatter;


    // Start is called before the first frame update
    void Start()
    {
        timer = countTimer;
        
        RandomColor(rend);
        RandomScale(Splatter);

    }

    void RandomScale(GameObject Splatter)
    {
        float scaleXY = Random.Range(0.01f, 0.05f);

        Splatter.transform.localScale = new Vector3(scaleXY, 1, scaleXY);
    }

    // Update is called once per frame
    void Update()
    {

        
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }
    // Generate a random color value.
    void RandomColor(Renderer rend)
    {
        rend = Splatter.GetComponent<Renderer>();
        // A different random value is used for each color component (if
        // the same is used for R, G and B, a shade of grey is produced).
        rend.material.color = new Color(Random.value, Random.value, Random.value);
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.parent = collision.transform;
    }
}
