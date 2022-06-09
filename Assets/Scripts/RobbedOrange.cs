using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbedOrange : MonoBehaviour
{
    public GameObject player;
    public GameObject gm;
    float distanceBetweenObjects;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
        gm = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        distanceBetweenObjects = Vector3.Distance(transform.position, player.transform.position);
        if(distanceBetweenObjects < 3) {
            if(Input.GetKeyDown(KeyCode.E)) {
                gm.GetComponent<GameManager>().itemsRobbed += 1;
                Destroy(gameObject);
            }
        }
    }
}
