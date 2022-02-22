using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public Text comboText;
    public float timer = 0;
    public float comboTimer = 8f;
    public int combo = 0;

    public Text feverText;
    public float feverMax = 10f;
    public float feverTime = 0;

    public bool feverEnabled = false;
    public bool feverUsed = false;

    public bool is_ended = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score\t: " + score.ToString();
        comboText.text = "Combo\t: " + combo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (combo > 0)
        {
            timer += Time.deltaTime;

            if (timer > comboTimer)
            {
                timer = 0;
                combo = 0;
                comboText.text = "Combo\t: " + combo.ToString();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !feverEnabled)
        {
            feverEnabled = true;
            feverUsed = true;
            feverText.gameObject.SetActive(true);
        }

        if (feverEnabled)
        {
            feverTime += Time.deltaTime;

            if (feverTime > feverMax)
            {
                feverEnabled = false;
                feverText.gameObject.SetActive(false);
            }
        }
    }

    public void EndGame()
    {
        is_ended = true;
    }

    public void AddPoint(int point)
    {
        if (!is_ended)
        {
            timer = 0;
            combo++;
            score += point * combo;
            if (feverEnabled) score *= 2;
            scoreText.text = "Score\t: " + score.ToString("#,0.###");
            comboText.text = "Combo\t: " + combo.ToString();
        }
    }

    public void ScoreReset()
    {
        score = 0;
        combo = 0;
        timer = 0;
        feverTime = 0;
        feverEnabled = false;
        feverUsed = false;

        scoreText.text = "Score\t: " + score.ToString("#,0.###");
        comboText.text = "Combo\t: " + combo.ToString();
    }
}
