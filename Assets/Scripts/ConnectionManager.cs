using System.Collections.Generic;
using UnityEngine;


public class ConnectionManager : SingletonMonoBehaviour<ConnectionManager>
{
    [SerializeField]
    private LineRenderer connectorPrefab = null;


    private List<LineRenderer> connectors = new List<LineRenderer>();


    public void CreateConnection(Transform fromObj, Transform toObj)
    {
        LineRenderer connection = Instantiate(connectorPrefab, transform);
        connection.positionCount = 2;
        connection.SetPosition(0, fromObj.position);
        connection.SetPosition(1, toObj.position);

        connectors.Add(connection);
    }


    public void DestroyConnection(int index)
    {
        Destroy(connectors[index]);
        connectors.RemoveAt(index);
    }
}
