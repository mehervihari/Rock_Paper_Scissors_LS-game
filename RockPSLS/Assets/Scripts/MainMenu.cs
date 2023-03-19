using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  
    This class is responsible for the actions in the Main menu of the game.
    Game starts with the main menu
*/

public class MainMenu : MonoBehaviour
{
    // variable that displays the best score
    [SerializeField]
    public TextMeshProUGUI bestScoreText;

    // updates the best score everytime start is called i.e whenever main menu is loaded
    void Start()
    {
        bestScoreText.text = PlayerPrefs.GetInt("Bestscore").ToString();
    }

    // function to load the actual game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Play_Scene");
    }
}
