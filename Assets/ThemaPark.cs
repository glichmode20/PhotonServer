using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ThemaPark : MonoBehaviourPunCallbacks
{
    public GameObject eManager;
    E_GameManager EManager;

    private void Start()
    {
        Cursor.visible = true;

        EManager = eManager.GetComponent<E_GameManager>();
    }

    public void GoThemaPark()
    {
        print("join");

        Cursor.visible = true;
        PhotonNetwork.JoinLobby();
        print("join1");
        EManager.returnRoomName = "±ØÇÑ Á÷¾÷";
    }
 
}
