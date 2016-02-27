using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
	public Text powText;

	private Transform tx;
	private Rigidbody rb;
	private int count;
	private float powerUp;
	private float moveSpeed;

	void Start()
	{
		tx = GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
		count = 0;
		winText.text = "";
		SetCountText();
		powerUp = 0f;
		moveSpeed = speed;
		powText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * moveSpeed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
			powerUp = Random.value;
		}
		if (powerUp == 0) // No power-up or lose whatever power-up you have
		{
			tx.position = new Vector3(tx.position.x, 0.5f, tx.position.z);
			moveSpeed = speed;
			tx.localScale = new Vector3(1f, 1f, 1f);
			powText.text = "";
		}
		else if (powerUp > 0 && powerUp <= 0.25) // BIG
		{
			tx.localScale = new Vector3(3f, 3f, 3f);
			tx.position = new Vector3(tx.position.x, 1.5f, tx.position.z);
			powText.text = "BIG";
		}
		else if (powerUp > 0.25 && powerUp <= 0.5) // FAST
		{
			moveSpeed = speed * 2f;
			powText.text = "FAST";
		}
		else if (powerUp > 0.5 && powerUp <= 0.75) // small
		{
			tx.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			tx.position = new Vector3(tx.position.x, 0.25f, tx.position.z);
			powText.text = "small";
		}
		else // SLLOOOOWWWWWWWW
		{
			moveSpeed = speed * 0.5f;
			powText.text = "SLLOOOOWWWWWWWW";
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 13) 
		{
			winText.text = "You Win!";
		}
	}
}