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
        pauseButton.SetActive(false);
        pc.enabled = false;
        pauseWindow.SetActive(true);
        Debug.Log("Game Is Paused");
        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
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
        StartCoroutine(ClickQuit(menuScene));
        Time.timeScale = 1f;
    }

    IEnumerator ClickQuit(string menuScene)
    {
        yield return new WaitForSeconds(0.4f);
        pc.enabled = true;
        SceneManager.LoadScene(menuScene);
    }

    public void Option()
    {
        pauseWindow.SetActive(false);
        optionWindow.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseButton.SetActive(true);
        pc.enabled = true;
        pauseWindow.SetActive(false);
        Debug.Log("Game Has been Resumed");
        Time.timeScale = 1f;
    }

    public void SaveOption()
    {
        optionWindow.SetActive(false);
        pauseWindow.SetActive(true);
    }


    public void NextLevel(string nextLevel)
    {
        StartCoroutine(ClickNextLevel());
        SceneManager.LoadScene(nextLevel);
        Time.timeScale = 1f;
        pc.enabled = true;
    }

    IEnumerator ClickNextLevel()
    {
        // need to rework this function so that audio doesnt reset back to 1 when clicking next Level
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Level reloaded");
    }
}
