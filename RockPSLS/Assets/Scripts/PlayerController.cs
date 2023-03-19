using UnityEngine;
using UnityEngine.UI;

/*  
    This class is responsible for controlling the Player.
    It includes the actions that can be done by the player.
*/

public class PlayerController : MonoBehaviour
{
    // reference to GameplayController singleton class
    private GameplayController gameplayController;

    // awake is called when the script instance is loaded
    void Start()
    {
        gameplayController = GameplayController.instance;
    }

    // function that's called when the player chooses any of the given choices/ options by clicking on the UI
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
