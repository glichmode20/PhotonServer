using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

// ���̷� �� -> �׸���ũ -> ����
// ������û ->
// �׸���ũ���� ������� �𿩾��� (��� ����� ���� : GameScene) ->  
// �� �̵� �Ϲ� ����


public class ConnectionManager : MonoBehaviourPunCallbacks
{

    // ���� ��ư
    public Button btnConnect;

    
    public void OnClickConnect()
    {
        // ���� ���� ��û
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    // ������ ���� ���� ������ ȣ��(Lobby �� ���� ���� ����)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        // �г��� ����

        // �κ� ���� ��û
        PhotonNetwork.JoinLobby();
    }

    // �κ� ���� ������ ȣ��
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        // LobbyScene �̵�
        PhotonNetwork.LoadLevel("LobbyScene");
    }


}
