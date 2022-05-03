using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Weapon : MonoBehaviour
{
    public NewMove script;
    public Animator shoot;

    void Start()
    {
      script = GameObject.Find("Player").GetComponent<NewMove>();
      shoot = GetComponent<Animator>();
    }

    void Update()
    {
      transform.Rotate(0, 0, Input.GetAxis("Mouse Y") * script.mSpeed * -1);
      if(Input.GetMouseButtonDown(0)){
        StartCoroutine(Fire());
      }
    }

    IEnumerator Fire(){
      shoot.SetBool("DoThing", true);
      yield return new WaitForSeconds(0.83333f);
      shoot.SetBool("DoThing", false);
    }
}
