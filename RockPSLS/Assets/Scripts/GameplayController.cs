using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS,
    LIZARD,
    SPOCK
}

public class GameplayController : MonoBehaviour
{
    public TextMeshProUGUI AIChoiceText, WinfoText, PlayerScore;
    private GameChoices player_Choice = GameChoices.NONE, ai_Choice = GameChoices.NONE;
    private PlayerController playerController;
    private int score;

    private void Awake()
    {
        //AIChoiceText = AIChoiceText.GetComponent<Text>().text;
        playerController = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetAIChoice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerChoice(GameChoices playerChoice)
    {
        switch (playerChoice)
        {
            case GameChoices.ROCK:
                player_Choice = GameChoices.ROCK;
                break;

            case GameChoices.PAPER:
                player_Choice = GameChoices.PAPER;
                break;

            case GameChoices.SCISSORS:
                player_Choice = GameChoices.SCISSORS;
                break;

            case GameChoices.LIZARD:
                player_Choice = GameChoices.LIZARD;
                break;

            case GameChoices.SPOCK:
                player_Choice = GameChoices.SPOCK;
                break;
        }
    }

    public void SetAIChoice()
    {
        int rndNum = Random.Range(0, 5);

        switch(rndNum)
        {
            case 0:
                ai_Choice = GameChoices.ROCK;
                AIChoiceText.text = "Rock";
                break;
            case 1:
                ai_Choice = GameChoices.PAPER;
                AIChoiceText.text = "Paper";
                break;
            case 2:
                ai_Choice = GameChoices.SCISSORS;
                AIChoiceText.text = "Scissors";
                break;
            case 3:
                ai_Choice = GameChoices.LIZARD;
                AIChoiceText.text = "Lizard";
                break;
            case 4:
                ai_Choice = GameChoices.SPOCK;
                AIChoiceText.text = "Spock";
                break;
        }

        StartCoroutine(PlayerChoiceCoroutine());
    }

    private IEnumerator PlayerChoiceCoroutine()
    {
        yield return new WaitForSeconds(2);

        //ayerController.GetPlayerChoice();
        if(player_Choice == GameChoices.NONE)
        {
            Debug.Log("player not chose any............");
        }
        //Debug.Log("player chose: " + player_Choice);

        DetermineWinnerAndRepeat();
    }

    void DetermineWinnerAndRepeat()
    {
        if(player_Choice == ai_Choice)
        {
            WinfoText.text = "It's a Tie";
        }

        if(player_Choice == GameChoices.ROCK)
        {
            if(ai_Choice == GameChoices.LIZARD || ai_Choice == GameChoices.SCISSORS)
            {
                WinfoText.text = "Player Wins";
                score++;
            }
            else
            {
                WinfoText.text = "AI Wins";
                score = 0;
            }
        }

        if(player_Choice == GameChoices.PAPER)
        {
            if (ai_Choice == GameChoices.ROCK || ai_Choice == GameChoices.SPOCK)
            {
                WinfoText.text = "Player Wins";
                score++;
            }
            else
            {
                WinfoText.text = "AI Wins";
                score = 0;
            }
        }

        if (player_Choice == GameChoices.SCISSORS)
        {
            if (ai_Choice == GameChoices.PAPER || ai_Choice == GameChoices.LIZARD)
            {
                WinfoText.text = "Player Wins";
                score++;
            }
            else
            {
                WinfoText.text = "AI Wins";
                score = 0;
            }
        }

        if (player_Choice == GameChoices.LIZARD)
        {
            if (ai_Choice == GameChoices.PAPER || ai_Choice == GameChoices.SPOCK)
            {
                WinfoText.text = "Player Wins";
                score++;
            }
            else
            {
                WinfoText.text = "AI Wins";
                score = 0;
            }
        }

        if (player_Choice == GameChoices.SPOCK)
        {
            if (ai_Choice == GameChoices.ROCK || ai_Choice == GameChoices.SCISSORS)
            {
                WinfoText.text = "Player Wins";
                score++;
            }
            else
            {
                WinfoText.text = "AI Wins";
                score = 0;
            }
        }

        PlayerScore.text = score.ToString();
        player_Choice = GameChoices.NONE;
        SetAIChoice();
    }
}
