using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CamMouse : MonoBehaviourPun
{
    float wheelValue = 0;

    Vector3 nearPosition;
    Vector3 farPosition;


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

            //nearPosition = Campos.transform.position;

        }
        else if(photonView.IsMine == false)
        {
            Campos.gameObject.SetActive(false);
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


        //farPosition = nearPosition + (Campos.transform.forward * -5);

        //wheelValue -= Input.GetAxis("Mouse ScrollWheel");
        //wheelValue = Mathf.Clamp(wheelValue, 0, 1.0f);

        //Vector3 CamPosition = Vector3.Lerp(nearPosition, farPosition, wheelValue);

        //Campos.transform.Position = CamPosition;

    }
}
