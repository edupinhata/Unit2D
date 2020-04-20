using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;
    List<int> guessed = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        NextGuess();
    }

    public void OnPressHigher()
    {
        if (guess != max)
            min = guess + 1;
        else
            min = max;
        NextGuess();
    }

    public void OnPressLower()
    {
        max = guess;
        NextGuess();
    }

    private void NextGuess()
    {
        guess = Random.Range(min, max);
        while (guessed.Contains(guess) && min != max)
        {
            guess = Random.Range(min, max+1);
        }
        guessed.Add(guess);
        guessText.text = guess.ToString();
    }
}
