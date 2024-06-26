using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBall_p2 : MonoBehaviour
{
    private GameObject ball = null;


    private void Update()
    {
        ball = GameObject.FindWithTag("Ball");
    }


    //주요기능을 실행하는 함수
    private void LoackBall()
    {
        StartCoroutine(Co_Stop());
    }

    //아이템의 주요 기능을 실행
    private IEnumerator Co_Stop()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.1f);
    }

    //충돌이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball2")
        {
            LoackBall();
            Destroy(gameObject);
            GameManager1.Instance.isOnItem = false;
        }
    }
}
