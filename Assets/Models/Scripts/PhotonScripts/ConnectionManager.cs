using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

// 마이룸 씬 -> 테마파크 -> 게임
// 서버요청 ->
// 테마파크에선 사람들이 모여야함 (배운 내용과 유사 : GameScene) ->  
// 방 이동 일반 게임


public class ConnectionManager : MonoBehaviourPunCallbacks
{

    // 접속 버튼
    public Button btnConnect;

    
    public void OnClickConnect()
    {
        // 서버 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    // 마스터 서버 접속 성공시 호출(Lobby 에 진입 가능 상태)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        // 닉네임 설정

        // 로비 진입 요청
        PhotonNetwork.JoinLobby();
    }

    // 로비 진입 성공시 호출
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        // LobbyScene 이동
        PhotonNetwork.LoadLevel("LobbyScene");
    }


}
