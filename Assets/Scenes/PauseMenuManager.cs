using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
        float value = PlayerPrefs.GetFloat(AudioManager.VOLUME_LEVEL_KEY, AudioManager.DEFAULT_VOLUME);
        pausePanel.GetComponentInChildren<Slider>().value = value;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void CloseMenu(){
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void ExitGame(){
        Application.Quit();
    }
}
