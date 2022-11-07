using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaR : MonoBehaviour
{
    public float rotSpeedX;

    // x 회전값
    public float rotX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //회전해라
        transform.Rotate(rotSpeedX * Time.deltaTime, 0, 0);
        //나의 x 회전값 에 rotSpeed * Time.deltaTime 값을 더한다.
        rotX += rotSpeedX * Time.deltaTime;
        //만약에 rotX가 -225보다 커지면 회전하는 방향을 바꾼다.
        if (rotX > 10)
        {
            rotSpeedX = -rotSpeedX;
        }

        //만약에 rotX가 -315보다 작아지면 회전하는 방향을 바꾼다.
        if (rotX < 0)
        {
            rotSpeedX = -rotSpeedX;
        }
        return;
    }
}
