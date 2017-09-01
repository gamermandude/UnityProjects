using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HitPoints = 150;
    public float ShotSpeed = 2;
    public GameObject Laser;
    public bool Invulnerable;
    public AudioClip DeathSound;
    private AudioSource source;

    private ScoreKeeper sk;
    private void Start()
    {
        sk = FindObjectOfType<ScoreKeeper>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var laser = collision.gameObject.GetComponent<Laser>();
        if (laser)
        {
            if (Invulnerable)
            {
                print("Ha ha chump, I'm invulnerable!");
                return;
            }

            print("A LAZOR BUH GAWD");
            HitPoints -= laser.Damage;
            laser.Hit();
            if(HitPoints < 1)
            {
                sk.Score(100);
                source.PlayOneShot(DeathSound, 1);
                GetComponent<Renderer>().enabled = false;
                GetComponent<ParticleSystem>().Play();
                Destroy(gameObject, DeathSound.length);
            }
        }
    }

    public float shotsPerSecond = 0.5f;
    private void Update()
    {
        float probability = Time.deltaTime * shotsPerSecond;
        if(Random.value < probability)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (Invulnerable) return;

        var projectile = Instantiate(Laser, transform.position, Quaternion.identity);
        var rigid = projectile.GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector3(0, -1 * ShotSpeed, 0);
    }
}
