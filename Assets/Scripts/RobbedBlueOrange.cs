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

    public int value;
    public string valueTxt1;
    public string valueTxt2;


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
                valueTxt1 = GameObject.Find("TextP1").GetComponent<UnityEngine.UI.Text>().text;
                valueTxt2 = GameObject.Find("TextP2").GetComponent<UnityEngine.UI.Text>().text;
                value += int.Parse(valueTxt1.Substring(1,valueTxt1.Length-4));
                value += int.Parse(valueTxt2.Substring(1,valueTxt2.Length-4));
                valueTxt1 = '$' + value.ToString() + ",00" ;
                valueTxt2 = '$' + value.ToString() + ",00" ;
                GameObject.Find("TextP1").GetComponent<UnityEngine.UI.Text>().text = valueTxt1;
                GameObject.Find("TextP2").GetComponent<UnityEngine.UI.Text>().text = valueTxt2;
                Destroy(gameObject);
            }
        }
    }
}
