using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviourPun
{
    PhotonGameManager manager;
 
    [SerializeField]
    int count = 0;

    int maxCount = 1;

    [SerializeField]
    GameObject OptionImage;
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

        PhotonView photonView = other.GetComponent<PhotonView>();

        if (count < maxCount && photonView != null && photonView.IsMine)
        {
            count++;
            OptionImage.SetActive(true);
        }
        else
        {
            count = 0;
        }
    }

    public void nextScene()
    {
      
        PhotonNetwork.Destroy(manager.player);
        // PhotonNetwork.LoadLevel("FinalGameScene");
        SceneManager.LoadScene("FinalGameScene");


    }

}
