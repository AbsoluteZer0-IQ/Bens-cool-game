using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController mover;
    public int speed = 5;
    public bool groundedPlayer, help;
    public Vector3 playerVelocity;
    public int jumper = 0;
    public float garvity = -10, chngrv;

    void Start()
    {
      mover = GetComponent<CharacterController>();
      help = true;
    }

    // Update is called once per frame
    void Update()
    {
    //  if(mover.isGrounded){
  //      garvity = 0f;
  //    }
  //    else if(jumper > 0){
//        garvity = chngrv;
//      }
//      else{
//        garvity = -chngrv;
    //  if(jumper > 0){
    //    jumper--;
    //  }
    if(Input.GetAxis("Jump") == 1 && mover.isGrounded){
      jumper = 1;
    }
    if(jumper > 0 && help){
      help = false;
      for(int i=-2; i<3; i++){
        garvity = (-Mathf.Pow(i, 2) + 5) ;
        jumper--;
        Debug.Log("cum");
      }
    }
      Vector3 move = new Vector3(Input.GetAxis("Horizontal"), garvity, Input.GetAxis("Vertical"));
      mover.Move(move * Time.deltaTime * speed);
    }
}
