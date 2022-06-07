using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbedBlueOrange : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    float distanceBlue;
    float distanceOrange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceBlue = Vector3.Distance(transform.position, player1.transform.position);
        distanceOrange = Vector3.Distance(transform.position, player2.transform.position);
        if(distanceBlue < 8 && distanceOrange < 8) {
            print("ENTREI");
            if(Input.GetKey("space") && Input.GetKey(KeyCode.E)) {
                Destroy(gameObject);
            }
        }
    }
}
