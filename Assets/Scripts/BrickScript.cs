using UnityEngine;
using System.Collections;
using System;

public class BrickScript : MonoBehaviour
{

    public static int NUMBER_OF_BREAKABLE_BRICKS = 0;

    [SerializeField]
    private int maxHits;
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private Sprite[] hitSprites;
    [SerializeField]
    private AudioClip crackClip;
    [SerializeField]
    private GameObject smoke;

    private int timesHit;
    private bool isBreakable;

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        // keep track of breakable bricks
        if (isBreakable)
        {
            NUMBER_OF_BREAKABLE_BRICKS++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        // works even if brick is destroyed
        AudioSource.PlayClipAtPoint(crackClip, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            NUMBER_OF_BREAKABLE_BRICKS--;
            levelManager.BrickDestroyedMessage();
            SmokeIn();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void SmokeIn()
    {
        Vector3 enhancedBricPos = this.transform.position + new Vector3(0.0f, 0.0f, -5.0f);
        smoke.GetComponent<ParticleSystem>().startColor = 
            gameObject.GetComponent<SpriteRenderer>().color;
        GameObject.Instantiate(smoke, enhancedBricPos, Quaternion.identity);
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    // TODO: Get rid of this method eventually
    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

}
