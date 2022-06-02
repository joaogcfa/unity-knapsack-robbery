using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool P1;
    public Rigidbody2D rb;
    public Vector2 velocidade;
    public float speed = 10.0f;
    public float inputX;
    public float inputY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX;
        float inputY;
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


        Vector3 desiredVelocity = inputX * transform.right + inputY * transform.forward;

        velocidade = new Vector2(inputX * speed, inputY * speed);
        rb.MovePosition(rb.position + velocidade * Time.fixedDeltaTime);
        
    }
}
