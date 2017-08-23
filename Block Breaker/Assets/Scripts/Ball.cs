using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Paddle thePaddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rigid;
    private bool hasStarted = false;
    private AudioSource audioSource;

	// Use this for initialization
	void Start()
    {
        thePaddle = FindObjectOfType<Paddle>();
        audioSource = GetComponent<AudioSource>(); 
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (audioSource.isPlaying) return;
        if (!hasStarted) return;
        audioSource.Play();
        rigid.velocity += tweak;
    }

    public void Reset()
    {
        hasStarted = false;
    }
}
