﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreUpdate : MonoBehaviour
{
    Text scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "score " + scoreManager.score;
    }
}
