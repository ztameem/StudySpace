using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    public TextMeshPro countdownTextMeshPro;
    public float countdownTime = 60f;
    public string nextSceneName = "NextScene"; 
    public bool useDoubleDigitMinutes = true;

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
        UpdateCountdownText();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();
        }
        else
        {
            SwitchToNextScene();
        }
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        if (useDoubleDigitMinutes)
        {
            countdownTextMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            countdownTextMeshPro.text = string.Format("{0}:{1:00}", minutes, seconds);
        }
    }

    void SwitchToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
