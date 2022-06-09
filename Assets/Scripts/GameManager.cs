using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int itemsToRob;
    public int itemsRobbed;

    public GameObject door;

    public GameObject PausePanel;
    public static bool isPaused;


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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pause();
            }

            else
            {
                resume();
            }
        }
        
    }

    public void resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        PausePanel.gameObject.SetActive(false);
    }
    public void pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        PausePanel.gameObject.SetActive(true);
    }
}
