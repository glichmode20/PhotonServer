using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaR : MonoBehaviour
{
    public float rotSpeedX;

    // x ȸ����
    public float rotX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ȸ���ض�
        transform.Rotate(rotSpeedX * Time.deltaTime, 0, 0);
        //���� x ȸ���� �� rotSpeed * Time.deltaTime ���� ���Ѵ�.
        rotX += rotSpeedX * Time.deltaTime;
        //���࿡ rotX�� -225���� Ŀ���� ȸ���ϴ� ������ �ٲ۴�.
        if (rotX > 10)
        {
            rotSpeedX = -rotSpeedX;
        }

        //���࿡ rotX�� -315���� �۾����� ȸ���ϴ� ������ �ٲ۴�.
        if (rotX < 0)
        {
            rotSpeedX = -rotSpeedX;
        }
        return;
    }
}
