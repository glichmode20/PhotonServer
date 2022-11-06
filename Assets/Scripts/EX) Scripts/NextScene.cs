using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviourPun
{
    public GameObject UICanvas;

    public int count = 0;
    int maxcount = 1;

    PhotonGameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        UICanvas.SetActive(false);

        manager = GameObject.Find("GameManager").GetComponent<PhotonGameManager>();
    }

    float maxDistance = 10f;
    
    private void Update()
    {
        // 플레이어와의 거리를 계산해서
        float distance = Vector3.Distance(manager.player.transform.position, transform.position);
        
        // 플레이어가 가게 근처에 있다면
        if(distance < maxDistance && count < maxcount)
        {
            // UI를 켠다
            UICanvas.SetActive(true);
        }

    }

  

    public void ClickNextScene()
    {
        PhotonNetwork.Destroy(manager.player);
        PhotonNetwork.LoadLevel("FinalGameScene");
    }

 
}
