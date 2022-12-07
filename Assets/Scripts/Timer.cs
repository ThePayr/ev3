using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Vuforia;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 30;
    public TMP_Text textotiempo;
    public GameObject panelTiempo;
    public AudioSource gameOverSonido;
    void Update()
    {
        timer -= Time.deltaTime;
        textotiempo.text = "" + timer.ToString("f0");


        if (timer < 0)
        {
            gameOverSonido.Play();
            StartCoroutine(SceneLoadWithDelay(0, 4));
        }


    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    IEnumerator SceneLoadWithDelay(int sceneNum, int numSeconds)
    {
        yield return new WaitForSeconds(numSeconds);

        SceneManager.LoadScene(sceneNum);
    }
}
