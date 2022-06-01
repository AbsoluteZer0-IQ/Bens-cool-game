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
    public int coin, dice, rot, susChance;
    public bool spawnSus = true;
    public Vector3 startPos, aboveStart;
    public GameObject player;

    void Start()
    {
      player = GameObject.Find("Player");
      maxX = PlayerPrefs.GetInt("xMax");
      maxY = PlayerPrefs.GetInt("yMax");
      maxZ = PlayerPrefs.GetInt("zMax");
      startPos = new Vector3(Random.Range(0, maxX+1) * 10, Random.Range(0, maxY+1) * 10, Random.Range(0, maxZ+1) * 10);
      aboveStart = new Vector3(startPos.x, startPos.y + 10, startPos.z);
      player.transform.position = aboveStart;
      xpos = Enumerable.Range(0, maxX + 1).ToArray();
      ypos = Enumerable.Range(0, maxY + 1).ToArray();
      zpos = Enumerable.Range(0, maxZ + 1).ToArray();
      susChance = Random.Range(0, 1001);

      for(int a=0; a<maxX; a++){
        for(int b=0; b<maxY; b++){
          for(int c=0; c<maxZ; c++){
            coin = Random.Range(0, 2);
            if(coin == 1){
              dice = Random.Range(0, 6);
              if(dice == 2){
                rot = 90;
              }
              else{
                rot = -90;
              }
              Instantiate(prefabs[dice], new Vector3(xpos[a] * 10, ypos[b] * 10, zpos[c] * 10), Quaternion.Euler(rot, 0, 0));
            }
            else if(susChance == 69 && spawnSus){
              spawnSus = false;
              Instantiate(prefabs[7], new Vector3(xpos[a] * 10, ypos[b] * 10, zpos[c] * 10), Quaternion.Euler(0, 0, 0));
            }
          }
        }
      }
      if(spawnSus){
        Instantiate(prefabs[7], new Vector3(Random.Range(0, maxX), Random.Range(0, maxY), Random.Range(0, maxZ)), Quaternion.Euler(0, 0, 0));
      }
    }
}
