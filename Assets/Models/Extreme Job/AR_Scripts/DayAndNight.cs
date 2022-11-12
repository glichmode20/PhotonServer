using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] 
    private float RealTimeSecond; // ���� ���迡���� 100�� = ���� ������ 1��

    private bool isNight = false;

    [SerializeField] 
    float nightFogDensity; // �� ������ Fog �е�
    
    float dayFogDensity; // �� ������ Fog �е�
    
    [SerializeField] 
    float fogDensityCalc; // ������ ����
    
    float currentFogDensity;

    void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;
    }

    void Update()
    {
        // ��� �¾��� X �� �߽����� ȸ��. ���ǽð� 1�ʿ�  0.1f * secondPerRealTimeSecond ������ŭ ȸ��
        transform.Rotate(Vector3.right, 0.1f * RealTimeSecond * Time.deltaTime);

        if (transform.eulerAngles.x >= 170) // x �� ȸ���� 170 �̻��̸� ���̶�� �ϰ���
            isNight = true;
        else if (transform.eulerAngles.x <= 10)  // x �� ȸ���� 10 ���ϸ� ���̶�� �ϰ���
            isNight = false;

        if (isNight)
        {
            if (currentFogDensity <= nightFogDensity)
            {
                currentFogDensity += 0.1f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
        else
        {
            if (currentFogDensity >= dayFogDensity)
            {
                currentFogDensity -= 0.1f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
    }
}
