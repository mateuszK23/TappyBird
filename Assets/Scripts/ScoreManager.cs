using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreField;
    private bool gameStarted;
    [SerializeField]
    private Text startText;

    private void Awake()
    {
        Time.timeScale = 0;
        gameStarted = false;
        startText.gameObject.SetActive(true);
        scoreField.gameObject.SetActive(false);
        StateController.isGameOver = false;
    }

    void Start()
    {
        StateController.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameStart();
        scoreField.text = StateController.score.ToString();
        if (StateController.isGameOver) gameObject.SetActive(false);
    }

    private void gameStart()
    {
        if (!gameStarted && (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")))
        {
            Time.timeScale = 1;
            gameStarted = true;
            startText.gameObject.SetActive(false);
            scoreField.gameObject.SetActive(true);
        }
    }

}
