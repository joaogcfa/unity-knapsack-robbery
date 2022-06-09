using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    // public GameObject player1;
    // public GameObject player2;

    private int contador;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        // player1 = GameObject.Find("Player1");
        // player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        if(contador == 2){
            // if (SceneManager.GetActiveScene().buildIndex == 3) {
            //     SceneManager.LoadScene(0);
            // } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // }
        }

    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        print("colisão");
        if(col.gameObject.tag == "Player") {
            Destroy(col.gameObject);
            contador++;
        }
    }
}
