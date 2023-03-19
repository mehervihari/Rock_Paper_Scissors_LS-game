using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  
    This class is responsible for controlling the actions in the game.
    It includes the actions/ animations that are to be performed in the game flow.
*/

public class ActionController : MonoBehaviour
{
    // reference to GameplayController singleton class
    private GameplayController gameplayController;

    // awake is called when the script instance is loaded
    void Start()
    {
        gameplayController = GameplayController.instance;
    }

    // event function that is called at the end of AI choice animation
    public void CallStartPlayerTimer()
    {
        gameplayController.StartPlayerTimer();
    }

    // event function that is called at the end of timer animation
    public void CallDetermineWinner()
    {
        gameplayController.DetermineWinner();
    }

    // event function that is called at the end of showing player choice animation
    public void CallDoReset()
    {
        gameplayController.DoReset();
    }

    // event function that is called at the end of removing player choice animation
    public void CallDecideNextRound()
    {
        gameplayController.DecideNextRound();
    }
}
