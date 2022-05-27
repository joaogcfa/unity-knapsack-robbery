using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolGuard : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int spot;
    public float rotation;

    public Animator animation;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        spot = 0; 

        rotation = transform.eulerAngles.z;

        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[spot].position, speed * Time.deltaTime);

        // print(transform.position);

        // Vector2 variacao = moveSpots[0].position - moveSpots[1].position;
        // print(variacao);

        // if(variacao.y > 0){
        //     animation.SetBool("isDown", true);
        // }


        if(Vector2.Distance(transform.position, moveSpots[spot].position) < 0.2f) 
        {
            animation.SetBool("isUp", false);
            animation.SetBool("isDown", false);
            animation.SetBool("isLeft", false);
            animation.SetBool("isRight", false);

            if(waitTime <= 0) 
            {
                if(spot == 0) {
                    spot = 1;
                } else {
                    spot = 0;
                }
                waitTime = startWaitTime;
                // this.gameObject.GetComponent<GuardRotation>().stopRotation = false;


            } else {
                waitTime -= Time.deltaTime;
                // this.gameObject.GetComponent<GuardRotation>().canRotate = true;
            }
        }
    }
}
