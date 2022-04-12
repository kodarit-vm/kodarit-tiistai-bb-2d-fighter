using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] playerPrefabs;

    private float posY = 0f;
    private float player1xPos = -5f;
    private float player2xPos = 5f;

    private Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
