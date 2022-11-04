using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviourPun
{
    PhotonGameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<PhotonGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.gameObject.tag == "PTPlayer")
            {
                print("sfadsddasdasas");
                PhotonNetwork.Destroy(manager.player);

                PhotonNetwork.LoadLevel("FinalGameScene");
                //SceneManager.LoadScene("FinalGameScene");

            }
        }
    }

}
