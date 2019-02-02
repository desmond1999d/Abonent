using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {

    [SerializeField]
    private GameObject fpsCamera;
    [SerializeField]
    private GameObject carCamera;

    // Use this for initialization
    void Start()
    {
        fpsCamera.SetActive(true);
        carCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fpsCamera.gameObject.active && !carCamera.gameObject.active)
            {
                fpsCamera.active = false;
                carCamera.active = true;
                Debug.Log("To car camera");
            }
            else if (!fpsCamera.gameObject.active && carCamera.gameObject.active)
            {
                fpsCamera.active = true;
                carCamera.active = false;
                Debug.Log("To fps camera");
            }
        }
    }
}
