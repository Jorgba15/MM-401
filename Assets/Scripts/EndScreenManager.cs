using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    [Header("Finishscreen")]
    public GameObject EndScreen;

    public void ShowEndScreen() 
    {
    EndScreen.SetActive(true);
    }

}


