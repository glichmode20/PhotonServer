using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerState : MonoBehaviourPun
{
    //FSM
    public enum State
    {
        Idle,
        Move,
    }

    public State currState;
    public Animator anim;


    public void ChangeState(State s)
    {
        // 현재 상태와 s와 같으면 함수 나가기
        if (currState == s) return;

        // 현재 상태를 s 상태로
        currState = s;
        // 상태에 따라서 animation 처리
        switch (s)
        {
            case State.Idle:
                photonView.RPC("RpcSetTrigger", RpcTarget.All, "Idle");
                break;
            case State.Move:
                photonView.RPC("RpcSetTrigger", RpcTarget.All, "Move");
                break;

        }

     
    }

    [PunRPC]
    void RpcSetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }
}
