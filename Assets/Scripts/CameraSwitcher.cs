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
    Zil,
    D13
}
public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private AutoCam d13AutoCam;
    [SerializeField] private AutoCam t400AutoCam;
    [SerializeField] private AutoCam zilAutoCam;
    [SerializeField] private AutoCam mossAutoCam;
    [SerializeField] private Camera FPSCamera;

    [SerializeField] private CarController d13Controller;
    [SerializeField] private CarController zilController;
    [SerializeField] private CarController t400Controller;
    [SerializeField] private CarController mossController;
    [SerializeField] private CarUserControl d13User;
    [SerializeField] private CarUserControl zilUser;
    [SerializeField] private CarUserControl t400User;
    [SerializeField] private CarUserControl mossUser;
    [SerializeField] private GameObject FPSController;

    private TextViewer textViewer;

    private CameraType currentCameraType = CameraType.FPS;


    void Start()
    {
        textViewer = GameController.Instance.MainCanvas.gameObject.GetComponent<TextViewer>();

        zilController.enabled = false;
        t400Controller.enabled = false;
        mossController.enabled = false;
        d13Controller.enabled = false;

        zilUser.enabled = false;
        t400User.enabled = false;
        mossUser.enabled = false;
        d13User.enabled = false;

        t400AutoCam.gameObject.SetActive(false);
        zilAutoCam.gameObject.SetActive(false);
        mossAutoCam.gameObject.SetActive(false);
        d13AutoCam.gameObject.SetActive(false);

        t400AutoCam.SetTarget(t400Controller.transform);
        mossAutoCam.SetTarget(mossController.transform);
        zilAutoCam.SetTarget(zilController.transform);
        d13AutoCam.SetTarget(d13Controller.transform);

        FPSController.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CameraSwitch(CameraType.FPS);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CameraSwitch(CameraType.Moss);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CameraSwitch(CameraType.T400);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CameraSwitch(CameraType.Zil);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CameraSwitch(CameraType.D13);
        }

        /*switch (currentCameraType)
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
		}*/
    }

    private void CameraSwitch(CameraType cameraType)
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
            case CameraType.D13:
                d13Controller.enabled = false;
                d13User.enabled = false;
                d13AutoCam.gameObject.SetActive(false);
                break;

        }

        switch (cameraType)
        {
            case CameraType.FPS:

                FPSController.SetActive(true);
                currentCameraType = CameraType.FPS;
                textViewer.EnableThis(true);
                break;
            case CameraType.T400:

                t400AutoCam.gameObject.SetActive(true);
                //				t400AutoCam.SetTarget(t400Controller.transform);
                StartCoroutine(SetTargetRoutine(t400AutoCam, t400Controller.transform));
                t400User.enabled = true;
                t400Controller.enabled = true;
                currentCameraType = CameraType.T400;
                textViewer.EnableThis(false);
                break;
            case CameraType.Moss:

                mossAutoCam.gameObject.SetActive(true);
                //				mossAutoCam.SetTarget(mossController.transform);
                StartCoroutine(SetTargetRoutine(mossAutoCam, mossController.transform));
                mossUser.enabled = true;
                mossController.enabled = true;
                currentCameraType = CameraType.Moss;
                textViewer.EnableThis(false);
                break;
            case CameraType.Zil:

                zilAutoCam.gameObject.SetActive(true);
                //				zilAutoCam.SetTarget(zilController.transform);
                StartCoroutine(SetTargetRoutine(zilAutoCam, zilController.transform));
                zilUser.enabled = true;
                zilController.enabled = true;
                currentCameraType = CameraType.Zil;
                textViewer.EnableThis(false);
                break;
            case CameraType.D13:

                d13AutoCam.gameObject.SetActive(true);
                //				zilAutoCam.SetTarget(zilController.transform);
                StartCoroutine(SetTargetRoutine(d13AutoCam, d13Controller.transform));
                d13User.enabled = true;
                d13Controller.enabled = true;
                currentCameraType = CameraType.D13;
                textViewer.EnableThis(false);
                break;
            default:
                break;
        }
    }

    private IEnumerator SetTargetRoutine(AutoCam autoCam, Transform target, int times = 2)
    {
        int count = 0;
        while (count < times)
        {
            autoCam.SetTarget(target);
            count++;
            yield return new WaitForEndOfFrame();
        }
    }
}
