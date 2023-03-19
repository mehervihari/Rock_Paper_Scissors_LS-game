using UnityEngine;

/*  
    This class is responsible for the animations in the game.
    It can play the animations present in the game.
*/

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator aiChoiceAnimator, slidingTimerAnimator, playerChoiceAnimator;

    // function to play the AI choice with animation
    public void PlayAIChoice()
    {
        aiChoiceAnimator.Play("ResizeAIChoice");
    }

    // function to play the timer animation that shows the time in which player has to make choice
    public void TimerForPlayerChoice()
    {
        slidingTimerAnimator.Play("SlideTimer");
    }

    // function to display the player choice with animation
    public void DisplayPlayerChoice()
    {
        playerChoiceAnimator.Play("ShowPlayerChoice");
    }

    // function to bring the required animations to kinda initial state
    public void ResetAnimations()
    {
        playerChoiceAnimator.Play("RemovePlayerChoice");
        aiChoiceAnimator.Play("Idle");
    }
}
