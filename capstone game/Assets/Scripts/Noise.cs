using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Noise : MonoBehaviour
{
    [Range(0, 100)]
    public float exe, why, zed;
    public Vector3 test;
    public float d, e, f, cool, mixer;

    public GameObject[] prefabs;
    [Range(0, 1000)]
    public int maxX;
    [Range(0, 1000)]
    public int maxY;
    [Range(0, 1000)]
    public int maxZ;
    public int[] xpos;
    public int[] ypos;
    public int[] zpos;
    public int block, rotx, roty, randrot;

    void Start(){
      mixer = (Random.Range(10, 101));

      xpos = Enumerable.Range(0, maxX + 1).ToArray();
      ypos = Enumerable.Range(0, maxY + 1).ToArray();
      zpos = Enumerable.Range(0, maxZ + 1).ToArray();

      for(int a=0; a<maxX; a++){
        for(int b=0; b<maxY; b++){
          for(int c=0; c<maxZ; c++){

              exe = xpos[a] * 10f;
              why = ypos[b] * 10f;
              zed = zpos[c] * 10f;
              test = new Vector3(exe, why, zed);
              d = Mathf.PerlinNoise(test.x/mixer, test.y/mixer);
              e = Mathf.PerlinNoise(test.x/mixer, test.z/mixer);
              f = Mathf.PerlinNoise(test.y/mixer, test.z/mixer);
              cool = (d+e+f)/3;
              //Debug.Log(cool);

              if((cool < 0.275) || (cool > 0.625)){
                Debug.Log("nothing");
              }
              else if((0.275 < cool && cool < 0.31) || (0.59 < cool && cool < 0.625)){
                block = 0;
                rotx = -90;
                roty = 0;
              }
              else if((0.31 < cool && cool < 0.345) || (0.555 < cool && cool < 0.59)){
                block = 1;
                rotx = -90;
                roty = 0;
              }
              else if((0.345 < cool && cool < 0.38) || (0.52 < cool && cool < 0.555)){
                block = 2;
                rotx = 90;
                randrot = Random.Range(1, 5);
                switch(randrot){
                  case 1:
                    roty = 0;
                    break;
                  case 2:
                    roty = 90;
                    break;
                  case 3:
                    roty = 180;
                    break;
                  case 4:
                    roty = 270;
                    break;
                  default:
                    roty = 0;
                    break;
                }
              }
              else if((0.38 < cool && cool < 0.415) || (0.485 < cool && cool < 0.52)){
                block = 3;
                rotx = -90;
                roty = 0;
              }
              else if((0.415 < cool && cool < 0.45) || (0.45 < cool && cool < 0.485)){
                block = 4;
                rotx = -90;
                roty = 0;
              }

              Instantiate(prefabs[block], new Vector3(exe, why, zed), Quaternion.Euler(rotx, roty, 0));
            }
          }
        }
      }
  //  void Update()
//    {
    //  if(Input.GetKeyDown(KeyCode.E)){
  //      for(int i=0; i<10; i++){
  //      test = new Vector3(exe, why, zed);
  //        a = Mathf.PerlinNoise(test.x/mixer, test.y/mixer);
  //        b = Mathf.PerlinNoise(test.x/mixer, test.z/mixer);
    //      c = Mathf.PerlinNoise(test.y/mixer, test.z/mixer);
    //      cool = (a+b+c)/3;
    //      Debug.Log(cool);
    //      exe += 10f;
    //      why += 10f;
    //      zed += 10f;
    //    }
  //    }
//    }
}
