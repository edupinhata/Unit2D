using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    int min, max, guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame(){
        max = 1000;
        min = 1;
        guess = 500;
        Debug.Log("Choose a number between " + min + " and " + max + ".");
        Debug.Log("Arrow Up = Number is Higher, Arrow Down = Number is Lower, Enter = Correct");
        Debug.Log("First guess is: " + guess);
        max += 1;
    }

    // Update is called once per frame
    void Update()
    {
        // The number is higher than the guess
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
            NextGuess();
        }
        // The number is lower than the guess
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            max = guess;
            NextGuess(); 
        }
        //The guess is right
        if (Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("Seu número é " + guess);
            StartGame();
        }

    }

    void NextGuess()
    {
        guess =  (max + min) / 2;
        Debug.Log("A nova guess é: " + guess);
    }


}
