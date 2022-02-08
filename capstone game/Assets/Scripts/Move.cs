using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController mover;
    public int speed = 5;
    public bool groundedPlayer;
    public Vector3 playerVelocity;
    public float jump = 2;
    public float gravityValue = -10;


    void Start()
    {
      mover = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      groundedPlayer = mover.isGrounded;
      Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      mover.Move(move * Time.deltaTime * speed);

      if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += jump;
        }
      if(groundedPlayer == false){
        playerVelocity.y += gravityValue * Time.deltaTime;
      }
        mover.Move(playerVelocity * Time.deltaTime);

    }
}
