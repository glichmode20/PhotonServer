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
        // �÷��̾���� �Ÿ��� ����ؼ�
        float distance = Vector3.Distance(manager.player.transform.position, transform.position);
        
        // �÷��̾ ���� ��ó�� �ִٸ�
        if(distance < maxDistance && count < maxcount)
        {
            // UI�� �Ҵ�
            UICanvas.SetActive(true);
        }

    }

  

    public void ClickNextScene()
    {
        PhotonNetwork.Destroy(manager.player);
        PhotonNetwork.LoadLevel("FinalGameScene");
    }

 
}
