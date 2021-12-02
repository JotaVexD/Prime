using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    protected AudioSource audioSource;
    public GameObject panel;
    public GameObject panelcredit;
    public GameObject panelHowToPlay;

    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void credits (){
        panel.SetActive(false);
        panelcredit.SetActive(true);
    }

    public void howToPlay (){
        panel.SetActive(false);
        panelHowToPlay.SetActive(true);
    }

    public void doExitGame() {
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Die() {
        SceneManager.LoadScene("GameOver");
    }
}
