using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Config : MonoBehaviour
{
    public static string nicknamestr;
    public TMP_Text nickname;
    public float timer = 30;
    public TMP_Text textotiempo;
    public GameObject panelTiempo;
    public AudioSource gameOverSonido;
    private float contador = 0;

    // Start is called before the first frame update
    void Start()
    {
        nickname.text = "Jugador: " + nicknamestr;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Debug.Log(contador);

        if (textotiempo.text == "0")
        {
            gameOverSonido.Play();
            SceneManager.LoadScene(0);
        }

        if (panelTiempo.activeSelf == true)
        {

            timer -= Time.deltaTime;
            textotiempo.text = "" + timer.ToString("f0");
        }

    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

}
