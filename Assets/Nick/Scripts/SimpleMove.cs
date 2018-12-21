using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

    public float backWheelDistance = 1;
    private GameObject dummyPivot;
    float turningCenterDistance = 5;

    // Use this for initialization
    void Start () {
        dummyPivot = new GameObject("dummyParent");
        dummyPivot.transform.parent = this.transform;
        dummyPivot.transform.localRotation = Quaternion.identity;
        dummyPivot.transform.localPosition = Vector3.zero;
        dummyPivot.transform.parent = null;
        this.transform.parent = dummyPivot.transform;
        this.transform.localPosition = new Vector3(0, 0, backWheelDistance);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000f * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 2000f * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 turningPivotPoint = dummyPivot.transform.TransformPoint(new Vector3(-turningCenterDistance, 0, 0));
            dummyPivot.transform.RotateAround(turningPivotPoint, -Vector3.up, 20 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 turningPivotPoint = dummyPivot.transform.TransformPoint(new Vector3(turningCenterDistance, 0, 0));
            dummyPivot.transform.RotateAround(turningPivotPoint, Vector3.up, 20 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 500f, ForceMode.Impulse);
        }

    }
}
