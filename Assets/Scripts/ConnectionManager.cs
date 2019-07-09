using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ConnectionManager : SingletonMonoBehaviour<ConnectionManager>
{
    [SerializeField]
    private LineRenderer connectorPrefab = null;

    [Header("Parameters")]
    [SerializeField]
    private int pointsCount = 100;
    [SerializeField]
    private float groundUpOffset = 0f;
    [SerializeField]
    public bool isTesting;


#if UNITY_EDITOR
    [Header("TestObjects")]
    [SerializeField]
    private Transform firstObj = null;
    [SerializeField]
    private Transform secondObj = null;
    [SerializeField]
    private Transform thirdObj = null;
    [SerializeField]
    private Transform forthObj = null;

    private LineRenderer firstConnector = null;
    private LineRenderer secondConnector = null;
    private LineRenderer thirdConnector = null;
#endif


    private List<LineRenderer> connectors = new List<LineRenderer>();


#if UNITY_EDITOR
    [ExecuteInEditMode]
    private void Update()
    {
        if (firstConnector != null)
        {
            DestroyImmediate(firstConnector.gameObject);
            DestroyImmediate(secondConnector.gameObject);
            DestroyImmediate(thirdConnector.gameObject);
        }

        if (!isTesting || firstObj == null || secondObj == null || thirdObj == null || forthObj == null) { return; }

        firstConnector = CreateConnection(firstObj, secondObj);
        secondConnector = CreateConnection(firstObj, thirdObj);
        thirdConnector = CreateConnection(firstObj, forthObj);
    }
#endif


    public void AddConnection(Transform fromObj, Transform toObj)
    {
        connectors.Add(CreateConnection(fromObj, toObj));
    }


    public void DestroyConnection(int index)
    {
        Destroy(connectors[index]);
        connectors.RemoveAt(index);
    }


    private LineRenderer CreateConnection(Transform fromObj, Transform toObj)
    {
        LineRenderer connection = Instantiate(connectorPrefab, transform);
        connection.positionCount = pointsCount;

        Vector3 startPosition = new Vector3(fromObj.position.x, 300f, fromObj.position.z);
        Vector3 finishPosition = new Vector3(toObj.position.x, 300f, toObj.position.z);

        Vector3 direction = Vector3.Normalize(finishPosition - startPosition);
        float segmentLength = (finishPosition - startPosition).magnitude / pointsCount;

        Vector3 currentPosition = startPosition;

        Collider terrainCollider = Terrain.activeTerrain.GetComponent<Collider>();

        for (int i = 0; i < pointsCount; i++)
        {
            RaycastHit hit;
            currentPosition += direction * segmentLength;

            Ray ray = new Ray(currentPosition, Vector3.down);

            if (terrainCollider.Raycast(ray, out hit, 1000f))
            {
                connection.SetPosition(i, new Vector3(hit.point.x, hit.point.y + groundUpOffset, hit.point.z));
            }
        }

        return connection;       
    }
}
