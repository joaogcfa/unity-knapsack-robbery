using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbedBlue : MonoBehaviour
{
    public GameObject player;
    float distanceBetweenObjects;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetweenObjects = Vector3.Distance(transform.position, player.transform.position);
        if(distanceBetweenObjects < 3) {
            if(Input.GetKeyDown("space")) {
                Destroy(gameObject);
            }
        }
    }
}
