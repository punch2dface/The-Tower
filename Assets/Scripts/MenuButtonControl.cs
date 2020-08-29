using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour
{
    public GameObject optionWindow;
    public GameObject startBtn;
    public GameObject optionBtn;
    public GameObject quitBtn;

    public void StartButton(string startScene)
    {
        SceneManager.LoadScene(startScene);
    }

    public void OptionButton()
    {
        optionWindow.SetActive(true);
        startBtn.SetActive(false);
        optionBtn.SetActive(false);
        quitBtn.SetActive(false);
    }

    public void QuitButton()
    {
        Debug.Log("Game has been exited");
        Application.Quit();
    }

    public void OptionSaveButton()
    {
        optionWindow.SetActive(false);
        startBtn.SetActive(true);
        optionBtn.SetActive(true);
        quitBtn.SetActive(true);
        Debug.Log("Option Selection has been Saved");
    }
}
