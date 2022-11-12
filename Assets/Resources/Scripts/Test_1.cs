using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to Cube
public class Test_1 : MonoBehaviour{
    [SerializeField] private GameObject theCube;
    [SerializeField] private LayerMask groundLayer;

    private void Update(){
        if(Input.GetKey(KeyCode.Mouse0)){
            Moving();
        }
    }

    private void Moving(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f, groundLayer)){
            theCube.transform.position = hit.point;
        }    
    }
}
