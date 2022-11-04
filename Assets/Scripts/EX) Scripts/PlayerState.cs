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
        // ���� ���¿� s�� ������ �Լ� ������
        if (currState == s) return;

        // ���� ���¸� s ���·�
        currState = s;
        // ���¿� ���� animation ó��
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
