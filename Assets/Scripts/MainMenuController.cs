using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject SettingsPanel;
    public Text highscoreNumber;

    public AudioSource myMusic;
    public Slider volume;
    public Button musicBtn;
    public Sprite[] musicSprites;

    private void Start()
    {
        highscoreNumber.text = "" + PlayerPrefs.GetInt("highscoreNumber").ToString();
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void SetUpSlider()
    {
        myMusic.volume = volume.value;
    }

    public void MusicButton()
    {
        if (!myMusic.isPlaying)
        {
            myMusic.Play();
            musicBtn.image.sprite = musicSprites[0];
        }

        else
        {
            myMusic.Stop();
            musicBtn.image.sprite = musicSprites[1];
        }
    }

    public void SettingsButton()
    {
        SettingsPanel.SetActive(true);
    }

    public void ExitBtn()
    {
        Application.Quit();
        print("safsdgfsdg");
    }

    public void ResetBtn()
    {
        PlayerPrefs.DeleteKey("highscoreNumber");
        highscoreNumber.text = "0";
    }
}
