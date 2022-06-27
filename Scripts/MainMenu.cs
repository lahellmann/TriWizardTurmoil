using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// add SceneManager
using UnityEngine.SceneManagement;
using Random = System.Random;

public class MainMenu : MonoBehaviour
{
    bool firstPerson;
    Random num = new Random();
    // Script controlling the entire Main Menu:
    void Start()
    {
        int toBo = num.Next(2);
        if(toBo == 2)
        {
            firstPerson = false;
        }
        else
        {
            firstPerson = true;
        }
    }


    // Play button:
    public void Play()
    {
        if (firstPerson)
        {
            SceneManager.LoadScene("LabyrinthFP");
        }
        else
        {
            SceneManager.LoadScene("LabyrinthTP");
        }
        
    }

    public void Quit()
    {
        Debug.Log("Game has been quit!");
        Application.Quit();
    }

    public void SetFirstPerson()
    {
        firstPerson = true;
    }
    public void setThirdPerson()
    {
        firstPerson = false;
    }
}
