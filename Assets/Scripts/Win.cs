using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public bool ganar = false;
    public AudioSource winnerSonido;
    void OnTriggerEnter(Collider other)
    {
        ganar = true;
        winnerSonido.Play();
        StartCoroutine(SceneLoadWithDelay(0, 4));
    }
    IEnumerator SceneLoadWithDelay(int sceneNum, int numSeconds)
    {
        yield return new WaitForSeconds(numSeconds);

        SceneManager.LoadScene(sceneNum);
    }
}
