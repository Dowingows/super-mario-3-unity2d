using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody2D rgb;
    private SpriteRenderer spr;
    private Animator anmr;

    private bool isOnGround = false;

    public float speed = 5f;
    public float jumpForce = 50f;



	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anmr = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxisRaw("Horizontal");

        if(moveX < 0){
            spr.flipX = true;
        }else if( moveX > 0 ){
            spr.flipX = false;
        }

        rgb.velocity = new Vector2(moveX * speed, rgb.velocity.y);

        anmr.SetBool("stop",(rgb.velocity.x == float.));

        if(Input.GetKeyUp(KeyCode.Space)){
            Jump();
        }

	}

    void Jump(){
        if(isOnGround){
            rgb.AddForce(new Vector2(0, jumpForce));
            this.isOnGround = false;
        }
    }


	private void OnCollisionEnter2D(Collision2D collision)
	{
        if(collision.gameObject.tag == "ground"){
            this.isOnGround = true;
        }
	}
}
