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
        StartCoroutine(MoveToLevelScene(startScene));
    }

    private IEnumerator MoveToLevelScene(string startScene)
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(startScene);
    }

    public void OptionButton()
    {
        StartCoroutine(ClickOptionButton());
    }

    IEnumerator ClickOptionButton()
    {
        yield return new WaitForSeconds(0.4f);
        optionWindow.SetActive(true);
        startBtn.SetActive(false);
        optionBtn.SetActive(false);
        quitBtn.SetActive(false);
    }

    public void QuitButton()
    {
        StartCoroutine(ClickQuitButton());
    }

    IEnumerator ClickQuitButton()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Game has been exited");
        Application.Quit();
    }

    public void OptionSaveButton()
    {
        StartCoroutine(ClickSaveButton());
    }

    IEnumerator ClickSaveButton()
    {
        yield return new WaitForSeconds(0.4f);
        optionWindow.SetActive(false);
        startBtn.SetActive(true);
        optionBtn.SetActive(true);
        quitBtn.SetActive(true);
        Debug.Log("Option Selection has been Saved");
    }
}
