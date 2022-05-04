using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public bool myHeight, shouldMove = false, help = false, watcher = false;
    public List<int> locations = new List<int>();
    public int picker, speed;
    public Vector3 toMove, newSpot, lower = new Vector3(0, 1.5f, 0);
    public RaycastHit whatHit;

    void Start(){
      transform.rotation = Quaternion.Euler(0, 0, 0);
      speed = Random.Range(5, 51);
      StartCoroutine(WaitMove());
    }

    void OnTriggerEnter(Collider other){
      if(other.CompareTag("Kill")){
        Destroy(gameObject);
      }
    }
    void Update()
    {
        if(shouldMove){
          transform.position = Vector3.MoveTowards(transform.position, newSpot, speed * Time.deltaTime);
        }
        if(transform.position == newSpot && help){
          help = false;
          shouldMove = false;
          StartCoroutine(WaitMove());
        }
    }

    void Look(){
        if(Physics.Raycast(transform.position - lower, transform.TransformDirection(Vector3.down), out whatHit, 2f)){
          if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("High")){
            myHeight = true;
          }
          else if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("Low")){
            myHeight = false;
          }
        }
        if(Physics.Raycast(transform.position - lower, transform.TransformDirection(Vector3.forward), out whatHit, 10f)){
          if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("High")){
            if(myHeight == true){
              locations.Add(1);
            }
          }
          else if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("Low")){
            if(myHeight == false){
              locations.Add(2);
            }
          }
        }
        if(Physics.Raycast(transform.position - lower, transform.TransformDirection(Vector3.left), out whatHit, 10f)){
          if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("High")){
            if(myHeight == true){
              locations.Add(3);
            }
          }
          else if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("Low")){
            if(myHeight == false){
              locations.Add(4);
            }
          }
        }
        if(Physics.Raycast(transform.position - lower, transform.TransformDirection(Vector3.right), out whatHit, 10f)){
          if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("High")){
            if(myHeight == true){
              locations.Add(5);
            }
          }
          else if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("Low")){
            if(myHeight == false){
              locations.Add(6);
            }
          }
        }
        if(Physics.Raycast(transform.position - lower, transform.TransformDirection(Vector3.back), out whatHit, 10f)){
          if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("High")){
            if(myHeight == true){
              locations.Add(7);
            }
          }
          else if(whatHit.collider.gameObject.layer == LayerMask.NameToLayer("Low")){
            if(myHeight == false){
              locations.Add(8);
            }
          }
        }
        if(locations.Count == 0){
          watcher = true;
          Destroy(GetComponent<Enemies>());
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
