using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    public Image Fader;
    public Text PlayerHealth;
    public Text PlayerLives;
    public GameObject MainMenu;
    public GameObject Game;
    public GameObject GameOver;
    public GameObject Victory;
    public GameObject Defeat;

    private void Awake()
    {
        Events.LevelCompleteFade.AddListener(UIFade);
        Events.PlayerHealthChanged.AddListener(UpdatePlayerHealth);
        Events.PlayerLivesChanged.AddListener(UpdatePlayerLives);
        Events.GameOver.AddListener(GameOverDefeat);
        Events.GameWin.AddListener(GameOverVictory);
    }

    void UIFade()
    {
        StartCoroutine("Fade");
    } 

    void UpdatePlayerHealth(int amount)
    {
        PlayerHealth.text = "Health: " + amount.ToString();
    }

    void UpdatePlayerLives(int amount)
    {
        PlayerLives.text = "Lives: " + amount.ToString();
    }

    IEnumerator Fade()
    {
        while(Fader.color.a < 1)
        {
            Fader.color += new Color(0, 0, 0, .15f);
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(FadeBack());
        yield return null;
    }

    IEnumerator FadeBack()
    {
        yield return new WaitForSeconds(2.0f);
        while (Fader.color.a > 0)
        {
            Fader.color -= new Color(0, 0, 0, .15f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;        
    }

    public void CloseApplication()
    {
        Application.Quit();        
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        Game.SetActive(true);
        Events.StartLevel.Invoke();
    }

    public void ReloadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    
    public void GameOverDefeat()
    {
        GameOver.SetActive(true);
        Defeat.SetActive(true);
    }

    public void GameOverVictory()
    {
        GameOver.SetActive(true);
        Victory.SetActive(true);
    }
}
