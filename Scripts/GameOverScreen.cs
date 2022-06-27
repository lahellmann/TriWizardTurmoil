using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public MoveMaze innermaze;
    public EnemyController enemy;


    // display GameOver:
    public void DisplayGameOver()
    {
        gameObject.SetActive(true);
    }

    // restart the game properly:
    public void RestartGame()
    {
        innermaze.ResetMaze();
        enemy.ResetEnemy();
        Debug.Log("Restart game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
