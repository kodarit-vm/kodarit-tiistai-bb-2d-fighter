using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] playerPrefabs;

    private float posY = -2f;
    private float player1xPos = -5f;
    private float player2xPos = 5f;

    private Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            spawnPos = new Vector2(player1xPos, posY);
        } else
        {
            spawnPos = new Vector2(player2xPos, posY);
        }
        PhotonNetwork.Instantiate(playerPrefabs[0].name, spawnPos, Quaternion.identity);
    }
}
