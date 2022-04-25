using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public LayerMask up, down;
    public bool height, myHeight, shouldMove = false, help = false, helpTwo = true;
    public List<int> locations = new List<int>();
    public int picker;
    [Range(0, 100)]
    public int speed;
    public Vector3 toMove, newSpot;
    public float howFar, closeness;

    void Start(){
      up = LayerMask.GetMask("High");
      down = LayerMask.GetMask("Low");
    }

    void OnTriggerEnter(Collider other){
      if(other.CompareTag("Kill")){
        Destroy(gameObject);
      }
    }

    void Update()
    {
        howFar = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
        if(howFar < closeness && helpTwo){
          helpTwo = false;
          StartCoroutine(WaitMove());
        }
        if(shouldMove){
          transform.position = Vector3.MoveTowards(transform.position, newSpot, speed * Time.deltaTime);
        }
        if(transform.position == newSpot && help && howFar < closeness){
          help = false;
          shouldMove = false;
          StartCoroutine(WaitMove());
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
        switch(locations[picker]){
          case 1:
          case 2:
            toMove = new Vector3(0, 0, 10);
            newSpot = toMove + transform.position;
            shouldMove = true;
            break;
          case 3:
          case 4:
            toMove = new Vector3(-10, 0, 0);
            newSpot = toMove + transform.position;
            shouldMove = true;
            break;
          case 5:
          case 6:
            toMove = new Vector3(10, 0, 0);
            newSpot = toMove + transform.position;
            shouldMove = true;
            break;
          case 7:
          case 8:
            toMove = new Vector3(0, 0, -10);
            newSpot = toMove + transform.position;
            shouldMove = true;
            break;
        }
    }

    IEnumerator WaitMove(){
      yield return new WaitForSeconds(1);
      locations.Clear();
      Look();
      help = true;
      StopCoroutine(WaitMove());
    }
}
