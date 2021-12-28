using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class PlayerControls : MonoBehaviour
{
	public AudioClip potion;
	public CapsuleCollider playerCollider;
	static Animator anim;
	public float moveSpeed = 10;
	public float moveSpeedmax = 30;
	public Rigidbody body;
	public float jumpSpeed = 600f;
	public float horizMove = 0;
	public LayerMask Floor;

	public float boostTimer = 0;
	bool boosting = false;
	bool sliding = false;
	public float jumpTimer = 0;
	bool jumping = false;
	public static bool isMagnet;
	public float magnetTimer = 0;
	public float slowTimer = 0;
	bool slowing = false;
	private void Start()
	{
		anim = GetComponent<Animator>();
		isMagnet = false;
		playerCollider = GetComponent<CapsuleCollider>();
	}

	private void FixedUpdate()
	{
		Vector3 forwarMove = transform.forward * moveSpeed * Time.deltaTime;
		Vector3 horizontalMove = transform.right * horizMove * moveSpeed * Time.deltaTime;
		body.MovePosition(body.position + forwarMove + horizontalMove);
		checkSpeedBoost();
		checkDoubleJump();
		checkCoinMagnet();
		checkSlide();

		if (body.transform.position.y < -1f)
		{
			FindObjectOfType<GameManager>().gameOver();
		}
	}
	void Update()
	{
		horizMove = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown(KeyCode.Space))
		{
			jumpCheck();
			anim.SetTrigger("isJumping");

		}

		if (moveSpeed < moveSpeedmax)
		{
			moveSpeed += 0.1f * Time.deltaTime;
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{

			anim.SetTrigger("isSliding");
			sliding = true;
		}
		

	}


	void checkSlide()
	{
		if(sliding)
		{
			playerCollider.height = 3.63f;
			playerCollider.center = new Vector3(playerCollider.center.x, 1.815f, playerCollider.center.z);
		}
		else
		{
			if(!Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)	 )
				{
				playerCollider.height = 4.44f;
				playerCollider.center = new Vector3(playerCollider.center.x, 2.22f, playerCollider.center.z);
			}
			
		}
	}
	void jumpCheck()
	{
		float height = GetComponent<Collider>().bounds.size.y;
		bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, Floor);

		body.AddForce(Vector3.up * jumpSpeed);
	}


	public void checkSpeedBoost()
	{
		if (boosting)
		{
			boostTimer += 1 * Time.deltaTime;

			if (boostTimer >= 5f)
			{
				moveSpeed = 10;
				boostTimer = 0;
				boosting = false;

			}
		}

	}
	public void checkDoubleJump()
	{
		if (jumping)
		{
			jumpTimer += 1 * Time.deltaTime;

			if (jumpTimer >= 5f)
			{
				jumpSpeed = 600f;
				jumpTimer = 0;
				jumping = false;

			}
		}

	}
	public void checkCoinMagnet()
	{
		if (isMagnet)
		{
			magnetTimer += 1 * Time.deltaTime;

			if (magnetTimer >= 2f)
			{
				magnetTimer = 0;
				isMagnet = false;

			}
		}

	}
	public void checkSlow()
	{
		if (slowing)
		{
			slowTimer += 1 * Time.deltaTime;

			if (slowTimer >= 2f)
			{
				slowTimer = 0;
				moveSpeed = 8;
				slowing = false;

			}
		}

	}

	private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "SpeedBoost")
		{
			boosting = true;
			moveSpeed = 20;
			AudioSource.PlayClipAtPoint(potion, transform.position);
			Destroy(other.gameObject);
		}


		if (other.gameObject.tag == "DoubleJump")
		{
			jumping = true;
			jumpSpeed = 900;
			AudioSource.PlayClipAtPoint(potion, transform.position);
			Destroy(other.gameObject);
		}


		if (other.gameObject.tag == "CoinMulit")
		{
			isMagnet = true;
			AudioSource.PlayClipAtPoint(potion, transform.position);
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "Slow")
		{
			slowing = true;
			AudioSource.PlayClipAtPoint(potion, transform.position);
			Destroy(other.gameObject);
		}
	}
}

