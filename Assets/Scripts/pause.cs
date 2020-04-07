using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    public Sprite pauseconfirm;
    public Sprite pausenormal;
    public bool quitconf;
    void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
                pausePanel.GetComponent<Image>().sprite = pausenormal;
            }
            else if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
                quitconf = false;
            }
        }
        if (quitconf == false && Input.GetKeyUp(KeyCode.Space) && pausePanel.activeInHierarchy)
        {
            quitconf = true;
            pausePanel.GetComponent<Image>().sprite = pauseconfirm;
        }
        if (quitconf == true && Input.GetKeyDown(KeyCode.Space) && pausePanel.activeInHierarchy)
        {
            quitconf = false;
            SceneManager.LoadScene(0);
        }
    }
    private void PauseGame()
    {
        PlayerPrefs.SetInt("pauses", PlayerPrefs.GetInt("pauses", 0) + 1);
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
}