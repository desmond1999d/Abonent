using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RayLicener : MonoBehaviour {
    [SerializeField]
    private UIInGame uiInGame;
    [SerializeField]
    private UIInGame2 uiInGame2;
    private Camera _camera;
    private bool startGame = false;
    private string oldSelected = "";
    public void StartGame()
    {
        startGame = true;
    }

    public void PauseGame()
    {
        startGame = false;
    }
    void Start()
    {
        _camera = GetComponent<Camera>();
        uiInGame2.gameObject.SetActive(false);
        uiInGame.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && startGame)
        {
            Vector3 point = new Vector3(
            _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                uiInGame2.SetText(hit.transform.gameObject.name.ToString());
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                ReactiveTargetTwo targetTwo = hitObject.GetComponent<ReactiveTargetTwo>();
                ReactiveTargetAparat1 targetAparat1 = hitObject.GetComponent<ReactiveTargetAparat1>();
                if (target != null)
                {
                    target.ReactToHit();
                }
                if (targetTwo != null)
                {
                    targetTwo.ReactToHit();
                }
                if (targetAparat1 != null)
                {
                    targetAparat1.ReactToHit();
                }
            }
        }
        if (startGame)
        {
            Vector3 point2 = new Vector3(
                _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray2 = _camera.ScreenPointToRay(point2);
            RaycastHit hit2;
            if (Physics.Raycast(ray2, out hit2))
            {
                if (oldSelected != hit2.transform.gameObject.name.ToString())
                {
                    oldSelected = hit2.transform.gameObject.name.ToString();
                    uiInGame.SetText(hit2.transform.gameObject.name.ToString());
                }
            }
        }
    }
}
