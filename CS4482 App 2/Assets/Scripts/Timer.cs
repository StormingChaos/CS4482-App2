using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI text;               //reference to text component
    public static float timer = 0f;     //time elapsed

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player has not finished the maze
        if (!CompleteMaze.victory)
        {
            //calculate time elapsed
            timer += Time.deltaTime;
        }

        //set displayed text to be the time elapsed
        text.text = timer + "s";
    }
}
