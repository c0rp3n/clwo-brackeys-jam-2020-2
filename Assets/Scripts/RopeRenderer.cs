using UnityEngine;
using System.Collections;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private Transform m_Start;
    [SerializeField] private Transform m_End;
    private LineRenderer m_Rope;

    void Start()
    {
        m_Rope = this.GetComponent<LineRenderer>();
        Vector2 p1 = m_Start.transform.position;
        m_Rope.SetPosition(0, p1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p1 = m_Start.position;
        Vector2 p2 = m_End.position;
        Vector2 lineVector = p2 - p1;
        m_Rope.SetPosition(0, p1);
        m_Rope.SetPosition(1, p2);
    }
}
