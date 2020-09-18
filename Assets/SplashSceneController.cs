using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text splashText;

    void Start()
    {
        Color c = splashText.color;
        c.a = 0f;
        splashText.color = c;
        StartCoroutine(SplashTextFadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        //SceneManager.LoadScene("MenuScene");
    }

    IEnumerator SplashTextFadeIn()
    {
        for (float f = 0.0f; f <= 1; f += 0.05f)
        {
            Color c = splashText.color;
            c.a = f;
            splashText.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2.0f);

        for (float f2 = 1.0f; f2 >= 0; f2 -= 0.05f)
        {
            Color c2 = splashText.color;
            c2.a = f2;
            splashText.color = c2;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MenuScene");
    }
}
