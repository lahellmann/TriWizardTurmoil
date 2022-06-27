using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabChangeScreen : MonoBehaviour
{
    // display LabChangeUI:
    public void DisplayLabChangeUI()
    {
        gameObject.SetActive(true);
    }

    // remove it again:
    public void RemoveLabChangeUI()
    {
        gameObject.SetActive(false);
    }
}
