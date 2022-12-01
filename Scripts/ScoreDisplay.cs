using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    Gameseesion gameseesion;
    TextMeshProUGUI scoretext;

    void Start()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
        gameseesion = FindObjectOfType<Gameseesion>();
    }
    void Update()
    {
        scoretext.text = "Score " + (gameseesion.GetScore().ToString());
    }
}
