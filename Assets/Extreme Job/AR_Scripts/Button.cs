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
        // �ð��� �帥��
        curTime += Time.deltaTime;

        // 1�ʰ� �Ǳ� ������
        while (curTime < 1)
        {
            // ��ư ȸ�� 
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.right), rotSpeed * Time.deltaTime);

            
            yield return null;

        }

   

    }
}
