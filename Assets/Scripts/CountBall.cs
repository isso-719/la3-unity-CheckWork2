using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBall : MonoBehaviour
{
    public int ballID;
    public int countID;
    public static int countStartID;

    public Texture[] textures;
    public string[] tags;

    public ParticleSystem temuParticle;

    public static bool isConnecting;
    public bool isGenerated;

    Renderer temurenderer;

    public GameObject ballManager;
    public GameObject uiManager;

    int point = 100;

    // Start is called before the first frame update
    void Start()
    {
        ballManager = GameObject.Find("BallManager");
        uiManager = GameObject.Find("UIManager");

        temurenderer = GetComponent<Renderer>();
        tags = new string[] { "red", "blue", "yellow" };
    }

    // Update is called once per frame
    void Update()
    {
        if (isGenerated == false)
        {
            int randomCount = Random.Range(0, 3);
            tag = tags[randomCount];
            temurenderer.material.mainTexture = textures[randomCount];
            countID = randomCount;
            gameObject.transform.parent = null;

            isGenerated = true;
        }
    }

    private void OnMouseDown()
    {
        countStartID = countID;
        ballManager.gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.parent = ballManager.gameObject.transform;
        isConnecting = true;
        temuParticle.Play();
    }

    private void OnMouseOver()
    {
        if (isConnecting == true && countStartID == countID)
        {
            gameObject.transform.parent = ballManager.gameObject.transform;
            temuParticle.Play();
        } else if (countStartID != countID)
        {
            isConnecting = false;
        }
    }

    private void OnMouseUp()
    {
        if (ballManager.gameObject.transform.childCount >= 4)
        {
            int addScore = point * ballManager.gameObject.transform.childCount;
            uiManager.SendMessage("AddPoint", addScore);

            ballManager.transform.position = new Vector3(0, 20f, 0);

            for (int i = 0; i < ballManager.gameObject.transform.childCount; i++)
            {
                CountBall countBall = ballManager.transform.GetChild(i).GetComponent<CountBall>();
                countBall.isGenerated = false;
            }

            for (int i = 0; i < ballManager.gameObject.transform.childCount; i++)
            {
                ballManager.transform.GetChild(i).GetComponent<CountBall>().temuParticle.Stop();
            }

            isConnecting = false;
            ballManager.gameObject.transform.DetachChildren();
        }
    }
}
