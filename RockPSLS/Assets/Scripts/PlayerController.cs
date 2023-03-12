using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private GameplayController gameplayController;

    private void Awake()
    {
        gameplayController = GetComponent<GameplayController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPlayerChoice()
    {
        string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        GameChoices playerChoice = GameChoices.NONE;

        switch (choiceName)
        {
            case "Rock":
                playerChoice = GameChoices.ROCK;
                break;

            case "Paper":
                playerChoice = GameChoices.PAPER;
                break;

            case "Scissors":
                playerChoice = GameChoices.SCISSORS;
                break;

            case "Lizard":
                playerChoice = GameChoices.LIZARD;
                break;

            case "Spock":
                playerChoice = GameChoices.SPOCK;
                break;
        }

        gameplayController.SetPlayerChoice(playerChoice);
    }
}
