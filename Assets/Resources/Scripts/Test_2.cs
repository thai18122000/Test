using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to Quad
public class Test_2 : MonoBehaviour{
    [SerializeField] private GameObject theQuad;

    private void Update(){
        if(Input.GetKey(KeyCode.Mouse0)){
            RotateObject();
        }
    }

    private void RotateObject(){        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            Vector3 rotateVector = hit.point - theQuad.transform.position;
            float rotateAngle = Vector3.SignedAngle(theQuad.transform.up, rotateVector, theQuad.transform.forward);
            theQuad.transform.Rotate(Vector3.forward, rotateAngle);
        } 
    }
}
