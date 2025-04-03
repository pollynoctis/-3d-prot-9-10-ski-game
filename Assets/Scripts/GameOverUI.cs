using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Image overlay;
    [SerializeField] private int nextLevelIndex = 1;

    private void Start()
    {
        overlay.CrossFadeAlpha(0,0.9f, true);
        gameOverScreen.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.raceFinish += EnableFinishUI;
        GameManager.gameQuit += Quit;
    }

    private void OnDisable()
    {
        GameManager.raceFinish -= EnableFinishUI;
        GameManager.gameQuit -= Quit;
    }
    
    private void EnableFinishUI()
    {
        gameOverScreen.SetActive(true);
    }
    

    private IEnumerator RestartCoroutine()
    {
        overlay.CrossFadeAlpha(1,1,true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator NextLevelCoroutine()
    {
        overlay.CrossFadeAlpha(1,1,true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevelIndex);
    }
    private IEnumerator QuitCoroutine()
    {
        overlay.CrossFadeAlpha(1,1,true);
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
    
    private void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }
    
    
    //scripts for buttons
    public void GameQuit() 
    {
        GameManager.CallGameQuit();
    }
    public void RestartLevel()
    {
        StartCoroutine(RestartCoroutine());
    }
    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }
}
