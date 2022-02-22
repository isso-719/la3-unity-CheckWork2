using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBall : MonoBehaviour
{
    public GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 position = new Vector3(Random.Range(-2f, 2f), Random.Range(30f, 50f), 0);
            Instantiate(clone.gameObject, position, Quaternion.Euler(90, 0, 0));

            clone.GetComponent<CountBall>().ballID = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
