using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int itemsToRob;
    public int itemsRobbed;

    public GameObject door;


    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        GameObject.Find("Door").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (itemsRobbed == itemsToRob){
            door.SetActive(true);
        }
        
    }
}
