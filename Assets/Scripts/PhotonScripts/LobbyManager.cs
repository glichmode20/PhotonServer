using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    // �� �̸�
    public InputField inputRoomName;

    // ���� ��ư
    //public Button btnCreate;

    public Button btnJoin;

    // �� ��� Content
    public Transform roomListContent;
    // ����� ����
    Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();
    // ������ ������ Prefab
    // public GameObject roomItemFactory;

    void Start()
    {
        // ���̸�(InputField)�� ����ɶ� ȣ��Ǵ� �Լ� ���
       // inputRoomName.onValueChanged.AddListener(OnRoomNameValueChanged);
    }

    //public void OnRoomNameValueChanged(string room)
    //{
    //    //����
    //    btnJoin.interactable = room.Length > 0;
  
    //}

    // �� ��� Content
    public void OnClickCreate()
    {
        // Ŭ���� �� ����
        CreateRoom();
    }

    public void OnClickJoin()
    {
        JoinRoom();
    }

    public void CreateRoom()
    {
        // �� �ɼ��� ����
        RoomOptions roomOptions = new RoomOptions();

        // �ִ� �ο� 10��
        roomOptions.MaxPlayers = 10;

        // �� ����Ʈ�� ������ �ʰ� / ���̰�
        roomOptions.IsVisible = true;

        // �� ���� ��û(�ش� �ɼ� �̿�)
        PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);

    } 

    // ���� �����Ǹ� ȣ�� �Ǵ� �Լ�
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();

        print("OnCreatedRoom");

    }

    // �� ������ ���� �� �� ȣ�� �Ǵ� �Լ�
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);

        print("OnCreateRoomFailed , " + returnCode + ", " + message);

        //JoinRoom();
    }

    // �� ���� ��û
    public void JoinRoom()
    {
        // ���� �ϳ��� ����?
        PhotonNetwork.JoinRoom(inputRoomName.text);
        
    }       

    
    //+ �� ������ �Ϸ� �Ǿ��� �� ȣ�� �Ǵ� �Լ�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        print("OnJoinedRoom");

        if(inputRoomName.text == "���̴� ���")
        {
             PhotonNetwork.LoadLevel("Photon");
        }
        else if(inputRoomName.text == "���� ����")
        {
            PhotonNetwork.LoadLevel("Photon2");
        }


    }

    //+ �� ������ ���� �Ǿ��� �� ȣ�� �Ǵ� �Լ�
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + message);
        // �� ������ �����ϸ� �ڵ����� �� �����
        CreateRoom();
    }

    //�濡 �÷��̾ ���� ���� �� ȣ�����ִ� �Լ�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print(newPlayer.NickName);
    }

    //�� ����� ���� �Ǿ��� �� (����, ����, ���� ����) ȣ�� ���ִ� �Լ�
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        // �븮��Ʈ ���� ����
        UpdateRoomCache(roomList);
    }

    private void UpdateRoomCache(List<RoomInfo> roomList)
    {

        for (int i = 0; i < roomList.Count; i++)
        {
            // ����, ����
            if (roomCache.ContainsKey(roomList[i].Name))
            {
                //���࿡ �ش� ���� �����Ȱ��̶��
                if (roomList[i].RemovedFromList)
                {
                    //roomCache ���� �ش� ������ ����
                    roomCache.Remove(roomList[i].Name);
                }
                //�׷��� �ʴٸ�
                else
                {
                    //���� ����
                    roomCache[roomList[i].Name] = roomList[i];
                }
            }
            //�߰�
            else
            {
                roomCache[roomList[i].Name] = roomList[i];
            }
        }
    }

}
