using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // @TODO dont hardcode these keys
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, m_Speed);
 
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -m_Speed);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
}
}
