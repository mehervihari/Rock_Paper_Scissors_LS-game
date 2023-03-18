using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static GameplayController instance;

    private GameChoices player_Choice = GameChoices.NONE, ai_Choice = GameChoices.NONE;

    private AnimationController animController;
    private UIController uiController;
    private int score;
    private const string winMsg = "You WIN!", loseMsg = "Game Over! You Lose...", 
                            tieMsg = "It's a Tie", noneMsg = "Game Over! No Choice Made...";
    private string roundResult;

    void Awake()
    {
        Debug.Log("called game awake");
        // see instnce calss
        if (instance == null)
            instance = this;
        else return;
        
        animController = GetComponent<AnimationController>();
        uiController = GetComponent<UIController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("called game start");
        GameStart();
    }

    private void GameStart()
    {
        SetAIChoice();
        animController.PlayAIChoice();
    }

    private void PlayerMadeChoice()
    {
        uiController.SetPlayerChoiceText(player_Choice.ToString());
        uiController.ChangePlayerSprite(player_Choice);

        //use ui manager
        uiController.ChangePlayerObjectsState(false);
        Debug.Log("set de-active");

        animController.DisplayPlayerChoice();
        Debug.Log("diaplayed player choice");
    }

    private void ValidateBestscore(int currscore)
    {
        Debug.Log("score valid");
        var bestscore = PlayerPrefs.GetInt("Bestscore");
        if (currscore > bestscore)
        {
            PlayerPrefs.SetInt("Bestscore", currscore);
        }
    }

    public void DecideNextRound()
    {
        Debug.Log("called decide nextround");
        uiController.ChangePlayerObjectsState(true);
        Debug.Log("set active");

        uiController.SetWinMessage("");

        if (score == 0 && roundResult != "It's a Tie")
        {
            ValidateBestscore(score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        else
        {    
            GameStart();
        }
    }

    public void StartPlayerTimer()
    {
        animController.TimerForPlayerChoice();
    }

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

        switch (rndNum)
        {
            //can use uiman here
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

    public void DoReset()
    {
        uiController.SetWinMessage(roundResult);
        uiController.SetPlayerScore(score.ToString());

        animController.ResetAnimations();
        player_Choice = GameChoices.NONE;
    }
}
