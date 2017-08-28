using UnityEngine;

public class Wiggle : MonoBehaviour
{
    public bool MovingRight;
    public float xmin = -1f;
    public float xmax = 1f;
    public float speed = 0.1f;

	// Update is called once per frame
	void Update()
    {
        if (MovingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if(transform.position.x > xmax || transform.position.x < xmin)
        {
            MovingRight = !MovingRight;
        }
		
	}
}
