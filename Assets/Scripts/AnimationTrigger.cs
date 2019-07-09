using System;
 using UnityEngine;
 
 namespace a
 {
     public class AnimationTrigger : MonoBehaviour
     {
         private void Update()
         {
             if (Input.GetMouseButtonDown(0))
             {
                 Ray ray = GameController.Instance.MainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                 RaycastHit hit;
 
                 if (Physics.Raycast(ray, out hit, 10f))
                 {
                     if (hit.collider.GetComponentInParent<Animator>())
                     {
                         hit.collider.GetComponentInParent<Animator>().SetTrigger("startAnimation");
                         hit.collider.GetComponentInParent<Animator>().SetTrigger("StartAnimation");
                     }
                 }
             }
         }
     }
 }