using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController mover;
    public int speed = 5;
    public bool groundedPlayer, isJump;
    public Vector3 playerVelocity;
    public int jumper = 0;
    public float upMove = 0, upInput, garvity, sign;

    void Start()
    {
      mover = GetComponent<CharacterController>();
      isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(mover.isGrounded){
        isJump = false;
      }
    if(Input.GetAxis("Jump") == 1 && mover.isGrounded){
      jumper = 1;
      isJump = true;
    }
    if(jumper > 0){
      jumper = 0;
      upInput = -2;
    }
    if(upInput < 2){
      upMove = (-Mathf.Pow(upInput, 2) + 5) * 0.0125f;
      upInput += 0.02f;
      sign = -2 * upInput;
      sign = sign/Mathf.Abs(sign);
    }
    if(!isJump){
      Vector3 move = new Vector3(Input.GetAxis("Horizontal"), garvity, Input.GetAxis("Vertical"));
      Vector3.Normalize(move);
      mover.Move(move * Time.deltaTime * speed);
    }
    else if(isJump){
      Vector3 move = new Vector3(Input.GetAxis("Horizontal"), sign * upMove * 100, Input.GetAxis("Vertical"));
      Vector3.Normalize(move);
      mover.Move(move * Time.deltaTime * speed);
    }
    }
}
