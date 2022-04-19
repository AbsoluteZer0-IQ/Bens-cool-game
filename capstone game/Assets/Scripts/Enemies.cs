using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public LayerMask up, down;
    public bool height, myHeight;
    public List<int> locations;
    public int picker, speed = 10;
    public Vector3 toMove = new Vector3(5, 0, 0);

    void Start(){
      up = LayerMask.GetMask("High");
      down = LayerMask.GetMask("Low");
      Vector3.MoveTowards(transform.position, transform.position + toMove, speed);
    }

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
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 10f, up)){
          myHeight = true;
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 10f, down)){
          myHeight = false;
        }
        Debug.Log(myHeight);

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 10f, up)){
          height = true;
          if(myHeight == height){
            locations.Add(1);
          }
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 10f, down)){
          height = false;
          if(myHeight == height){
            locations.Add(2);
          }
        }
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 10f, up)){
          height = true;
          if(myHeight == height){
            locations.Add(3);
          }
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 10f, down)){
          height = false;
          if(myHeight == height){
            locations.Add(4);
          }
        }
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 10f, up)){
          height = true;
          if(myHeight == height){
            locations.Add(5);
          }
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 10f, down)){
          height = false;
          if(myHeight == height){
            locations.Add(6);
          }
        }
        Debug.Log(height);
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), 10f, up)){
          height = true;
          if(myHeight == height){
            locations.Add(7);
          }
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), 10f, down)){
          height = false;
          if(myHeight == height){
            locations.Add(8);
          }
        }
        picker = Random.Range(0, locations.Count);
        switch(picker){
          case 1:
          case 2:
            toMove = new Vector3(0, 0, 10);
            Vector3.MoveTowards(transform.position, toMove, speed * Time.deltaTime);
            Debug.Log("for");
            break;
          case 3:
          case 4:
            toMove = new Vector3(-10, 0, 0);
            Vector3.MoveTowards(transform.position, toMove, speed * Time.deltaTime);
            Debug.Log("left");
            break;
          case 5:
          case 6:
            toMove = new Vector3(10, 0, 0);
            Vector3.MoveTowards(transform.position, toMove, speed * Time.deltaTime);
            Debug.Log("right");
            break;
          case 7:
          case 8:
            toMove = new Vector3(0, 0, -10);
            Vector3.MoveTowards(transform.position, toMove, speed * Time.deltaTime);
            Debug.Log("back");
            break;
        }
        locations.Clear();
    }
}
