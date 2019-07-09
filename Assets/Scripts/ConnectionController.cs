using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionController : MonoBehaviour
{
    [SerializeField] private GameObject PowerSupply;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ConnectionManager connectionManager = PowerSupply.GetComponent(typeof(ConnectionManager)) as ConnectionManager;
            connectionManager.isTesting = !connectionManager.isTesting;
        }
    }
}
