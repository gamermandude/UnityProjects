using UnityEngine;

public class Brick : MonoBehaviour
{

    public int timesHit;

    public Sprite[] HitSprites;
    public static int TotalBricks;
    private bool isBreakable;
    public AudioClip CrackSound;
    private LevelManager levelManager;
    public GameObject smoke;

    // Use this for initialization
    void Start ()
    {
        isBreakable = tag == "Breakable";
        if (isBreakable) { TotalBricks++; }
        print("TotalBricks: " + TotalBricks);
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(CrackSound, transform.position);
            HandleHits();
        }
    }

    void HandleHits()
    {
        int maxHits = HitSprites.Length + 1;

        print("timeshit " + timesHit);
        print("maxhits " + maxHits);

        timesHit++;
        if (timesHit >= maxHits)
        {
            ScoreKeeper.Score += maxHits * 1000;
            TotalBricks--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    void PuffSmoke()
    {
        var puff = Instantiate(smoke, transform.position, Quaternion.identity);
        var main = puff.GetComponent<ParticleSystem>().main;
        main.startColor = GetComponent<SpriteRenderer>().color;
    }
    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (HitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Missing sprite texture for: index: " + spriteIndex + " brick: " + gameObject.name);
        }
    }
}
