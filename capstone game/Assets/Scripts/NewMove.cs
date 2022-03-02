using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    [Range(0, 100)]
    public int speed;
    [Range(0, 100)]
    public int jSpeed;
    [Range(0, 100)]
    public int mSpeed;
    public float MouseX, MouseY;
    public Vector3 look;
    public CamCon script;
    public bool onFloor;
    // Start is called before the first frame update
    void Start()
    {
      onFloor = false;
      Cursor.lockState = CursorLockMode.Locked;
      script = GameObject.Find("Main Camera").GetComponent<CamCon>();
    }

    void OnTriggerEnter(Collider other){
      if (other.CompareTag("Ground")){
        onFloor = true;
      }
    }
    void OnTriggerExit(Collider other){
      if (other.CompareTag("Ground")){
        onFloor = false;
      }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") == 1){
          transform.position += transform.forward * Time.deltaTime * speed;
        }
//        MouseY = Input.GetAxis("Mouse Y") * mSpeed;
        MouseX = Input.GetAxis("Mouse X") * mSpeed;
        transform.Rotate(MouseY, MouseX, 0);
        if(Input.GetAxisRaw("Jump") == 1 && onFloor){
          GetComponent<Rigidbody>().AddForce(transform.up * jSpeed);
      //    onFloor = false;
          Debug.Log("qwdcgwefqhj");
      //    look = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
    //      look.z = jSpeed;
        //  look.y = 5;
        //  GetComponent<Rigidbody>().velocity = transform.TransformDirection(look);
        }
    }
}
