using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFlipperSize : MonoBehaviour
{

    [SerializeField] private float oringScale = default;
    [SerializeField] private float minScale = default;
    [SerializeField] private float maxScale = default;
    [SerializeField] private float itmeDurationTime = default;

    private bool isChange = false;

    public GameObject leftPin = null;
    public GameObject rightPin = null;

    public float xpos;
    public float ypos;
    public Vector2 newposition;


    private void Update()
    {
        leftPin = GameObject.FindWithTag("LeftPin2");
        rightPin = GameObject.FindWithTag("RightPin2");
    }

    private void SetFlipperEvent()
    {
        float choseEvent = Random.Range(0, 2);

        if(isChange == false)
        {
            switch (choseEvent)
            {
                case 0:
                    {
                        SetSamllFlipper();
                        break;
                    }
                case 1:
                    {
                        SetSamllFlipper();
                        break;
                    }
            }
        }
    }

    private void SetSamllFlipper()
    {
        StartCoroutine(Co_SetSamllFlipper());
    }

    private void SetLargeFlipper()
    {
        StartCoroutine(Co_SetLargeFlipper());
    }

    private void SetFlipperSize(float size)
    {
        isChange = true;
        leftPin.transform.localScale = new Vector3(-size, 1f, 1f);
        rightPin.transform.localScale = new Vector3(size, 1f, 1f);
    }

    private void SetFlipperOriginSize(float size)
    {
        isChange = false;
        leftPin.transform.localScale = new Vector3(-size, 1f, 1f);
        rightPin.transform.localScale = new Vector3(size, 1f, 1f);
    }

    private IEnumerator Co_SetSamllFlipper()
    {
        SetFlipperSize(minScale);
        yield return new WaitForSeconds(itmeDurationTime);
        SetFlipperSize(oringScale);

    }

    private IEnumerator Co_SetLargeFlipper()
    {
        SetFlipperSize(maxScale);
        yield return new WaitForSeconds(itmeDurationTime);
        SetFlipperSize(oringScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            SetFlipperEvent();
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
