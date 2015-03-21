using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rigidbody2D;
	Animator anim;
	BoxCollider2D boxcollider2d;
	Collider collider;
	public float jumpheight;
	public bool isJumping;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		boxcollider2d = GetComponent<BoxCollider2D>();
		collider = GetComponent<Collider> ();

	}

	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.layer == "Ground"){
			isJumping == true;
		}
	
	// Update is called once per frame
	void Update () {

		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");

		bool isWalking = (Mathf.Abs (input_x)) > 0;
		//bool isJumping = collider.//TODO: Make isJumping animation active while character is jumping..

		anim.SetBool ("isWalking", isWalking);
		anim.SetBool ("isJumping", isJumping);

		if (isWalking) {
			anim.SetFloat ("x", input_x);

			transform.position += new Vector3 (input_x, 0, 0).normalized * Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			anim.SetFloat ("y", input_y);
			rigidbody2D.AddForce (Vector3.up * jumpheight);
			//transform.position += (new Vector3 (0, input_y, 0) * 20) * Time.deltaTime;
		
		}	

	}




	}



