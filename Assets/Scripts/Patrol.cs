using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int spot;
    public float rotation;
    public int limit;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        spot = 0; 

        rotation = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[spot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[spot].position) < 0.2f) 
        {
            if(waitTime <= 0) 
            {   
                spot++;
                if(spot == limit) {
                    spot = 0;
                }
                transform.Rotate(0f, 0f, 180f);
                waitTime = startWaitTime;
                this.gameObject.GetComponent<GuardRotation>().stopRotation = false;
            } else {
                waitTime -= Time.deltaTime;
                this.gameObject.GetComponent<GuardRotation>().canRotate = true;
            }
        } else {
            this.gameObject.GetComponent<GuardRotation>().canRotate = false;
        }
    }
}
