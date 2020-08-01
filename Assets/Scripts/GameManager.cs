using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject m_Past;
	[SerializeField] private GameObject m_Present;

	public int KeysCollected;
	private bool isPast;

	public bool RewindTimeBool = false;
	public GameObject PlayerGameObject;
	public float RewindTimeSpeed;
	private Vector2 PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
		this.KeysCollected = 0;
        this.isPast = false;
		PlayerGameObject = GameObject.Find("PlayerObject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void CollectedAKey()
	{
		KeysCollected++;
		Debug.Log("Keys Collected: " + KeysCollected);
	}

	public void SwapTime()
	{
		this.isPast = !this.isPast;
		if (this.isPast)
		{
			m_Present.SetActive(false);
			m_Past.SetActive(true);
		}
		else
		{
			m_Past.SetActive(false);
			m_Present.SetActive(true);
		}
	}

	public void RewindTime() // This is a terrible way of doing it but it works, say sorry to your own eyes
	{
		PlayerTransform = PlayerGameObject.transform.position;
		PlayerGameObject.transform.Translate(Vector2.left * RewindTimeSpeed);
		PlayerGameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

	}


	public void SwitchToNextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
