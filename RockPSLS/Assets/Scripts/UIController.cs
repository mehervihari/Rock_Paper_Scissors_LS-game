using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*  
    This class is responsible for controlling the UI in the game.
    It can access and modify different UI elements as per requirement.
*/

public class UIController : MonoBehaviour
{
    // variables for different texts that are to be modified
    [SerializeField]
    private TextMeshProUGUI AIChoiceText, PlayerChoiceText, WinInfoText, PlayerScoreText;

    // variables for maintaining required sprites
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite, lizard_Sprite, spock_Sprite;

    // variables of the AI, player choice images
    [SerializeField]
    private Image playerChoice_Img, aiChoice_Img;

    // variables of required gameobjects
    [SerializeField]
    private GameObject TimerSlider, PlayerOptionsHolder;

    // function to set the text of AI choice
    public void SetAIChoiceText(string choicename)
    {
        AIChoiceText.text = choicename;
    }

    // function to set the text of player's choice
    public void SetPlayerChoiceText(string choicename)
    {
        PlayerChoiceText.text = choicename;
    }

    // function to set the result of current game round
    public void SetWinMessage(string winmsg)
    {
        WinInfoText.text = winmsg;
    }

    // function to set the score of player
    public void SetPlayerScore(string playerscore)
    {
        PlayerScoreText.text = playerscore;
    }

    // function to get the score of player
    public int GetPlayerScore()
    {
        return Int32.Parse(PlayerScoreText.text);
    }

    // function to change the state of required gameobjects
    public void ChangePlayerObjectsState(bool state)
    {
        TimerSlider.SetActive(state);
        PlayerOptionsHolder.SetActive(state);
    }

    // function to change the player sprite as per the choice made
    public void ChangePlayerSprite(GameChoices playerChoice)
    {
        switch (playerChoice)
        {
            case GameChoices.ROCK:
                playerChoice_Img.sprite = rock_Sprite;
                break;

            case GameChoices.PAPER:
                playerChoice_Img.sprite = paper_Sprite;
                break;

            case GameChoices.SCISSORS:
                playerChoice_Img.sprite = scissors_Sprite;
                break;

            case GameChoices.LIZARD:
                playerChoice_Img.sprite = lizard_Sprite;
                break;

            case GameChoices.SPOCK:
                playerChoice_Img.sprite = spock_Sprite;
                break;
            default: playerChoice_Img.sprite = null; 
                break;
        }
    }

    // function to change the AI sprite as per the choice made
    public void ChangeAISprite(GameChoices aiChoice)
    {
        switch (aiChoice)
        {
            case GameChoices.ROCK:
                aiChoice_Img.sprite = rock_Sprite;
                break;

            case GameChoices.PAPER:
                aiChoice_Img.sprite = paper_Sprite;
                break;

            case GameChoices.SCISSORS:
                aiChoice_Img.sprite = scissors_Sprite;
                break;

            case GameChoices.LIZARD:
                aiChoice_Img.sprite = lizard_Sprite;
                break;

            case GameChoices.SPOCK:
                aiChoice_Img.sprite = spock_Sprite;
                break;
            default: aiChoice_Img.sprite = null; break;
        }
    }
}
