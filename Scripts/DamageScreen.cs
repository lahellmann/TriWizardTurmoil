using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is supposed to be on the Screen telling the Player that he has taken damage. 
 * You can display and hide the Gameobject
 **/
public class DamageScreen : MonoBehaviour
{
    // display damageUI:
    public void DisplayDamageUI()
    {
        gameObject.SetActive(true);
    }

    public void RemoveDamageUI()
    {
        gameObject.SetActive(false);
    }
}
