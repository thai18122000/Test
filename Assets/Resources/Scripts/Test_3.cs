using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to Main camera
public class Test_3 : MonoBehaviour{
    [SerializeField] private Transform cam;
    float yRot;
    private void Update(){
        if(Input.GetKey(KeyCode.Mouse0)){
            RotateCam();
        }
    }

    private void RotateCam(){ 
        float mouseX = Input.GetAxis("Mouse X");
        yRot = yRot - mouseX;
        yRot = Mathf.Clamp(yRot, -45, 45);
        //Sử dụng phép quay Quaternion để dễ dàng clamp - giới hạn các parameter truyền vào
        cam.localRotation = Quaternion.Euler(new Vector3(0, yRot, 0));
    }
}
