using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("NickName")]
    public TMP_InputField nickname;
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject nicknamePanel;
    public GameObject errorPanel;

    private void Awake()
    {
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    public void PlayLevel(string levelName)
    {

        Config.nicknamestr = nickname.text;
        if(string.IsNullOrEmpty(nickname.text))
        {
            OpenPanel(errorPanel);
        }
        else SceneManager.LoadScene(levelName);
    }

    public void ExitGame()
    { 
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void SetMute()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        }
        else
            mixer.SetFloat("VolMaster", lastVolume);
    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        nicknamePanel.SetActive(false);
        errorPanel.SetActive(false);
        panel.SetActive(true);
        PlaySoundButton();
    }

    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }

    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }

    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("VolFX", v);
    }

}
