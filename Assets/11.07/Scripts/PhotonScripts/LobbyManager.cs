using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    // 방 이름
    public InputField inputRoomName;

    // 접속 버튼
    //public Button btnCreate;

    public Button btnJoin;

    // 방 목록 Content
    public Transform roomListContent;
    // 방들의 정보
    Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();
    // 방정보 아이템 Prefab
    // public GameObject roomItemFactory;

    void Start()
    {
        // 방이름(InputField)이 변경될때 호출되는 함수 등록
       // inputRoomName.onValueChanged.AddListener(OnRoomNameValueChanged);
    }

    //public void OnRoomNameValueChanged(string room)
    //{
    //    //참가
    //    btnJoin.interactable = room.Length > 0;
  
    //}

    // 방 목록 Content
    public void OnClickCreate()
    {
        // 클릭시 방 생성
        CreateRoom();
    }

    public void OnClickJoin()
    {
        JoinRoom();
    }

    public void CreateRoom()
    {
        // 방 옵션을 설정
        RoomOptions roomOptions = new RoomOptions();

        // 최대 인원 10명
        roomOptions.MaxPlayers = 10;

        // 룸 리스트에 보이지 않게 / 보이게
        roomOptions.IsVisible = true;

        // 방 생성 요청(해당 옵션 이용)
        PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);

    } 

    // 방이 생성되면 호출 되는 함수
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();

        print("OnCreatedRoom");

    }

    // 방 생성이 실패 될 때 호출 되는 함수
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);

        print("OnCreateRoomFailed , " + returnCode + ", " + message);

        //JoinRoom();
    }

    // 방 참가 요청
    public void JoinRoom()
    {
        // 방은 하나만 존재?
        PhotonNetwork.JoinRoom(inputRoomName.text);
        
    }       

    
    //+ 방 참가가 완료 되었을 때 호출 되는 함수
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        print("OnJoinedRoom");

        if(inputRoomName.text == "보이는 어둠")
        {
             PhotonNetwork.LoadLevel("Photon");
        }
        else if(inputRoomName.text == "극한 직업")
        {
            PhotonNetwork.LoadLevel("Photon2");
        }


    }

    //+ 방 참가가 실패 되었을 때 호출 되는 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + message);
        // 방 생성이 실패하면 자동으로 방 만들기
        CreateRoom();
    }

    //방에 플레이어가 참여 했을 때 호출해주는 함수
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print(newPlayer.NickName);
    }

    //방 목록이 변경 되었을 때 (생성, 삭제, 정보 갱신) 호출 해주는 함수
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        // 룸리스트 정보 갱신
        UpdateRoomCache(roomList);
    }

    private void UpdateRoomCache(List<RoomInfo> roomList)
    {

        for (int i = 0; i < roomList.Count; i++)
        {
            // 수정, 삭제
            if (roomCache.ContainsKey(roomList[i].Name))
            {
                //만약에 해당 룸이 삭제된것이라면
                if (roomList[i].RemovedFromList)
                {
                    //roomCache 에서 해당 정보를 삭제
                    roomCache.Remove(roomList[i].Name);
                }
                //그렇지 않다면
                else
                {
                    //정보 수정
                    roomCache[roomList[i].Name] = roomList[i];
                }
            }
            //추가
            else
            {
                roomCache[roomList[i].Name] = roomList[i];
            }
        }
    }

}
