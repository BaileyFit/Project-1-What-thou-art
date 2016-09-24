using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed = 1.0f;
    public float jumpSpeed = 0.5f;

    private Animator marioAnimator;
    public Rigidbody2D rb2d;

    private float scaleX = 1.0f;
    private float scaleY = 1.0f;

    public bool grounded;

    // Use this for initialization
    void Start () {
        marioAnimator = GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        marioAnimator.SetBool("Grounded", grounded);
        marioAnimator.speed = rb2d.velocity.sqrMagnitude;
	}
    void FixedUpdate()
    {
        float mSpeed = Input.GetAxis("Horizontal");
        marioAnimator.SetFloat("Speed", Mathf.Abs(mSpeed));


        if (mSpeed > 0)
        {
            transform.localScale = new Vector2(scaleX, scaleY);
        }
        else if (mSpeed < 0)
        {
            transform.localScale = new Vector2(-scaleX, scaleY);
        }

        rb2d.velocity = new Vector2(mSpeed * speed, rb2d.velocity.y);
    }
}
