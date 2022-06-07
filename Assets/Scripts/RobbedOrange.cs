using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbedOrange : MonoBehaviour
{
    public GameObject player;
    float distanceBetweenObjects;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distanceBetweenObjects = Vector3.Distance(transform.position, player.transform.position);
        if(distanceBetweenObjects < 3) {
            if(Input.GetKeyDown(KeyCode.E)) {
                Destroy(gameObject);
            }
        }
    }
}
