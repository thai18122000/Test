using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to Cube1
public class Test_4 : MonoBehaviour{
    [SerializeField] private GameObject cube1;
    [SerializeField] private LayerMask cubeLayerMask;
    private Rigidbody rb;
    [SerializeField] float speed;

    private void Start(){
        GetReferences();
    }

    private void FixedUpdate(){
        if(Input.GetKey(KeyCode.Mouse0)){
            Moving();
        }
        else{
            StopMoving();
        }
    }

    private void GetReferences(){
        rb = GetComponent<Rigidbody>();
    }

    private void Moving(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f, cubeLayerMask)){
            Vector3 direction = hit.transform.position - cube1.transform.position;
            //Do chỉ lấy Vector hướng nên Normalize;
            direction = direction.normalized;
            //Uncomment để sử dụng 1 trong 4 function dưới, Uncomment từng funtion 1.

            MovingWith_Velocity(direction);
            // MovingWith_MovePosition(direction);
            // MovingWith_Translate(direction);
            // MovingWith_Position(direction);
        }    
    }

    /*rb.Velocity và rb.MovetoPosition di chuyển vật thể dựa trên Physic, nên cần sử dụng FixedUpdate để cố định framerate
    Ngoài ra, do sử dụng Physic nên sẽ ko tối ưu được như tranform
    */

    //rb.Velocity sẽ ko cần tới Time.Deltatime do di chuyển dựa trên việc gán vector vận tốc vào vật thể
    private void MovingWith_Velocity(Vector3 direction){
        rb.velocity = direction * speed;
    }

    private void MovingWith_MovePosition(Vector3 direction){
        rb.MovePosition(cube1.transform.position + (direction * speed * Time.deltaTime));
    }

    private void MovingWith_Translate(Vector3 direction){
        cube1.transform.Translate(direction * speed * Time.deltaTime);
    }

    //Trong 4 cách, tranform.position là 1 dạng teleport, rb.position cũng là teleport
    private void MovingWith_Position(Vector3 direction){
        cube1.transform.position += direction * speed * Time.deltaTime;
    }

    private void StopMoving(){
        rb.velocity = Vector3.zero;
    }
}
