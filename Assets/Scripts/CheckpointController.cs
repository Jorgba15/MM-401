using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckpointController : MonoBehaviour
{
    // declares gameobjects for each checkpoint, to be assigned in inspector
    public GameObject Checkpoint1;
    public GameObject Checkpoint2;
    public GameObject Checkpoint3;
    public GameObject Checkpoint4;
    public GameObject CheckpointFinal;

    // Endscreen to show after race ends
    public GameObject EndScreen;

    // add variables to keep track of player progress
    public int currentCheckPoint = 0;
    public int currentLap = 1;
    public int maxCheckpoints = 5; 
    public int race = 3;

    public float completionTime = 0;

    // UI timer
    void Update() {
        float currentTime = Time.time;
        GameObject.Find("TimerTime").GetComponent<TextMeshProUGUI>().text = currentTime.ToString("f");
    }

    // checkpoints activation, update checkpoint and lap counters 
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        { 
            int CheckPoints = other.gameObject.GetComponent<ReceivePoints>().CheckPoint;
            currentCheckPoint += CheckPoints;

            GameObject.Find("CheckCounter").GetComponent<TextMeshProUGUI>().text = currentCheckPoint.ToString();

            other.gameObject.SetActive(false);

            if (currentCheckPoint == maxCheckpoints) 
            {
                Checkpoint1.SetActive(true);
                Checkpoint2.SetActive(true);
                Checkpoint3.SetActive(true);
                Checkpoint4.SetActive(true);
                    
                currentCheckPoint -= maxCheckpoints;
                currentLap += 1;
                GameObject.Find("LapCounter").GetComponent<TextMeshProUGUI>().text = currentLap.ToString();    
            }    

            if (currentCheckPoint == maxCheckpoints -1)
            {
                CheckpointFinal.SetActive(true);
            }

            if (currentLap > 1 && currentCheckPoint > 3) 
            {
                CheckpointFinal.SetActive(true);
            }

            if (currentLap > race) 
            {
                float result = Time.time;
                completionTime = result;
                EndScreen.SetActive(true);
                GameObject.Find("RaceTime").GetComponent<TextMeshProUGUI>().text = completionTime.ToString();
                Time.timeScale = 0f;
            }
        }
    }
}
