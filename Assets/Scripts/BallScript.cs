using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private PaddleScript paddle;
    [SerializeField]
    private float yVelocity;

    private Vector2 paddleToBallVector;
    private bool hasStarted;

    // Is called before Start Method
    void Awake()
    {
        paddleToBallVector = this.transform.position - paddle.transform.position;
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // locks the ball relative to the paddle if game not started
            this.transform.position = (Vector2)paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                GetComponent<Rigidbody2D>().velocity = 
                    new Vector2(Random.Range(-2.0f, 2.0f), yVelocity);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0.3f, 0.5f), Random.Range(0.3f, 0.5f));
        if (hasStarted)
        {
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

}
