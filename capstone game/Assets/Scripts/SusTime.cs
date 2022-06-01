using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusTime : MonoBehaviour
{
    public GameObject susBoi;
    void Start()
    {
        StartCoroutine(Amogus());
    }

    IEnumerator Amogus(){
      for(int i = 0; i < 101; i++){
        Instantiate(susBoi, new Vector3(Random.Range(-12, 14), 48, Random.Range(-10, 13)), Quaternion.identity);
        yield return new WaitForSeconds(1);
      }
    }
}
