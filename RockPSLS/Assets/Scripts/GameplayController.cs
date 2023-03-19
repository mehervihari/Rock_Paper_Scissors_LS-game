using UnityEngine;
using UnityEngine.SceneManagement;

// enum to maintain the different choices that can be made by players
public enum GameChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS,
    LIZARD,
    SPOCK
}

/*  
    This class is responsible for the actual game logic and gameplay.
    It controlls the game and the sequence of events in it.
    This is a singeton class.
*/

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    // reference for AnimationController class
    private AnimationController animController;

    // reference for UIController class
    private UIController uiController;

    // Choices made by player and AI
    private GameChoices player_Choice = GameChoices.NONE, ai_Choice = GameChoices.NONE;

    // variable to maintain the player score
    private int score;

    // different winning messages for any game round
    private const string winMsg = "You WIN!", loseMsg = "Game Over! You Lose...", 
                            tieMsg = "It's a Tie", noneMsg = "Game Over! No Choice Made...";

    // variable to put the result of the current game round
    private string roundResult;

    // awake is called when the script instance is loaded
    void Awake()
    {
        if (instance == null)
            instance = this;
        else return;
        
        animController = GetComponent<AnimationController>();
        uiController = GetComponent<UIController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // function that actually starts the game
    private void GameStart()
    {
        SetAIChoice();
        animController.PlayAIChoice();
    }

    // function that is called when player makes a choice
    private void PlayerMadeChoice()
    {
        uiController.SetPlayerChoiceText(player_Choice.ToString());
        uiController.ChangePlayerSprite(player_Choice);
        uiController.ChangePlayerObjectsState(false);

        animController.DisplayPlayerChoice();
    }

    // function to update the best/ highest score of the player
    private void ValidateBestscore(int currscore)
    {
        var bestscore = PlayerPrefs.GetInt("Bestscore");
        if (currscore > bestscore)
        {
            PlayerPrefs.SetInt("Bestscore", currscore);
        }
    }

    // function that decides whether next round can be continued or not
    public void DecideNextRound()
    {
        uiController.ChangePlayerObjectsState(true);
        uiController.SetWinMessage("");

        if (score == 0 && roundResult != "It's a Tie")
        {
            ValidateBestscore(score);
            SceneManager.LoadScene("MainMenu");
        }

        else
        {    
            GameStart();
        }
    }

    // function that calls the timer animation
    public void StartPlayerTimer()
    {
        animController.TimerForPlayerChoice();
    }

    // function that determines the winner of the current game round
    public void DetermineWinner()
    {
        if (player_Choice == ai_Choice)
        {
            roundResult = tieMsg;
        }

        else
        {
            switch (player_Choice)
            {
                case GameChoices.NONE:
                    roundResult = noneMsg;
                    score = 0;
                    break;

                case GameChoices.ROCK:
                    if (ai_Choice == GameChoices.LIZARD || ai_Choice == GameChoices.SCISSORS)
                    {
                        roundResult = winMsg;
                        score++;
                    }
                    else
                    {
                        roundResult = loseMsg;
                        score = 0;
                    }
                    break;

                case GameChoices.PAPER:
                    if (ai_Choice == GameChoices.ROCK || ai_Choice == GameChoices.SPOCK)
                    {
                        roundResult = winMsg;
                        score++;
                    }
                    else
                    {
                        roundResult = loseMsg;
                        score = 0;
                    }
                    break;

                case GameChoices.SCISSORS:
                    if (ai_Choice == GameChoices.PAPER || ai_Choice == GameChoices.LIZARD)
                    {
                        roundResult = winMsg;
                        score++;
                    }
                    else
                    {
                        roundResult = loseMsg;
                        score = 0;
                    }
                    break;

                case GameChoices.LIZARD:
                    if (ai_Choice == GameChoices.PAPER || ai_Choice == GameChoices.SPOCK)
                    {
                        roundResult = winMsg;
                        score++;
                    }
                    else
                    {
                        roundResult = loseMsg;
                        score = 0;
                    }
                    break;

                case GameChoices.SPOCK:
                    if (ai_Choice == GameChoices.ROCK || ai_Choice == GameChoices.SCISSORS)
                    {
                        roundResult = winMsg;
                        score++;
                    }
                    else
                    {
                        roundResult = loseMsg;
                        score = 0;
                    }
                    break;
            }
        }

        ValidateBestscore(uiController.GetPlayerScore());
        PlayerMadeChoice();
    }

    // function to set the choice of the player
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

    // function to set the choice of AI (computer)
    public void SetAIChoice()
    {
        int rndNum = Random.Range(0, 5);

        switch (rndNum)
        {
            case 0:
                ai_Choice = GameChoices.ROCK;
                break;
            case 1:
                ai_Choice = GameChoices.PAPER;
                break;
            case 2:
                ai_Choice = GameChoices.SCISSORS;
                break;
            case 3:
                ai_Choice = GameChoices.LIZARD;
                break;
            case 4:
                ai_Choice = GameChoices.SPOCK;
                break;
        }

        uiController.SetAIChoiceText(ai_Choice.ToString());
        uiController.ChangeAISprite(ai_Choice);
    }

    // function to reset few things before proceeding to next game round
    public void DoReset()
    {
        uiController.SetWinMessage(roundResult);
        uiController.SetPlayerScore(score.ToString());

        animController.ResetAnimations();
        player_Choice = GameChoices.NONE;
    }
}
