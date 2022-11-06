using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image : MonoBehaviour
{
    public GameObject image;
    public GameObject Nextimage;
    public AudioClip clip;
    AudioSource audioSource;
    GameObject Player;


    public int count = 0;
    int maxcount = 1;

    private void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
     
        //image.SetActive(false);
    }

    void ShowImage()
    {
        image.SetActive(true);
        Invoke("HideImage", 4f);
    }

    void HideImage()
    {
        Nextimage.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && count < maxcount)
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

            count++;

            ShowImage();

            print("실행");
        }
        else if(count < maxcount)
        {
            count = 0;
        }

    }
}
