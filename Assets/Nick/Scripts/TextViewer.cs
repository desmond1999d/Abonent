using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextViewer : MonoBehaviour {

    [SerializeField] private GameObject text;
    [SerializeField] private Image centerImage;
    [SerializeField] private Color baseColor;
    [SerializeField] private Color setColor;
    [SerializeField] private String tag = "ObjectText";
    
    private Camera mainCamera;
    
    private bool isEnabled = true;
    private bool isVisible = false;

	void Start ()
    {
        mainCamera = GameController.Instance.MainCamera;
        
        baseColor = centerImage.color;
	}
	

	void Update () {

        if (isEnabled)
        {
            changeCenterColor();

            if (Input.GetMouseButtonDown(0))
            {
                if (!isVisible)
                {
                    viewText();
                }
            
            }
        }
		
	}

    private void changeCenterColor()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.CompareTag(tag))
            {
                if (hit.collider.GetComponent<ObjectText>())
                {
                    centerImage.color = setColor;
                }
            }
            else
            {
                centerImage.color = baseColor;
            }
               
        }
        else
        {
            centerImage.color = baseColor;
        }
    }
    private void viewText()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 10f))
        {
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.GetComponent<ObjectText>())
            {
                text.SetActive(true);
                text.GetComponentInChildren<Text>().text = hit.collider.gameObject.GetComponent<ObjectText>().GetDescription();
            }
            else
            {
                text.SetActive(false);
            }
        }
        else
        {
            text.SetActive(false);
        }
    }

    public void EnableThis(bool enable)
    {
        if (enable)
        {
            isEnabled = true;
            centerImage.enabled = true;
        }
        else
        {
            isEnabled = false;
            centerImage.enabled = false;
        }
    }
}
