using UnityEngine;
using System.Collections;

public class ReactiveTargetAparat1 : MonoBehaviour {

    private bool open = false;
    public void ReactToHit()
    {
        StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
        if (!open)
        {
            this.transform.Rotate(0, 90, 0);
            open = true;
        }
        else
        {
            this.transform.Rotate(0, -90, 0);
            open = false;
        }
        yield return new WaitForSeconds(1.5f);
    }
}
