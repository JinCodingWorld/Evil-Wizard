using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

//싱글턴, 오브젝트 풀링 써서 만들 수 있다

public class Shoot : MonoBehaviour
{
    public GameObject camera;
    public GameObject prefab;
    // KILL 수 나타내기
    public Text KillNum;
    public GameObject Dead;
    private int dead = 0;
    //RecordTime 넣어보자
    public Text timeText;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit)) // (카메라 시작점, 카메라 보는 방향, out은 결과값을 돌려받는 키워드, hit 라는 변수에 정보 담겨있음) 
        {
            // raycast는 physics 안에 들어있다
            if (hit.transform.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal)); // LookRotation은 입력 벡터값으로 회전하는 함수, normal 수직인 방
                audio.Play();
                dead++;
                Dead.SetActive(true);

                Invoke("delay", 2f);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time : " + (int)testSurviveTime.surviveTime;

        KillNum.text = dead.ToString() + " KILL!";
        if(dead >= 30)
        {
            //축하씬 넘어가고 나서 아래가 실행될까??
            SceneManager.LoadScene(3);
        }
    }

    void delay()
    {
        Dead.SetActive(false);
    }

}
