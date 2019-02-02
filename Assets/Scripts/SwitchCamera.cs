using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    private Point point;
    [SerializeField]
    private RayLicener rayLicener;
    //[SerializeField]
    //public MenuController menu;
	public Camera[] cameraList;
    public Camera mainCamera;
    public GameObject popupGameMenu;
	private int currentCamera;
    public float timer;

	void Start () {
		currentCamera = 0;
		for (int i = 0; i < cameraList.Length; i++){
			cameraList[i].gameObject.SetActive(false);
		}

		if (cameraList.Length > 0){
			cameraList[0].gameObject.SetActive (true);
		}
        popupGameMenu.gameObject.SetActive(false);
	}

    public void StartGame()
    {
        cameraList[currentCamera].gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        point.StartGame();
        rayLicener.StartGame();
        popupGameMenu.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        cameraList[currentCamera].gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        point.PauseGame();
        rayLicener.PauseGame();
        popupGameMenu.gameObject.SetActive(false);
        //menu.gameObject.SetActive(true);
    }

	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = 15;
			currentCamera ++;
			if (currentCamera < cameraList.Length){
				cameraList[currentCamera - 1].gameObject.SetActive(false);
				cameraList[currentCamera].gameObject.SetActive(true);
			}
			else {
				cameraList[currentCamera - 1].gameObject.SetActive(false);
				currentCamera = 0;
				cameraList[currentCamera].gameObject.SetActive(true);
			}
		}
	}
}
