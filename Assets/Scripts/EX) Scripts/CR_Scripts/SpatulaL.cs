using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaL : MonoBehaviour
{
    public float rotSpeedX;

    // x ȸ����
    public float rotX;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
        //���� x ȸ���� �� rotSpeed * Time.deltaTime ���� ���Ѵ�.
        rotX += rotSpeedX * Time.deltaTime;

        //���࿡ rotX�� -225���� Ŀ���� ȸ���ϴ� ������ �ٲ۴�.
        if (rotX > -10)
        {
            rotSpeedX = -rotSpeedX;
                count++;
        }
        //���࿡ rotX�� -315���� �۾����� ȸ���ϴ� ������ �ٲ۴�.
        else if (rotX < 0)
        {
            rotSpeedX = -rotSpeedX;
            count++;
        }

        if (count != 2)
        {
            //ȸ���ض�
            transform.Rotate(rotSpeedX * Time.deltaTime, 0, 0);
        }
        
    }
}
