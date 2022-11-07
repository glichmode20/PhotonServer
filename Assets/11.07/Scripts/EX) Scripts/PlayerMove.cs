using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class PlayerMove : MonoBehaviourPun, IPunObservable
{
    public enum State
    {
        Idle,
        Move,
    }
    public State m_state;

    float speed = 100;
    float yVelocity;

    public float gravity = -20f;

    CharacterController cc;
    PlayerState playerState;
    public Transform body;

    // ���� ��ġ
    Vector3 receivePos;
    //ȸ�� �Ǿ���ϴ� ��
    Quaternion receiveRot;
    //���� �ӷ�
    public float lerpSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {

        playerState = GetComponent<PlayerState>();
        cc = GetComponent<CharacterController>();
        body = transform.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        //���࿡ �����̶��
        if (photonView.IsMine)
        {
            switch (m_state)
            {
                case State.Idle:
                    UpdateIdle();
                    break;
                case State.Move:
                    UpdateMove();
                    break;
            }
        }
        //������ �ƴϸ�
        else
        {

            float t = Mathf.Clamp(Time.deltaTime * 10, 0f, 0.99f);
            //Lerp�� �̿��ؼ� ������, ����������� �̵� �� ȸ��
            transform.position = Vector3.Lerp(transform.position, receivePos, lerpSpeed * Time.deltaTime * t);
            transform.rotation = Quaternion.Lerp(transform.rotation, receiveRot, lerpSpeed * Time.deltaTime * t);
        }
    }
    private void UpdateIdle()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            m_state = State.Move;
            playerState.ChangeState(PlayerState.State.Move);

        }
    }
    private void UpdateMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        // ���� �Է��� ������ ���¸� Idle ���·� ��ȯ
        if (dir.magnitude <= 0)
        {
           playerState.ChangeState(PlayerState.State.Idle);
            
            m_state = State.Idle;
        }

        dir = Camera.main.transform.TransformDirection(dir);
        transform.forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);


        dir.y = yVelocity;
        cc.Move(dir * speed * Time.deltaTime);

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // ������ ������
        if (stream.IsWriting) // isMine == true;
        {
            //position, rotation
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        // ������ �ޱ�
        else if (stream.IsReading)
        {
            receivePos = (Vector3)stream.ReceiveNext();
            receiveRot = (Quaternion)stream.ReceiveNext();
        }
    }

}
