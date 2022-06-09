using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbedBlueOrange : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject gm;
    float distanceBlue;
    float distanceOrange;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        distanceBlue = Vector3.Distance(transform.position, player1.transform.position);
        distanceOrange = Vector3.Distance(transform.position, player2.transform.position);
        if(distanceBlue < 8 && distanceOrange < 8) {
            print("ENTREI");
            if(Input.GetKey("space") && Input.GetKey(KeyCode.E)) {
                gm.GetComponent<GameManager>().itemsRobbed += 1;
                Destroy(gameObject);
            }
        }
    }
}
