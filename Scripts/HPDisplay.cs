using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPDisplay : MonoBehaviour

{
    TextMeshProUGUI HPText;
    Player player;

    void Start()
    {
        HPText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        HPText.text = "HP: " + player.GetHP().ToString();
    }
}
