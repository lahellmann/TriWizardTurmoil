using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public CharacterController controller;
    public GameObject Result;
    // Start is called before the first frame update
    void Start()
    {
        Result.SetActive(false);
    }
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Result.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        Result.SetActive(false);
    }
}
