using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerobject : MonoBehaviour
{
    //public int playernum;
    public GameObject playerContainer;
    private GameObject playerObject;

    public void GetPlayerPrefabs()
    {
        string selectplayer = PlayerPrefs.GetString("selectPlayer");
        GameObject Prefsload = Resources.Load<GameObject>(selectplayer);

        if (Prefsload != null && playerContainer != null)
        {

            Destroy(playerObject);

            GameObject player = Instantiate(Prefsload, playerContainer.transform.position, Quaternion.identity);
            player.transform.parent = playerContainer.transform;

            playerObject = player;
        }
    }

    void Awake()
    {
        GetPlayerPrefabs();
    }
}
