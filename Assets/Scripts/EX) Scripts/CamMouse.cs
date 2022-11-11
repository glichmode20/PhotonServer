using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CamMouse : MonoBehaviourPun
{
    float rotX;
    float rotY;

    float rotSpeed = 200f;
    

    [SerializeField]
    Transform Campos;

    // Start is called before the first frame update
    void Start()
    {
        //만약에 내것이라면
        if (photonView.IsMine == true)
        {
            //camPos를 활성화
            Campos.gameObject.SetActive(true);
            AudioListener.volume = 1;
        }
        else if(photonView.IsMine == false)
        {
            Campos.gameObject.SetActive(false);
            // 내거 아닌 오디오 리스너는 꺼버린다
            Campos.GetComponentInChildren<AudioListener>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false) return;

        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        rotX += rotSpeed * mx * Time.deltaTime;
        rotY += rotSpeed * my * Time.deltaTime;

        rotY = Mathf.Clamp(rotY, -80, 80);

        transform.localEulerAngles = new Vector3(0, rotX, 0);
        Campos.localEulerAngles = new Vector3(-rotY, 0, 0);


    }
}
