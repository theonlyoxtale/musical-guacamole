using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizardScript : MonoBehaviour
{
  // Use this for initialization
  int max; // max number to guess
  int min; // minimum number to guess
  int guess; // the number being guessed
  //variable that holds the number of guesses allowed by the computer
  public int _MaxGuessesAllowed = 5;
  //variable that holds the current number guess
  public Text text;

  void Start()
  {
    StartGame();
  }

  void StartGame()
  {
    //setup the initial values for the guessing game
    max = 1001;
    min = 1;
    NextGuess();
  }

  public void GuessHigher()
  {
    min = guess;
    NextGuess();
  }

  public void GuessLower()
  {
    max = guess;
    NextGuess();
  }

  void NextGuess()
  {
    //makes sure that a guess can be up to either 1 or 1000
    guess = (max + min) / Random.Range(min,max+1);
    text.text = guess.ToString();
    _MaxGuessesAllowed = _MaxGuessesAllowed - 1;
    if (_MaxGuessesAllowed <= 0)
    {
      Application.LoadLevel("win");
    }
  }
}