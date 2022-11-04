using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class RoomItem : MonoBehaviour
{
    // ������ Text
    public Text roomInfo;

    // Ŭ�� �Ǿ��� �� ȣ��Ǿ� �ϴ� �Լ��� ���� ����
    public Action<string> onClickAction;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetInfo(string roomName, int currPlayer, byte maxPlayer)
    {
        // �ڽ��� ���� ������Ʈ �̸��� roomName����
        name = roomName;

        //�� ���� ���� �� �̸�(1/ 10)
        roomInfo.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")";
    }

    public void OnClick()
    {
        GameObject inputRoomName = GameObject.Find("InputRoomName");

        InputField input = inputRoomName.GetComponent<InputField>();
        input.text = name;
    }
}
