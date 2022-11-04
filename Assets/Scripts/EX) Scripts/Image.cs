using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image : MonoBehaviour
{
    public GameObject image;
    public AudioClip clip;
    AudioSource audioSource;
    GameObject Player;
    
    private void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
     
        image.SetActive(false);
    }

    void ShowImage()
    {
        image.SetActive(true);
        //Invoke("HideImage", 2f);
    }

    void HideImage()
    {
        image.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            // clip ������ ����
            audioSource.clip = clip;
            // ���� ũ��
            audioSource.volume = 1f;
            // �ݺ� ����
            audioSource.loop = false;
            // ����� ���Ұ�
            audioSource.mute = false;
            audioSource.PlayOneShot(clip);


            ShowImage();

            print("����");
        }

    }
}
