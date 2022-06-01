using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public int spinSpeed;
    public GameObject plyer, line;
    public bool canLine = true, slide = true;
    public Vector3 pos;

    void Start(){
      plyer = GameObject.Find("Player");
      line = GameObject.Find("SusDetector");
      pos = transform.position;
    }

    void Update()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
        if(slide){
          transform.Translate(Vector3.up * Time.deltaTime);
        }
        else if(!slide){
          transform.Translate(Vector3.down * Time.deltaTime);
        }
        if(transform.position.y >= pos.y + 0.5f){
          slide = false;
        }
        else if(transform.position.y <= pos.y - 0.5f){
          slide = true;
        }
        if(Input.GetKeyDown("e") && canLine){
          StartCoroutine(Paint());
        //  Debug.DrawRay(transform.position, plyer.transform.position - transform.position, Color.green, 5f, false);
        }
    }
    IEnumerator Paint(){
      canLine = false;
      line.GetComponent<LineRenderer>().SetPosition(0, plyer.transform.position);
      line.GetComponent<LineRenderer>().SetPosition(1, transform.position);
      line.GetComponent<LineRenderer>().enabled = true;
      yield return new WaitForSeconds(5);
      line.GetComponent<LineRenderer>().enabled = false;
      yield return new WaitForSeconds(30);
      canLine = true;
      StopCoroutine(Paint());
    }
}
