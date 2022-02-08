using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public GameObject cube;
    public int[] xpos = new int[] {1, 2, 3, 4, 5};
    public int[] ypos = new int[] {1, 2, 3, 4, 5};
    public int[] zpos = new int[] {1, 2, 3, 4, 5};
    public int coin;
    // Start is called before the first frame update
    void Start()
    {
      for(int a=0; a<5; a++){
        for(int b=0; b<5; b++){
          for(int c=0; c<5; c++){
            coin = Random.Range(0, 2);
            if(coin == 1){
                          Instantiate(cube, new Vector3(xpos[a] * 10, ypos[b] * 10, zpos[c] * 10), Quaternion.identity);
            }
          }
        }
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
