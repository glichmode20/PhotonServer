using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenualUI : MonoBehaviour
{
    public GameObject Menual;
        
    private void Start()
    {
        //Menual.SetActive(false);
    }


    public IEnumerator leImage()
    {
        print("½ÇÇà Áß");

        Menual.SetActive(true);

        yield return new WaitForSeconds(2);

        Menual.SetActive(false);
    }
}
