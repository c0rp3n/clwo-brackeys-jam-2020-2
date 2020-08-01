using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindScript : MonoBehaviour
{
	public KeyCode RewindKey = KeyCode.R;
	public GameObject PointOfRewind;
	public int NumberofRewindsLeft=1;

    // Start is called before the first frame update
    void Start()
    {
		PointOfRewind = GameObject.Find("RewindPoint");
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

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(RewindKey))
		{
			RewindFunction();
		}
    }
}
