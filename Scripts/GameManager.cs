using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // in order to only the end game once!
    bool gameHasEnded = false;

    // game control variable:
    public bool thirdPersonMode = false;

    public float restartDelay = 10f;

    public GameOverScreen GameOverScreen;


    public void GameOver()
    {
        if (!gameHasEnded)
        {
            // adjust the variables:
            gameHasEnded = true;
            Debug.Log("GAMEOVER");
            // load the Game Over Screen:
            GameOverScreen.DisplayGameOver();
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void SetToThirdPerson()
    {
        thirdPersonMode = true;
    }

    public void SetToFirstPerson()
    {
        thirdPersonMode = false;
    }

}
