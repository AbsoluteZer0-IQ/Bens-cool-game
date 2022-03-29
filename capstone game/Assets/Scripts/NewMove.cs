using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMove : MonoBehaviour
{
    [Range(0, 100)]
    public int speed;
    [Range(0, 100)]
    public int jSpeed;
    [Range(0, 100)]
    public int mSpeed;
    public float MouseX, MouseY;
    public Vector3 look, mover;
    //public Generation script;
    public Noise script;
    public bool onFloor;
    public int test = 0;

    void Start(){
      onFloor = false;
      Cursor.lockState = CursorLockMode.Locked;
      if(SceneManager.GetActiveScene().buildIndex == 1){
        script = GameObject.Find("NoiseMaker").GetComponent<Noise>();
    //    script = GameObject.Find("Creator").GetComponent<Generation>();
        transform.position = new Vector3(0, script.maxY * 10, 0);
      }
    }
    void OnTriggerEnter(Collider other){
      if(other.CompareTag("Ground")){
        onFloor = true;
        test = 0;
      }
      if(other.CompareTag("Start")){
        SceneManager.LoadScene(1);
      }
      if(other.CompareTag("Kill")){
        SceneManager.LoadScene(0);
      }
    }
//    void OnTriggerExit(Collider other){
  //    if (other.CompareTag("Ground")){
  //      onFloor = false;
  //    }
//    }
    void Update(){
      //  mover = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//        MouseY = Input.GetAxis("Mouse Y") * mSpeed;
        MouseX = Input.GetAxis("Mouse X") * mSpeed;
        transform.Rotate(MouseY, MouseX, 0);
        if(test == 18){
          onFloor = false;
        }
        if(Input.GetAxisRaw("Jump") == 1 && onFloor){
          GetComponent<Rigidbody>().AddForce(transform.up * jSpeed);
          test++;
      //    onFloor = false;
      //    Debug.Log("qwdcgwefqhj");
      //    look = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
    //      look.z = jSpeed;
        //  look.y = 5;
        //  GetComponent<Rigidbody>().velocity = transform.TransformDirection(look);
        }
        }
    void FixedUpdate(){
        if(Input.GetAxisRaw("Vertical") == 1){
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
    }
}
