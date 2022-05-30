using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrowBoom : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Purpose());
    }
    IEnumerator Purpose(){
      for(int rad = 0; rad<11; rad++){
        GetComponent<SphereCollider>().radius = rad;
        yield return new WaitForSeconds(0.2f);
      }
      Destroy(gameObject);
    }
    void OnCollisionEnter(Collision other){
      Debug.Log(other.gameObject.name);
      if(other.gameObject.name == "Player"){
        SceneManager.LoadScene(0);
      }
      Destroy(other.gameObject);
    }
}
