using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball1 : MonoBehaviour
{
    [SerializeField] private float oringBounciness = default;
    [SerializeField] private float bouncinessDamage = default;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            AudioManager.instance.PlaySFX("Bound");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("DeadZone2"))
        {
            if(GameManager1.Instance.isOnBall == true)
            {
                UIManager.Instance.p1.text = (UIManager.Instance.score_p1 += 1).ToString();
            }
            
            Destroy(gameObject);
            GameManager1.Instance.isOnBall = false;
        }
    }
}
