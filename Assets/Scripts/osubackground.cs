using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osubackground : MonoBehaviour
{
    public float m_changeSpeed = 0.1f;
    public UnityEngine.UI.Image m_backgroundImage;

    private void Update()
    {
        float h, s, v;
        Color.RGBToHSV(m_backgroundImage.color, out h, out s, out v);
        h = (h + m_changeSpeed * Time.deltaTime) % 1.0f;
        m_backgroundImage.color = Color.HSVToRGB(h, s, v);
    }
}
