using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    public Text life;
    AudioSource audio;
    private int Health = 10;
    public GameObject plane;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("ºÎµúÈû");
            Health--;
            audio.Play();
            plane.SetActive(true);

            Invoke("redscreen", 0.8f);
        }
    }
    void redscreen()
    {
        plane.SetActive(false);
    }
    private void Update()
    {
        life.text = "LIFE : " + Health.ToString();
        if (Health<=0)
        {
            // End Scene;
            SceneManager.LoadScene(2);
        }
    }
}
