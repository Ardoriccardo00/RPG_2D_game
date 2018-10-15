using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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

	// Use this for initialization
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

	void Update () {

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

	// public void removeSword(SpriteRenderer other)
 /*	{
		other.gameObject.name = "Sword";
		other.GetComponent<SpriteRenderer> ();
		other.material.name;
	} */
}
