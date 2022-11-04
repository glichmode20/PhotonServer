using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    float curTime;

    float rotSpeed = 100f;
    internal bool interactable;

    public void start()
    {
        //StartCoroutine(LerpTime());
        transform.eulerAngles = new Vector3(90, 0, -90);

    }

    public void Restart()
    {
        transform.eulerAngles = new Vector3(90, 0, 0);
    }

    IEnumerator LerpTime()
    {
        // 시간이 흐른다
        curTime += Time.deltaTime;

        // 1초가 되기 전까지
        while (curTime < 1)
        {
            // 버튼 회전 
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.right), rotSpeed * Time.deltaTime);

            
            yield return null;

        }

   

    }
}
