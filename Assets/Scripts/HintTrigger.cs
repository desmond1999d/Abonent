using UnityEngine;
using UnityEngine.UI;

public class HintTrigger : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private TextAsset description;
    [SerializeField] private Image image;
    [SerializeField] private Texture2D photo;

    private bool isShown = false;

    void Start()
    {
        text.GetComponent<UnityEngine.UI.Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = GameController.Instance.MainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isShown = !isShown;
                }
                if (text.GetComponent<UnityEngine.UI.Text>() && !isShown)
                {
                    text.GetComponent<UnityEngine.UI.Text>().text += description.text;
                    Sprite sprite = Sprite.Create(photo, new Rect(image.transform.position.x, image.transform.position.y, image.minWidth, image.minHeight),
                        new Vector2(image.transform.position.x, image.transform.position.y));
                    image.sprite = sprite;
                    image.enabled = true;
                }
                else
                {
                    image.enabled = false;
                    text.GetComponent<UnityEngine.UI.Text>().text = string.Empty;
                }
            }
        }
    }
}
