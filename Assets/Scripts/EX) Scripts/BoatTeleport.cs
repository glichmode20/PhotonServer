using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class BoatTeleport : MonoBehaviourPunCallbacks
{
    public GameObject boat;
    public GameObject bPos1;

    public GameObject camPos;

    public GameObject player;
    GameObject movieImg;
    GameObject movieImg1;
    GameObject movieImg2;
    public GameObject reSpawn;



    // Start is called before the first frame update
    void Start()
    {
        camPos = player.transform.GetChild(0).gameObject;
        movieImg = GameObject.Find("@BoatCanvas").transform.GetChild(0).gameObject;
        movieImg1 = movieImg.transform.GetChild(0).gameObject;
        movieImg2 = movieImg.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false)
        {
            Destroy(camPos);

        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "Boat")
                {
                    player.transform.position = bPos1.transform.position;
                    StartCoroutine(MovieImg());

                }

            }
        }

    }
    IEnumerator MovieImg()
    {
        yield return new WaitForSeconds(0.1f);
        if (photonView.IsMine == true)
        {
            movieImg1.SetActive(true);
            player.transform.GetComponent<PlayerMove>().enabled = false;
            yield return new WaitForSeconds(2f);
            movieImg2.SetActive(true);
            if (movieImg2.activeSelf == true)
            {
                player.transform.GetComponent<PlayerMove>().enabled = true;

            }
            yield return new WaitForSeconds(1f);
            player.transform.position = reSpawn.transform.position;
            movieImg1.SetActive(false);
            movieImg2.SetActive(false);


        }

    }

}
