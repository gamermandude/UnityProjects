using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var paddlePos = new Vector3(0.5f, transform.position.y, 0f);

        var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        var clamped = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        paddlePos.x = clamped;
        transform.position = paddlePos;
	}
}
