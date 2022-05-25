using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public int spinSpeed;
    public GameObject plyer, line;

    void Start(){
      plyer = GameObject.Find("Player");
      line = GameObject.Find("SusDetector");
    }

    void Update()
    {
        transform.Rotate(0, spinSpeed*Time.deltaTime, 0);
        if(Input.GetKeyDown("e")){
          StartCoroutine(Paint());
        //  Debug.DrawRay(transform.position, plyer.transform.position - transform.position, Color.green, 5f, false);
        }
    }
    IEnumerator Paint(){
      line.GetComponent<LineRenderer>().SetPosition(0, plyer.transform.position);
      line.GetComponent<LineRenderer>().SetPosition(1, transform.position);
      line.GetComponent<LineRenderer>().enabled = true;
      yield return new WaitForSeconds(5);
      line.GetComponent<LineRenderer>().enabled = false;
    }
}
