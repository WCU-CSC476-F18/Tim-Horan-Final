using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int points, score;
    
    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        points = 0;
        score = 0;
    }


    void Update ()
    {
        text.text = "Points: " + points;
    }
}
