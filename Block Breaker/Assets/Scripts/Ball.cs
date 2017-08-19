using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Paddle thePaddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rigid;
    private bool hasStarted = false;

	// Use this for initialization
	void Start()
    {
        thePaddle = FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - thePaddle.transform.position;
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if (!hasStarted) { transform.position = thePaddle.transform.position + paddleToBallVector; }
        if (Input.GetMouseButtonDown(0) && !hasStarted)
        {
            hasStarted = true;
            rigid.velocity = new Vector2(2f, 10f);
        }
	}

    public void Reset()
    {
        hasStarted = false;
    }
}
