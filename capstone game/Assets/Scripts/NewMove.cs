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
      onFloor = true;
      Cursor.lockState = CursorLockMode.Locked;
      script = GameObject.Find("Main Camera").GetComponent<CamCon>();
    }

    void OnCollisionEnter(collision other){
      if (other.GameObject.Tag == ("Ground")){
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
        if(Input.GetAxisRaw("Jump") == 1 && !onFloor){
          onFloor = true;
          GetComponent<Rigidbody>().AddForce(transform.up * jSpeed);
      //    look = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
    //      look.z = jSpeed;
        //  look.y = 5;
        //  GetComponent<Rigidbody>().velocity = transform.TransformDirection(look);
        }
    }
}
