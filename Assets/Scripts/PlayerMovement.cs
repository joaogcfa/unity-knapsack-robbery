using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool P1;
    public Rigidbody2D rb;
    public Vector2 velocidade;
    public float speed = 10.0f;
    public float inputX;
    public float inputY;
    public Animator animation;


    float x, y;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        float inputX;
        float inputY;

        x = this.transform.position.x;
        y = this.transform.position.y;


        if (P1)
        {
            inputX = Input.GetAxis("P1Horizontal");
            inputY = Input.GetAxis("P1Vertical");
        }
        else
        {
            inputX = Input.GetAxis("P2Horizontal");
            inputY = Input.GetAxis("P2Vertical");
        }

        if (inputY < 0)
        {
            animation.SetBool("isWalking", true);
            animation.SetBool("isBack", false);


        }
        else if (inputY > 0)
        {
            animation.SetBool("isWalking", false);
            animation.SetBool("isBack", true);


        }
        else
        {

            animation.SetBool("isWalking", false);
            animation.SetBool("isBack", false);

        }


        if (inputX < 0)
        {
            animation.SetBool("isLeft", true);
            animation.SetBool("isRight", false);


        }
        else if (inputX > 0)
        {
            animation.SetBool("isLeft", false);
            animation.SetBool("isRight", true);


        }
        else
        {

            animation.SetBool("isLeft", false);
            animation.SetBool("isRight", false);

        }


        Vector3 desiredVelocity = inputX * transform.right + inputY * transform.forward;

        velocidade = new Vector2(inputX * speed, inputY * speed);
        rb.MovePosition(rb.position + velocidade * Time.fixedDeltaTime);

    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Flashlight"){
            print("MORRI");
            SceneManager.LoadScene("Menu");
        }
    }
}
