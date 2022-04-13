using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
      if(other.CompareTag("Kill")){
        Destroy(gameObject);
      }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
          Look();
        }
    }

    void Look(){
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 10f);
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), 10f);
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 10f);
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 10f);
    }
}
