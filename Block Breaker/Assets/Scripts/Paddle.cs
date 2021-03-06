﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool AutoPlay;
    private Ball ball;
	// Use this for initialization
	void Start()
    {
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if (!AutoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlayAI();
        }
	}
    void AutoPlayAI()
    {
        var paddlePos = new Vector3(0.5f, transform.position.y, 0f);

        var ballPositionInBlocks = ball.transform.position;
        var clamped = Mathf.Clamp(ballPositionInBlocks.x, 0.5f, 15.5f);
        paddlePos.x = clamped;
        transform.position = paddlePos;
    }
    void MoveWithMouse()
    {
        var paddlePos = new Vector3(0.5f, transform.position.y, 0f);

        var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        var clamped = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        paddlePos.x = clamped;
        transform.position = paddlePos;
    }
}
