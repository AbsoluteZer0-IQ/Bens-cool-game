using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController mover;
    public int speed = 5;
    public bool isJump;
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
    if(Input.GetAxis("Jump") == 1 && mover.isGrounded){
      jumper = 1;
      isJump = true;
    }
    if(jumper > 0){
      jumper = 0;
      upInput = -6.325f;
    }
    if(upInput < 6.325f){
      upMove = (-0.125f * Mathf.Pow(upInput, 2) + 5);
      upInput += 0.025f;
      sign = -0.250f * upInput;
      sign = sign/Mathf.Abs(sign);
    }
    if(upInput >= 6.325){
      isJump = false;
    }
    if(!isJump){
      Vector3 move = new Vector3(Input.GetAxis("Horizontal"), garvity, Input.GetAxis("Vertical"));
      Vector3.Normalize(move);
      mover.Move(move * Time.deltaTime * speed);
    }
    else if(isJump){
      Vector3 move = new Vector3(Input.GetAxis("Horizontal"), sign * upMove * 12, Input.GetAxis("Vertical"));
      Vector3.Normalize(move);
      mover.Move(move * Time.deltaTime);
    }
    }
}
