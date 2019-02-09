using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextViewer : MonoBehaviour {

    [SerializeField]
    private GameObject m_Text;

    [SerializeField]
    private Image m_Center;

    public Color baseColor;
    [SerializeField]
    private Color m_SetColor;

    private bool isVisible = false;



	// Use this for initialization
	void Start () {

        baseColor = m_Center.color;

	}
	

	void Update () {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.GetComponent<ObjectText>())
            {
                m_Center.color = m_SetColor;
            }
            else
            {
                m_Center.color = baseColor;
            }
               
        }
        else
        {
            m_Center.color = baseColor;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!isVisible)
            {
                if (Physics.Raycast(ray, out hit, 10f))
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.GetComponent<ObjectText>())
                    {
                        m_Text.SetActive(true);
                        m_Text.GetComponentInChildren<Text>().text = hit.collider.gameObject.GetComponent<ObjectText>().GetDescription();
                    }
                    else
                    {
                        m_Text.SetActive(false);
                    }
                }
                else
                {
                    m_Text.SetActive(false);
                }
            }
            
        }
		
	}
}
