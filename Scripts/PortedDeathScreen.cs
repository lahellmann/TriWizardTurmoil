using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortedDeathScreen : MonoBehaviour
{

    // display GameOver:
    public void DisplayPortedDeath()
    {
        gameObject.SetActive(true);
    }

    // back to main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
