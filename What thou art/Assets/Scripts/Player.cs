using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed = 1.0f;
    public float jumpSpeed = 0.5f;
    public float curSpeed;
    public float maxSpeed = 5;
    public float jumpTimer = 4;

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
        curSpeed = rb2d.velocity.sqrMagnitude;
        marioAnimator.speed = curSpeed;
        if (curSpeed < 0.2)
        {
            marioAnimator.speed = 1;
        }
	}
    void FixedUpdate()
    {
        //Move Left + Rigth
        float mSpeed = Input.GetAxis("Horizontal");
        marioAnimator.SetFloat("Speed", Mathf.Abs(mSpeed));

        if (mSpeed > 0)
        {
            rb2d.AddForce(Vector2.right * speed);
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
            transform.localScale = new Vector2(scaleX, scaleY);
        }
        else if (mSpeed < 0)
        {
            rb2d.AddForce(Vector2.left * speed);
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
            transform.localScale = new Vector2(-scaleX, scaleY);
        }

        //Jump
        if (Input.GetAxis("Vertical") > 0 && jumpTimer > 0)
        {
            jumpTimer = jumpTimer - 1;
            rb2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
            Debug.Log("Jump Should work");
        }
        //Can only hold down jump for so long
        if (grounded == true)
        {
            jumpTimer = 20;
        }
    }
}
