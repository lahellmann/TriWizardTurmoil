using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public MainMenu mainMenu;


    public void ThirdPersonMode()
    {
        mainMenu.setThirdPerson();
        mainMenu.Play();
    }

    // even though it is obsolete from the way the GameManager Script is handling the bool:
    public void FirstPersonMode()
    {
        mainMenu.SetFirstPerson();
        mainMenu.Play();
    }
    

}
