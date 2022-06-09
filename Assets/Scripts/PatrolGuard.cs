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
    Vector2 position_;

    public int limit;

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
        position_=transform.position;

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[spot].position, speed * Time.deltaTime);

        // print(transform.position.x);
       
        if(Mathf.Round((position_.y)) < Mathf.Round((transform.position.y))){
            animation.SetBool("isUp", true);

        }else if(Mathf.Round((position_.y))> Mathf.Round((transform.position.y))){
            animation.SetBool("isDown", true);

        }

        if(Mathf.Round((position_.x)) < Mathf.Round((transform.position.x))){
            animation.SetBool("isRight", true);

        }else if(Mathf.Round((position_.x))> Mathf.Round((transform.position.x))){
            animation.SetBool("isLeft", true);

        }


        if(Vector2.Distance(transform.position, moveSpots[spot].position) < 0.2f) 
        {
            animation.SetBool("isUp", false);
            animation.SetBool("isDown", false);
            animation.SetBool("isLeft", false);
            animation.SetBool("isRight", false);

            if(waitTime <= 0) 
            {
                spot++;
                if(spot == limit) {
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
