using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultyplayerPlayerController : NetworkBehaviour  {

	public float moveSpeed;
	private float currentMoveSpeed;
	//public float diagonalMoveModifier;

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	public Vector2 lastMove;
	private Vector2 moveInput;

	private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public string startPoint;

	public bool canMove;
	public bool hasSword;

	private SpriteRenderer Sprite;

	private SFXManager sfxman;

	public WeaponPickup weaponName;

	void Start () {
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D>();
		sfxman = FindObjectOfType<SFXManager> ();
		Sprite = FindObjectOfType<SpriteRenderer> ();
		weaponName = FindObjectOfType<WeaponPickup> ();

		if (!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else { Destroy(gameObject); }

		canMove = true;

		lastMove = new Vector2 (0, -1f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isLocalPlayer)
		{
		}
		else
		{
			return;
		}

		playerMoving = false;

		if (!canMove) 
		{
			myRigidbody.velocity = Vector2.zero;
			return;
		}

		if (!attacking) {

			moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;

			if (moveInput != Vector2.zero) {

				myRigidbody.velocity = new Vector2 (moveInput.x * moveSpeed, moveInput.y * moveSpeed);
				playerMoving = true;
				lastMove = moveInput;
			} 

			else
			{
				myRigidbody.velocity = Vector2.zero;
			}

			if (hasSword == true) {
				if (Input.GetKeyDown (KeyCode.J)) {
					attackTimeCounter = attackTime;
					attacking = true;
					myRigidbody.velocity = Vector2.zero;
					anim.SetBool ("Attack", true);

					sfxman.playerAttack.Play ();

				}
			} 
			/*else
			{
				
			} */


		}

		if (attackTimeCounter > 0)  
		{
			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0) 
		{
			attacking = false;
			anim.SetBool ("Attack", false);
		}

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}

	public override void OnStartLocalPlayer()
	{ 
		//GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	// public void removeSword(SpriteRenderer other)
	/*	{
		other.gameObject.name = "Sword";
		other.GetComponent<SpriteRenderer> ();
		other.material.name;
	} */
}

//-------------------------------------------------------------------------------------------

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	// Update is called once per frame
	void Update () {


		if(!isLocalPlayer)
		{
			return;
		}

		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate (0, 0, z);

		if(Input.GetKeyDown(KeyCode.Space))
		{
			CmdFire ();
		}
	}
	[Command]
	void CmdFire()
	{
		GameObject bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 6.0f;

		NetworkServer.Spawn (bullet);

		Destroy(bullet, 2);
	}

	public override void OnStartLocalPlayer()
	{ 
		//base.OnStartLocalPlayer ();
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
} */
