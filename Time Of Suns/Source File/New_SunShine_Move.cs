using UnityEngine;
using System.Collections;

public class New_SunShine_Move : MonoBehaviour 
{
    [SerializeField]
    private float m_TransRotation = 0.0f;
    [SerializeField]
    private float m_RotationSpeed = 0.0f;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.X))
        {
            m_TransRotation -= m_RotationSpeed * Time.deltaTime * 20;
            transform.localRotation = Quaternion.Euler(m_TransRotation, 0, 0);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            m_TransRotation += m_RotationSpeed * Time.deltaTime * 20;
            transform.localRotation = Quaternion.Euler(m_TransRotation, 0, 0);
        }
	}
}
