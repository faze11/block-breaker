using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Paddle paddle;
    private Vector3 paddleToBallVector;
    public bool IsLaunched = false;

	// Use this for initialization
	void Start () {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (!IsLaunched)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                // launch ball
                print("Launching ball");
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                IsLaunched = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(.1f, 0.25f), Random.Range(.1f, 0.25f));


        var x = collision.collider.GetComponent<Paddle>();
        if (x != null)
        {
            print("Paddle");
            tweak = new Vector2(Random.Range(.1f, 0.4f), Random.Range(.1f, 0.4f));
        }
        if (IsLaunched)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
