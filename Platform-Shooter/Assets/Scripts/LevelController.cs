using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int mainMenuIndex;
    public string deathMenuName;
    public int currentLevel;
    public int nextLevelIndex;
    public int firstLevel;
    private Player player;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void Respawn()
    {
        player.rb.position = player.startPosition;

    }

    public void Reload()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void NextLevel()
    {
        Debug.Log("Go To Level" + nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }
    public void DeathMenu()
    {
        SceneManager.LoadScene(deathMenuName);
    }

}
