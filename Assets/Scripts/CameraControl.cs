using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera Control Script
/// Follows player vertical movement. However it only goes up not down.
/// </summary>
public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public float maxPlayerHeight;

    // Start is called before the first frame update
    void Start()
    {
        //cam.transform.position = player.transform.position;
        maxPlayerHeight = player.transform.position.y;
        transform.position = new Vector3(0, maxPlayerHeight, -1);
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelButtonControl.retryGame == true)
        {
            maxPlayerHeight = player.transform.position.y;
            transform.position = new Vector3(0, maxPlayerHeight, 0);
            LevelButtonControl.retryGame = false;
        }
        if(player.transform.position.y > maxPlayerHeight)
        {
            maxPlayerHeight = player.transform.position.y;
            transform.position = new Vector3(0, maxPlayerHeight, 0);
        }
    }
}
