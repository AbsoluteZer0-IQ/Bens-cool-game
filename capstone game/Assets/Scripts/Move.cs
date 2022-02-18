using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController mover;
    public int speed = 5;
    public bool groundedPlayer;
    public Vector3 playerVelocity;
    public int jumper = 0;
    public float upMove = 0, upInput;

    void Start()
    {
      mover = GetComponent<CharacterController>();
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
    if(jumper > 0){
      jumper = 0;
      upInput = -2;
    }
    if(upInput <= 2){
      upMove = (-Mathf.Pow(upInput, 2) + 5) ;
      upInput--;
    }
      Vector3 move = new Vector3(Input.GetAxis("Horizontal"), upMove, Input.GetAxis("Vertical"));
      mover.Move(move * Time.deltaTime * speed);
    }
}
