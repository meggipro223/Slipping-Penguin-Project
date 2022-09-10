using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    [SerializeField]
    private GameObject PausePanel;

	public void PauseButton()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
}
