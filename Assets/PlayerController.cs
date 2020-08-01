using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameManager GMScript;
	public KeyCode RewindKey = KeyCode.R;
	public GameObject PointOfRewind;
	public int NumberofRewindsLeft = 1;

	// Start is called before the first frame update
	void Start()
    {
		GMScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		PointOfRewind = GameObject.Find("RewindPoint");

	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(RewindKey))
		{
			RewindFunction();
		}
	}

	void RewindFunction()
	{
		if (NumberofRewindsLeft > 0)
		{
			Debug.Log("Rewound from: " + gameObject.transform.position + "To: " + PointOfRewind.transform.position);
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
			Debug.Log("Found a key!");
			GMScript.CollectedAKey();
			collision.gameObject.SetActive(false);
		}

		else if (collision.tag == "Door")
		{
			Debug.Log("Walked into a door");
			if(GMScript.KeysCollected >= 1) // Change me later please this is terrible
			{
				Debug.Log("In func that changes scenes that is in the player script");
				GMScript.SwitchToNextScene();
			}
		}
	}
}
