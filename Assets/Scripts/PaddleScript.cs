using UnityEngine;
using System.Collections;
using System;

public class PaddleScript : MonoBehaviour
{

    [SerializeField]
    private bool autoPlay = false;

    private BallScript ball;

    public void Start()
    {
        ball = GameObject.FindObjectOfType<BallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    private void AutoPlay()
    {
        Vector2 ballPosInUnityUints = ball.transform.position;
        Vector2 paddlePos = new Vector2(
            Mathf.Clamp(ballPosInUnityUints.x, 0.5f, 15.5f),
            this.transform.position.y);
        this.transform.position = paddlePos;
    }

    private void MoveWithMouse()
    {
        float mousePosInUnityUints = Input.mousePosition.x / Screen.width * 16;
        Vector2 paddlePos = new Vector2(
            Mathf.Clamp(mousePosInUnityUints, 0.5f, 15.5f),
            this.transform.position.y);
        this.transform.position = paddlePos;
    }
}
