using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class RoomItem : MonoBehaviour
{
    // 방정보 Text
    public Text roomInfo;

    // 클릭 되었을 때 호출되야 하는 함수를 담은 변수
    public Action<string> onClickAction;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetInfo(string roomName, int currPlayer, byte maxPlayer)
    {
        // 자신의 게임 오브젝트 이름을 roomName으로
        name = roomName;

        //방 정보 셋팅 방 이름(1/ 10)
        roomInfo.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")";
    }

    public void OnClick()
    {
        GameObject inputRoomName = GameObject.Find("InputRoomName");

        InputField input = inputRoomName.GetComponent<InputField>();
        input.text = name;
    }
}
