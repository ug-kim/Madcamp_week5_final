﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar1 : MonoBehaviour
{
    static public Collider2D coll;
    void Start()
    {
        coll = gameObject.GetComponent<Collider2D>();
    }
}