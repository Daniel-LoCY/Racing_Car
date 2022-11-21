using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform cube;
    private float speed = 0;
    private float slowDownSpeed = 0.2f;
    private float accelerateSpeed = 0.005f;
    private float turnAngle = 1f;
    [SerializeField] Button pauseBtn;
    private bool isPause = false;
//ooo
    private void Start()
    {
        pauseBtn.onClick.AddListener(() =>
        {
            if (isPause)
            {
                Time.timeScale = 1;
                pauseBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Pause";
            }
            else
            {
                Time.timeScale = 0;
                pauseBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Start";
            }
            isPause = !isPause;
        });
    }

    private void FixedUpdate()
    { 
        if (Input.GetKey(KeyCode.UpArrow)) //前進
        {
            cube.Translate(new Vector3(speed, 0, 0), Space.Self);
            if (speed <= 1f)
                speed += accelerateSpeed;
        }
        else if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && speed > 0) //前進減速
        {
            cube.Translate(new Vector3(speed, 0, 0), Space.Self);
            speed -= Time.deltaTime * slowDownSpeed;
            if (speed < 0.05f)
                speed = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //後退
        {
            cube.Translate(new Vector3(speed, 0, 0), Space.Self);
            if (speed >= -1f)
                speed -= accelerateSpeed;
        }
        else if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && speed < 0) //後退減速
        {
            cube.Translate(new Vector3(speed, 0, 0), Space.Self);
            speed += Time.deltaTime * slowDownSpeed;
            if (speed > -0.05f)
                speed = 0;
        }
        if (speed > 0 /*&& Input.GetKey(KeyCode.UpArrow)*/) //前進轉彎
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                cube.Rotate(new Vector3(0, -turnAngle, 0), Space.Self);
            else if (Input.GetKey(KeyCode.RightArrow))
                cube.Rotate(new Vector3(0, turnAngle, 0), Space.Self);
        }
        else if (speed < 0 /*&& Input.GetKey(KeyCode.DownArrow)*/) //後退轉彎
        {
            if (Input.GetKey(KeyCode.RightArrow))
                cube.Rotate(new Vector3(0, -turnAngle, 0), Space.Self);
            else if (Input.GetKey(KeyCode.LeftArrow))
                cube.Rotate(new Vector3(0, turnAngle, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (speed > 0)
            {
                speed -= Time.deltaTime * slowDownSpeed * 1.5f;
                if (speed < 0.1f)
                    speed = 0;
            }
            else if (speed < 0)
            {
                speed += Time.deltaTime * slowDownSpeed * 1.5f;
                if (speed > 0.1f)
                    speed = 0;
            }
        }
    }
}
