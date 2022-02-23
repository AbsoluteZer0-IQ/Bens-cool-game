using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    [Range(0, 100)]
    public int speed;
    [Range(0, 100)]
    public int mSpeed;
    public float MouseX, MouseY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") == 1){
          transform.position += transform.forward * Time.deltaTime * speed;
        }
        MouseX = Input.GetAxis("Mouse X") * mSpeed;
        if(Input.GetAxis("Mouse Y") >= 0){
          MouseY = Input.GetAxis("Mouse Y") * mSpeed;
        }
        transform.Rotate(MouseX, MouseY, 0);
    }
}
