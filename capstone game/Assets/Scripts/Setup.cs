using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public GameObject oldGen, newGen;

    void Awake()
    {
      if(PlayerPrefs.GetInt("genType") == 1){
        newGen.SetActive(false);
        oldGen.SetActive(true);
      }
      else{
        oldGen.SetActive(false);
        newGen.SetActive(true);
      }
    }
}
