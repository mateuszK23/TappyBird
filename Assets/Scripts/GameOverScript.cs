using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text highScore;
    [SerializeField] private Text currentScore;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void displayGameOver()
    {
        if (StateController.score > StateController.bestScore)
          StateController.bestScore = StateController.score;

        highScore.text = "Best Score: " + StateController.bestScore;
        currentScore.text = "Current Score: " + StateController.score;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void tryAgain()
    {
        SceneManager.LoadScene("Gameplay");
    }

}
