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
            // clip 파일을 실행
            audioSource.clip = clip;
            // 사운드 크기
            audioSource.volume = 1f;
            // 반복 여부
            audioSource.loop = false;
            // 오디오 음소거
            audioSource.mute = false;
            audioSource.PlayOneShot(clip);


            ShowImage();

            print("실행");
        }

    }
}
