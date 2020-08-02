using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField] private float m_SmoothTime;
    [SerializeField] private Vector3 m_Offset;
    [SerializeField] private Transform m_Target;

    private Transform m_Transform;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
		m_Target = GameObject.Find("PlayerObject").transform; //So it automatically finds player transform
        this.m_Transform = GetComponent<Transform>();
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = this.m_Target.TransformPoint(this.m_Offset);

        // Smoothly move the camera towards that target position
        this.m_Transform.position = Vector3.SmoothDamp(this.m_Transform.position, targetPosition, ref velocity, this.m_SmoothTime);
    }
}
