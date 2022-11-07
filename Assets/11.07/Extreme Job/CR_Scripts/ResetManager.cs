using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public GameObject manager;

    public GameObject fryer;
    public GameObject mixBoll;
    public GameObject ck;

    Fryer fryers;
    Mix mix;

    ChickenTrigger ct1;
    ChickenTrigger ct2;
    ChickenTrigger ct3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        manager.GetComponent<Fryer>().enabled = true;
        manager.GetComponent<Mix>().enabled = false;

        fryers = manager.GetComponent<Fryer>();
        mix = manager.GetComponent<Mix>();

        ct1 = fryers.ck1.GetComponent<ChickenTrigger>();
        ct2 = fryers.ck2.GetComponent<ChickenTrigger>();
        ct3 = fryers.ck3.GetComponent<ChickenTrigger>();

        mixBoll.SetActive(false);
        fryer.SetActive(true);
        // true
        fryers.isck1 = true;
        fryers.isck2 = true;
        fryers.isck3 = true;

        // false
        fryers.isckk1 = false;
        fryers.isckk2 = false;
        fryers.isckk3 = false;

        // true
        fryers.isMoveCk1 = true;
        fryers.isMoveCk2 = true;
        fryers.isMoveCk3 = true;

        fryers.is1Score = true;
        fryers.is2Score = true;

        fryers.isAllScore = true;
        fryers.isbollCheck = true;

        for (int i = 0; i < fryers.moveCKcheck.Length; i++)
        {
            //치킨 현재 모두 접시에 담겨있는 채로 시작
            fryers.moveCKcheck[i] = true;
        }

        for (int i = 0; i < mix.moveCKcheck.Length; i++)
        {
            //치킨 현재 모두 접시에 담겨있는 채로 시작
            mix.moveCKcheck[i] = true;

           
        }

        ct1.isFry1 = false;
        ct2.isFry2 = false;
        ct3.isFry3 = false;

        fryers.curTime1 = 0;

        // true
        mix.isCck1 = true;
        mix.isCck2 = true;
        mix.isCck3 = true;

        // true
        mix.isck1 = true;
        mix.isck2 = true;
        mix.isck3 = true;

        // true
        mix.isTck1 = true;
        mix.isTck2 = true;
        mix.isTck3 = true;

        // true
        mix.isOne = true;
        mix.isTwo = true;
        mix.isThree = true;

        mix.isCkTag = true;

    }

    public void CountReset()
    {
        fryers.count = 0;

        fryers.oilcolor.material.color = new Color(1, 1, 0, 1);

        fryers.ck1color.material.color = new Color(1, 1, 0, 1);
        fryers.ck2color.material.color = new Color(1, 1, 0, 1);
        fryers.ck3color.material.color = new Color(1, 1, 0, 1);

        fryers.BtnCube.SetActive(false);
        fryers.btn.transform.rotation = Quaternion.Euler(0, 0, 0);
        fryers.chicken.transform.position = new Vector3(3.4433f, 2.8712f, 0.43356f);


        if (ck.gameObject.tag == "RealCk")
        {
            ck.gameObject.tag = "ck";
        }

        fryers.ckCount = 0;
        mix.count = 0;
    }

}

