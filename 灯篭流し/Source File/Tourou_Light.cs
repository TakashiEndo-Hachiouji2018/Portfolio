using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tourou_Light : MonoBehaviour
{
    public AnimationCurve m_NormalCurve;
    public AnimationCurve m_WindCurve;

    public float m_LightSpeed;
    public float m_WindLightSpeed;
    public Light m_Lightting;
    public GameObject m_Tourou;

    private float m_Phase;
    private float m_LightIntesityBase;
    private float m_LightRange;

	// Use this for initialization
	void Start ()
    {
        m_Phase = Random.Range(0.0f, 3.0f);
        m_LightIntesityBase = m_Lightting.intensity;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float normalbrightiness = m_NormalCurve.Evaluate(Time.time * m_LightSpeed + m_Phase);
        m_Tourou.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(normalbrightiness, normalbrightiness, normalbrightiness));
        m_Lightting.intensity = m_LightIntesityBase + normalbrightiness * m_LightRange;

        if (GetComponent<Tourou>().strongwind == true)
        {
            float windbrightiness = m_WindCurve.Evaluate(Time.time * m_WindLightSpeed + m_Phase);
            m_Tourou.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(windbrightiness, windbrightiness, windbrightiness));
            m_Lightting.intensity = m_LightIntesityBase + windbrightiness * m_LightRange;
        }
    }


}
