using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    [Range(0, 100)]
    public float exe, why, zee;
    public Vector3 test;
    public float a, b, c, cool, mixer;

    void Start(){
      mixer = (Random.Range(10, 101));
    }
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.E)){
        for(int i=0; i<10; i++){
          test = new Vector3(exe, why, zee);
          a = Mathf.PerlinNoise(test.x/mixer, test.y/mixer);
          b = Mathf.PerlinNoise(test.x/mixer, test.z/mixer);
          c = Mathf.PerlinNoise(test.y/mixer, test.z/mixer);
          cool = (a+b+c)/3;
          Debug.Log(cool);
          exe += 10f;
          why += 10f;
          zee += 10f;
        }
      }
    }
}
