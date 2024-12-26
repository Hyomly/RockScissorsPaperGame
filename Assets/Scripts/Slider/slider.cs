using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    [SerializeField]
    private Slider m_moveSlider;
    [SerializeField]
    private Slider m_rotationSlider;
    [SerializeField]
    private Slider m_scaleSlider;

    [SerializeField]
    GameObject m_obj;

    
    public void XMove(float value)
    {
        var objY = m_obj.transform.position.y;
        var objZ = m_obj.transform.position.z;
        m_obj.transform.position = new Vector3(value, objY, objZ);
        
    }

    public void YRotation(float value)
    {
        m_obj.transform.rotation = Quaternion.Euler(0, value, 0);
    }
    
    public void Scale(float value)
    {
        m_obj.transform.localScale = new Vector3(value, value, value);
    }
    // Start is called before the first frame update
    void Start()
    {
        m_moveSlider.onValueChanged.AddListener(XMove);
        m_rotationSlider.onValueChanged.AddListener(YRotation);
        m_scaleSlider.onValueChanged.AddListener(Scale);
    }

}
