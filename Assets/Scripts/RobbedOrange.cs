using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbedOrange : MonoBehaviour
{
    public GameObject player;
    public GameObject gm;
    float distanceBetweenObjects;
    public int value;

    public string valueTxt;

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
                valueTxt = GameObject.Find("TextP1").GetComponent<UnityEngine.UI.Text>().text;
                value += int.Parse(valueTxt.Substring(1,valueTxt.Length-4));
                valueTxt = '$' + value.ToString() + ",00" ;
                GameObject.Find("TextP1").GetComponent<UnityEngine.UI.Text>().text = valueTxt;
                Destroy(gameObject);
            }
        }
    }
}
