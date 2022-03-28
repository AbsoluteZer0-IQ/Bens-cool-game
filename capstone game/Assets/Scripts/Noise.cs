using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    [Range(0, 1)]
    public float exe, why, zee;
    public Vector3 test;
    public float a, b, c, cool;

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.E)){
        for(int i=0; i<10; i++){
          test = new Vector3(exe, why, zee);
          a = Mathf.PerlinNoise(test.x, test.y);
          b = Mathf.PerlinNoise(test.x, test.z);
          c = Mathf.PerlinNoise(test.y, test.z);
          cool = (a+b+c)/3;
          Debug.Log(cool);
          exe += 0.01f;
          why += 0.01f;
          zee += 0.01f;
        }
      }
    }
}
