using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Generation : MonoBehaviour
{
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
    public int coin, dice, rot;

    void Start()
    {

      xpos = Enumerable.Range(0, maxX + 1).ToArray();
      ypos = Enumerable.Range(0, maxY + 1).ToArray();
      zpos = Enumerable.Range(0, maxZ + 1).ToArray();

      for(int a=0; a<maxX; a++){
        for(int b=0; b<maxY; b++){
          for(int c=0; c<maxZ; c++){
            coin = Random.Range(0, 2);
            if(coin == 1){
              dice = Random.Range(0, 5);
              if(dice == 2){
                rot = 90;
              }
              else{
                rot = -90;
              }
              Instantiate(prefabs[dice], new Vector3(xpos[a] * 10, ypos[b] * 10, zpos[c] * 10), Quaternion.Euler(rot, 0, 0));
            }
          }
        }
      }
    }
}
