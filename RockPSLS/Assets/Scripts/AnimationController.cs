using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator aiChoiceAnimator, slidingTimerAnimator, playerChoiceAnimator;

    public void PlayAIChoice()
    {
        aiChoiceAnimator.Play("ResizeAIChoice");
        Debug.Log("called AI resize");
    }

    public void TimerForPlayerChoice()
    {
        slidingTimerAnimator.Play("SlideTimer");
        Debug.Log("called timer");
    }

    public void DisplayPlayerChoice()
    {
        playerChoiceAnimator.Play("ShowPlayerChoice");
    }

    public void ResetAnimations()
    {
        playerChoiceAnimator.Play("RemovePlayerChoice");
        aiChoiceAnimator.Play("Idle");
        Debug.Log("called reset");
    }
}
