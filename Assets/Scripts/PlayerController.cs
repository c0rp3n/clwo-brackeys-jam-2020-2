using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameManager GMScript;
	public KeyCode RewindKey = KeyCode.R;
	public GameObject PointOfRewind;
	public int NumberofRewindsLeft = 1;

	public KeyCode SetPointOfRewind = KeyCode.N;

	public Rigidbody2D rb; // Short for Rigid Body

	// Start is called before the first frame update
	void Start()
    {
		//Initialization
		GMScript = GameObject.Find("GameManager").GetComponent<GameManager>(); 
		PointOfRewind = GameObject.Find("RewindPoint");
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(RewindKey) && GMScript.TeleportRewindBool == true)
		{
			TeleportRewindFunction();
		}
		else if (Input.GetKeyDown(RewindKey) && GMScript.SwapTimeBool == true)
		{
			this.GMScript.SwapTime();
		}

		else if (GMScript.RewindTimeBool == true && Input.GetKey(SetPointOfRewind))
		{
			PointOfRewind.transform.position = this.transform.position;
		}


		else if (GMScript.RewindTimeBool == true && Input.GetKey(RewindKey))
		{
			rb.velocity = Vector2.zero;
			GMScript.RewindTime();
		}


		else if (Input.GetKeyUp(RewindKey))
		{
			rb.gravityScale = 5;
		}
		
	}

	void TeleportRewindFunction() // The first function that resets you back into position
	{
		if (NumberofRewindsLeft > 0)
		{
			gameObject.transform.position = PointOfRewind.transform.position;
			NumberofRewindsLeft--;
		}
		else
		{
			Debug.Log("Did not go in rewind func, current number of rewinds: " + NumberofRewindsLeft);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Key")
		{
			GMScript.CollectedAKey();
			collision.gameObject.SetActive(false);
		}

		else if (collision.tag == "Door" && GMScript.KeysCollected >= 1)
		{
			GMScript.SwitchToNextScene();
		}

		else
		{
			Debug.Log("Collided with: " + collision.tag);
		}
	}
}
