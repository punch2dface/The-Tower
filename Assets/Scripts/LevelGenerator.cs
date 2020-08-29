using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platform;
    public GameObject goal;

    public int numOfPlatform;
    public float horizontalRange;
    public int startingYPos = 0;
    public int lastPlatformYPos;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numOfPlatform; i++)
        {
            horizontalRange = Random.Range(-1.4f, 1.4f);
            startingYPos += 4;
            Instantiate(platform, new Vector3(horizontalRange, startingYPos, 1), Quaternion.identity);
        }
        lastPlatformYPos = startingYPos + 4;
        Instantiate(goal, new Vector3(Random.Range(-1.4f, 1.4f), lastPlatformYPos, 1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
