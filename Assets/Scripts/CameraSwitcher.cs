using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Vehicles.Car;

public enum CameraType
{
	FPS,
	T400,
	Moss,
	Zil
}
public class CameraSwitcher : MonoBehaviour
{
	[SerializeField] private AutoCam t400AutoCam;
	[SerializeField] private AutoCam zilAutoCam;
	[SerializeField] private AutoCam mossAutoCam;
	[SerializeField] private Camera FPSCamera;

	[SerializeField] private CarController zilController;
	[SerializeField] private CarController t400Controller;
	[SerializeField] private CarController mossController;
	[SerializeField] private CarUserControl zilUser;
	[SerializeField] private CarUserControl t400User;
	[SerializeField] private CarUserControl mossUser;
	[SerializeField] private GameObject FPSController;

	private CameraType currentCameraType = CameraType.FPS;
	
	// Use this for initialization
	void Start () {
		
		zilController.enabled = false;
		t400Controller.enabled = false;
		mossController.enabled = false;
		
		zilUser.enabled = false;
		t400User.enabled = false;
		mossUser.enabled = false;
		
		t400AutoCam.gameObject.SetActive(false);
		zilAutoCam.gameObject.SetActive(false);
		mossAutoCam.gameObject.SetActive(false);
		
		t400AutoCam.SetTarget(t400Controller.transform);
		mossAutoCam.SetTarget(mossController.transform);
		zilAutoCam.SetTarget(zilController.transform);

		FPSController.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			cameraSwitch(CameraType.FPS);
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			cameraSwitch(CameraType.Moss);
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			cameraSwitch(CameraType.T400);
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			cameraSwitch(CameraType.Zil);
		}

		switch (currentCameraType)
		{
			case CameraType.FPS:
				break;
			case CameraType.T400:
				t400AutoCam.SetTarget(t400Controller.transform);
				break;
			case CameraType.Moss:
				mossAutoCam.SetTarget(mossController.transform);
				break;
			case CameraType.Zil:
				zilAutoCam.SetTarget(zilController.transform);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void cameraSwitch(CameraType cameraType)
	{
		switch (currentCameraType)
		{
			case CameraType.FPS:
				FPSController.SetActive(false);
				break;
			case CameraType.T400:
				t400Controller.enabled = false;
				t400User.enabled = false;
				t400AutoCam.gameObject.SetActive(false);
				break;
			case CameraType.Moss:
				mossController.enabled = false;
				mossUser.enabled = false;
				mossAutoCam.gameObject.SetActive(false);
				break;
			case CameraType.Zil:
				zilController.enabled = false;
				zilUser.enabled = false;
				zilAutoCam.gameObject.SetActive(false);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
		
		switch (cameraType)
		{
			case CameraType.FPS:
				
				FPSController.SetActive(true);
				currentCameraType = CameraType.FPS;
				
				break;
			case CameraType.T400:

				t400AutoCam.gameObject.SetActive(true);
				t400AutoCam.SetTarget(t400Controller.transform);
				t400User.enabled = true;
				t400Controller.enabled = true;
				currentCameraType = CameraType.T400;
				
				break;
			case CameraType.Moss:

				mossAutoCam.gameObject.SetActive(true);
				mossAutoCam.SetTarget(mossController.transform);
				mossUser.enabled = true;
				mossController.enabled = true;
				currentCameraType = CameraType.Moss;
				
				break;
			case CameraType.Zil:

				zilAutoCam.gameObject.SetActive(true);
				zilAutoCam.SetTarget(zilController.transform);
				zilUser.enabled = true;
				zilController.enabled = true;
				currentCameraType = CameraType.Zil;
				
				break;
			default:
				break;
		}
	}
}
