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
    public GameObject Lazor;
    public float firingRate = 1f;
    public float firingSpeed = 10;

    private AudioSource source;
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

        source = GetComponent<AudioSource>();
	}
    public float speed = 0.1f;
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += Vector3.up * speed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += Vector3.down * speed * Time.deltaTime;
        //}

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("FireZeLazor", 0.00001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("FireZeLazor");
        }

        var clamped = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax), Mathf.Clamp(transform.position.y, ymin, ymax), 0f);
        transform.position = clamped;
	}

    void FireZeLazor()
    {
        var prefab = Instantiate(Lazor, transform.position, Quaternion.identity);
        var rigid = prefab.GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector3(0, 10, 0) * firingSpeed;
        source.Play();
    }
    public float Health = 200f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var laser = collision.GetComponent<Laser>();
        if(laser)
        {
            laser.Hit();
            Health -= laser.Damage;
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
            print("Hit");
        }
    }
}
