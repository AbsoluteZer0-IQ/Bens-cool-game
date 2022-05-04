using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public Enemies script;

    void Start(){
      script = GetComponent<Enemies>();
    }

    void Update()
    {
      script = GetComponent<Enemies>();
      if(transform.position.y < -5){
        Destroy(gameObject);
      }
      if(script.watcher == true){
        script.watcher = false;
        StartCoroutine(Reset());
      }
    }

    IEnumerator Reset(){
      yield return new WaitForSeconds(2);
      gameObject.AddComponent<Enemies>();
      StopCoroutine(Reset());
    }
}
