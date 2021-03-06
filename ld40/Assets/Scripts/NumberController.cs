﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

        char[] value = GameStates.score.ToString().ToCharArray();
        
            for(int i = 0; i < value.Length; i++)
            {
                transform.GetChild(i).GetChild(toInt(value[i])).GetComponent<SpriteRenderer>().enabled = true;

            }
        
	}
    private int toInt(int i)
    {
        switch (i)
        {
            case '0':
                return 0;
            case '1':
                return 1;
            case '2':
                return 2;
            case '3':
                return 3;
            case '4':
                return 4;
            case '5':
                return 5;
            case '6':
                return 6;
            case '7':
                return 7;
            case '8':
                return 8;
            case '9':
                return 9;
            default:
                return 9;
        }
    }
}
