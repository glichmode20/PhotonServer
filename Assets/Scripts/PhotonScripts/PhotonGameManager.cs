using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PhotonGameManager : MonoBehaviourPun, IPunObservable
{
   public Transform PlayerSpwan;
   public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = PhotonNetwork.Instantiate("Player", PlayerSpwan.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�濡 �÷��̾ ���� ���� �� ȣ�����ִ� �Լ�
    //public override void OnPlayerEnteredRoom(Player newPlayer)
    //{
    //    base.OnPlayerEnteredRoom(newPlayer);
    //    print(newPlayer);
    //}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }

   
}
