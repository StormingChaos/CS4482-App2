using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    Animator anim;
    GameObject player;
    public static bool getInput = false;
    public GameObject victoryScreen;

    // Start is called before the first frame update
    void Awake()
    {
        anim = victoryScreen.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (CompleteMaze.victory)
        {
            //anim.SetTrigger("GameOver");
            victoryScreen.gameObject.SetActive(true);

            if (PauseMenu.GamePaused)
            {
                victoryScreen.gameObject.SetActive(false);
            }
            else
            {
                victoryScreen.gameObject.SetActive(true);
            }
        }
    }

    public void EnableTextEntry ()
    {
        getInput = true;
    }

    public void DisableTextEntry()
    {
        getInput = false;
    }

    public void SubmitScore()
    {
        Debug.Log("Submitting Score...");
    }
}
