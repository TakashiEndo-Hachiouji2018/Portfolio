using UnityEngine;
using System.Collections;

public class Buoyancy : MonoBehaviour
{

    public float m_Distance;
    public float m_Speed;
    private Vector3 m_Origin;
    private float m_Phase;
    //private Tourou tourou;

    public float buoSwitch = 1;

    // Use this for initialization
    void Start()
    {
        m_Phase = Mathf.PI * 2 * Random.Range(0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        m_Origin = transform.position;
        transform.position = m_Origin + Vector3.up * m_Distance * Mathf.Sin(Time.time * m_Speed + m_Phase) * Time.deltaTime;
    }
}
