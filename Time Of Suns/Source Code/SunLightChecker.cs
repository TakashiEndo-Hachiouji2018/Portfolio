using UnityEngine;
using System.Collections;

public class SunLightChecker : MonoBehaviour
{
    private GameObject[] m_Lights;

    public Vector3 offset;

    /// <summary>
    /// 何個の太陽に照らされているか
    /// </summary>
    private int m_IlluminatedCount;

    public int IlluminatedCount
    {
        get { return m_IlluminatedCount; }
        set { m_IlluminatedCount = value; }
    }

    void Start()
    {
        m_Lights = GameObject.FindGameObjectsWithTag("Sun");
    }

    void Update()
    {
        m_IlluminatedCount = 0;

        foreach (var light in m_Lights)
        {
            if (IsIlluminated(light))
            {
                m_IlluminatedCount++;
            }
        }
    }

    /// <summary>
    /// 引数で指定したLightに照らされているか？
    /// </summary>
    /// <param name="light">DirectionalLight</param>
    /// <returns>true:照らされている。false:日陰</returns>
    private bool IsIlluminated(GameObject light)
    {
        Vector3 origin = transform.position + offset;
        Vector3 rayDirection = - light.transform.forward;

        // RayがHitしたということは、光が遮られたということ、つまり日陰。
        // RayがHitしなかったということはひなた。
        bool hit = Physics.Raycast(origin, rayDirection);

        return !hit;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + offset, 0.2f);
    }
}
