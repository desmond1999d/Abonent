using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
    private bool open = false;
    public void ReactToHit() {
        StartCoroutine(Die());
    }
    private IEnumerator Die() {
        if (!open)
        {
            this.transform.Rotate(0, -110, 0);
            this.transform.Translate(-0.8797f, 0, -0.8423f);
            open = true;
        }
        else
        {
            this.transform.Rotate(0, 110, 0);
            this.transform.Translate(-1.09f, 0, 0.54f);
            open = false;
        }
        yield return new WaitForSeconds(1.5f);
    }
}
