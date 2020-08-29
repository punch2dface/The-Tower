using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonControl : MonoBehaviour
{
    public GameObject pauseWindow;
    public PlayerControl pc;
    public GameObject optionWindow;
    public GameObject pauseButton;
    public GameObject gameOverWindow;
    public Rigidbody2D rb;
    public Camera cam;
    public static Boolean retryGame;


    public Vector3 ogCamPos;
    public Vector3 ogPos;

    private void Awake()
    {
        ogPos = rb.transform.position;
        ogCamPos = new Vector3(0, 4, 0);
    }

    public void PauseGame()
    {
        // set pause window active
        // pause time
        //
        pauseButton.SetActive(false);
        pc.enabled = false;
        pauseWindow.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Is Paused");
    }

    public void RetryGame()
    {
        // set window to false
        // set player position back to origin
        // resume game
        retryGame = true;
        gameOverWindow.SetActive(false);
        pauseButton.SetActive(true);
        pc.enabled = true;
        rb.transform.position = ogPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;

        cam.transform.position = ogCamPos;

        Time.timeScale = 1f;
    }

    public void QuitGame(string menuScene)
    {
        // go back to main menu scene
        pc.enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }

    public void Option()
    {
        // set option window to true
        // set
        pauseWindow.SetActive(false);
        optionWindow.SetActive(true);
        // save button etc.
    }

    public void ResumeGame()
    {
        // similar to retry game function
        pauseButton.SetActive(true);
        pc.enabled = true;
        pauseWindow.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Game Has been Resumed");
    }

    public void SaveOption()
    {
        //save setting
        optionWindow.SetActive(false);
        pauseWindow.SetActive(true);
    }

    public void NextLevel(string nextLevel)
    {
        //pc.enabled = true;
        //Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel);

    }
}
