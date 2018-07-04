using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutController : MonoBehaviour
{
    [SerializeField, Range(0, 0.1f)]
    private float m_FadeSpeed;

    private float m_ColorRad, m_ColorGreen, m_ColorBlue, m_Alpha;
    public bool m_IsFadeOut = false;
    public bool m_IsFadeIn = false;
    public bool m_FadeOutFlag = false;
    public bool m_FadeInFlag = false;

    private Image m_FadeImage;

    // Use this for initialization
    void Start()
    {
        m_FadeImage = GetComponent<Image>();
        m_ColorRad = m_FadeImage.color.a;
        m_ColorGreen = m_FadeImage.color.g;
        m_ColorBlue = m_FadeImage.color.b;
        m_Alpha = m_FadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsFadeIn)
        {
            StartFadeIn();
        }

        if (m_IsFadeOut)
        {
            StartFadeOut();
        }
    }

    private void StartFadeIn()
    {
        m_Alpha -= m_FadeSpeed;
        SetAlpha();

        if (m_Alpha <= 0)
        {
            m_IsFadeIn = false;
            m_FadeImage.enabled = false;
            m_FadeInFlag = true;
        }
    }

    private void StartFadeOut()
    {
        m_FadeImage.enabled = true;
        m_Alpha += m_FadeSpeed;
        SetAlpha();

        if (m_Alpha >= 1)
        {
            m_IsFadeOut = false;
            m_FadeOutFlag = true;
        }
    }

    private void SetAlpha()
    {
        m_FadeImage.color = new Color(m_ColorRad, m_ColorGreen, m_ColorBlue, m_Alpha);
    }
}
