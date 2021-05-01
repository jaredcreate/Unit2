using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSplatter : MonoBehaviour
{
    //Starting Countdown
    public float countTimer = 10f;

    //Countdown Variable
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //Start the Count down
        timer = countTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Count down
        timer -= Time.deltaTime;

        //Destroy the Splatter When CountDown hit Zero
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
