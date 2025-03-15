using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    
    void Update()
    {
        this.transform.position = new Vector3( player.transform.position.x+3, player.transform.position.y,-10);
    }
}
