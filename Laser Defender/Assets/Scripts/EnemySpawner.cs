using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public float width = 10;
    public float height = 5;

    public float xmax;
    public float xmin;
    public float ymin;
    public float ymax;

    public float speed = 1f;
    public float padding = 10;

    public PlayerController player;

    public bool TrackingPlayer;
    public bool MovingRight;


	void Start()
    {

        player = FindObjectOfType<PlayerController>();

        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        var topMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        var bottomMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
        ymin = bottomMost.y;
        ymax = topMost.y;

        foreach (Transform child in transform)
        {
            var prefab = Instantiate(enemy, child.position, Quaternion.identity);
            prefab.transform.parent = child;
        }
	}
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
        //
    }

    void Update()
    {
        if (TrackingPlayer)
        {
            var playerPos = player.transform.position;

            transform.position += new Vector3(playerPos.x * speed * Time.deltaTime, 0, 0);

            var clamped = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax), Mathf.Clamp(transform.position.y, ymin, ymax), 0f);
            transform.position = clamped;
        }
        else if (MovingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if(transform.position.x >= xmax || transform.position.x <= xmin)
        {
            MovingRight = !MovingRight;
        }
    }
}
