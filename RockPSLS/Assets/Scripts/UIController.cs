using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI AIChoiceText, PlayerChoiceText, WinInfoText, PlayerScoreText;
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite, lizard_Sprite, spock_Sprite;
    [SerializeField]
    private Image playerChoice_Img, aiChoice_Img;
    [SerializeField]
    private GameObject TimerSlider, PlayerOptionsHolder;

    public void SetAIChoiceText(string choicename)
    {
        AIChoiceText.text = choicename;
    }

    public void SetPlayerChoiceText(string choicename)
    {
        PlayerChoiceText.text = choicename;
    }

    public void SetWinMessage(string winmsg)
    {
        WinInfoText.text = winmsg;
    }

    public void SetPlayerScore(string playerscore)
    {
        PlayerScoreText.text = playerscore;
    }

    public int GetPlayerScore()
    {
        return Int32.Parse(PlayerScoreText.text);
    }

    public void ChangePlayerObjectsState(bool state)
    {
        TimerSlider.SetActive(state);
        PlayerOptionsHolder.SetActive(state);
    }

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
