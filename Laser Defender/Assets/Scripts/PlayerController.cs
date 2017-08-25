using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float xmin;
    float xmax;
    float ymin;
    float ymax;
    public float padding = 1;
	// Use this for initialization
	void Start ()
    {
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        var topMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        var bottomMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
        ymin = bottomMost.y;
        ymax = topMost.y;
	}
    public float speed = 0.1f;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        var clamped = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax), Mathf.Clamp(transform.position.y, ymin, ymax), 0f);
        transform.position = clamped;
	}
}
