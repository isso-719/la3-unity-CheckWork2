using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timerText;
    public float timerMax = 60f;
    float timer;
    bool timerEnabled = false;
    public UIManager uiManager;

    public GameObject retryButton;

    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);
        timer = timerMax;
        timerEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerEnabled == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                retryButton.SetActive(true);
                timerEnabled = false;
                timer = timerMax;
                uiManager.is_ended = true;
            }

            timerText.text = "Time\t: " + timer.ToString("F1") + "s";
        }


    }

    public void Retry()
    {
        retryButton.SetActive(false);
        timerEnabled = true;
        uiManager.ScoreReset();
        uiManager.is_ended = false;
    }
}
