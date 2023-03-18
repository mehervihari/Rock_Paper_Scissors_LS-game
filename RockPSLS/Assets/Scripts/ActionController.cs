using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    private GameplayController gameplayController;
    // Start is called before the first frame update
    void Start()
    {
        gameplayController = GameplayController.instance;
        //GameplayController.instance
    }

    public void CallStartPlayerTimer()
    {
        gameplayController.StartPlayerTimer();
    }

    public void CallDetermineWinner()
    {
        gameplayController.DetermineWinner();
    }

    public void CallDoReset()
    {
        gameplayController.DoReset();
    }

    public void CallDecideNextRound()
    {
        gameplayController.DecideNextRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
