using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GM : MonoBehaviour
{
    public static float vertVel = 0;
    public static int coinTotal = 0;
    public static float timeTotal = 0;

    public float waittoload = 0;
    public static float zVelAdj = 1;

    public static string lvlCompStatus = "";

    public Transform bbNoPit;
    public Transform bbPitMid;
    public float zScenePos=52;

    public Transform coinObj;
    public Transform obstObj;
    public Transform capsuleObj;

    public int randNum;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bbNoPit, new Vector3(0, 2.25f, 36 ), bbNoPit.rotation);
        Instantiate(bbNoPit, new Vector3(0, 2.25f, 40), bbNoPit.rotation);

        Instantiate(bbPitMid, new Vector3(0, 2.25f, 44), bbPitMid.rotation);
        Instantiate(bbPitMid, new Vector3(0, 2.25f, 48), bbPitMid.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if(zScenePos<120)
        {
            randNum = Random.Range(0, 10);

            if(randNum < 5)
            {
                Instantiate(coinObj, new Vector3(-1, 3.17f, zScenePos), coinObj.rotation);
                Instantiate(obstObj, new Vector3(1, 3.17f, zScenePos), obstObj.rotation);

            }

            if (randNum > 5)
            {
                Instantiate(obstObj, new Vector3(1, 3.17f, zScenePos), obstObj.rotation);
                Instantiate(coinObj, new Vector3(-1, 3.17f, zScenePos), coinObj.rotation);
            }

            

            if (randNum == 5)
            {
                Instantiate(capsuleObj, new Vector3(0, 3.17f, zScenePos), capsuleObj.rotation);
                Instantiate(coinObj, new Vector3(1, 3.17f, zScenePos), coinObj.rotation);

            }


            Instantiate(bbNoPit, new Vector3(0, 2.25f, zScenePos), bbNoPit.rotation);
            Instantiate(bbPitMid, new Vector3(0, 2.25f, zScenePos+4), bbPitMid.rotation);
            zScenePos += 8;

        }


        timeTotal += Time.deltaTime;

        if (lvlCompStatus == "Fail")
        {
            waittoload += Time.deltaTime;

        }

        if (waittoload > 2)
        {
            SceneManager.LoadScene("LevelComp");

        }

    }

    

}
