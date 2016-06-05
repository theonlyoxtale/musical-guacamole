﻿using UnityEngine;
using System.Collections;

public class NumberWizardScript : MonoBehaviour {

    // Use this for initialization
    int max;
    int min;
    int guess;

    void Start () {
        StartGame(); 
	}

    void StartGame()
    {
        //setup the initial values for the guessing game
        max = 1000;
        min = 1;
        guess = 500;

        //prints messages for the beginning of the game
        print("============================");
        print("Welcome to Number Wizard");
        print("Pick in number in your head but don't tell me");

        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);

        print("Is the number higher or lower than " + guess + " ?");
        
        //makes sure that a guess can be up to either 1 or 1000
        max = max++;

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //print("Up arrow pressed");
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //print("Down arrow pressed");
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I won!");
            StartGame();
        }
	}

    void NextGuess()
    {
        guess = (max + min) / 2;
        print("Higher or lower than " + guess);
        print("up arrow for higher, down for lower, return for equal");
    }
}
