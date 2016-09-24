using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed = 1.0f;
    public float jumpSpeed = 0.5f;

    private Animator marioAnimator;
    private float scaleX = 1.0f;
    private float scaleY = 1.0f;

    public bool grounded;

    // Use this for initialization
    void Start () {
        marioAnimator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        marioAnimator.SetBool("Grounded", grounded);
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

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(mSpeed * speed, this.GetComponent<Rigidbody2D>().velocity.y);
    }
}
