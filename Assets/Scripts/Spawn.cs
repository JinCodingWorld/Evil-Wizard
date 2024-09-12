using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Spawn : MonoBehaviour
{
    public Transform[] pos;
    public GameObject[] prefab;

    public Transform arCamera;

    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(WaitandSpawn());

        audio.Play();
    }

    IEnumerator WaitandSpawn()
    {
        while (true)
        {
            float waitTime = Random.Range(2.0f, 6.0f);
            int ranNum = Random.Range(0, 4);
            yield return new WaitForSeconds(waitTime);
            for (int i = 0; i < ranNum; i++)
            {
                int iPrefab = Random.Range(0, prefab.Length);
                int iPos = Random.Range(0, pos.Length);

                //GameObject o = Instantiate(prefab[iPrefab], pos[iPos].position, Quaternion.Euler(0, 180, 0));

                //// 방향 문제 해결해보자
                GameObject o = Instantiate(prefab[iPrefab], pos[iPos].position, Quaternion.identity);

                o.transform.LookAt(arCamera);
                //o.GetComponent<EnemyFollow>().target = arCamera;

                Destroy(o, 13f);

                Rigidbody rb = o.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.back * Random.Range(4.0f, 12.0f), ForceMode.VelocityChange);

            }
        }

    }

}
