using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Weapon : MonoBehaviour
{
    public NewMove script;
    public Animator shoot;
    public GameObject bullet, bomb;
    public Transform thisTrans;
    public bool blocker = false;

    void Start()
    {
      script = GameObject.Find("Player").GetComponent<NewMove>();
      shoot = GetComponent<Animator>();
      thisTrans = GetComponent<Transform>();
    }

    void Update()
    {
    //  transform.Rotate(0, 0, Input.GetAxis("Mouse Y") * script.mSpeed * -1);
      if(Input.GetMouseButton(0) && !blocker){
        blocker = true;
        StartCoroutine(Fire());
      }
      else if(Input.GetMouseButton(1) && !blocker){
        blocker = true;
        StartCoroutine(BigFire());
      }
    }

    IEnumerator Fire(){
      shoot.SetBool("DoThing", true);
      yield return new WaitForSeconds(0.416665f);
      Instantiate(bullet, bullet.transform.position, Quaternion.identity, thisTrans);
      yield return new WaitForSeconds(0.416665f);
      shoot.SetBool("DoThing", false);
      blocker = false;
      StopCoroutine(Fire());
    }
    IEnumerator BigFire(){
      shoot.SetBool("DoThing", true);
      yield return new WaitForSeconds(0.416665f);
      Instantiate(bomb, bomb.transform.position, Quaternion.identity, thisTrans);
      yield return new WaitForSeconds(0.416665f);
      shoot.SetBool("DoThing", false);
      blocker = false;
      StopCoroutine(Fire());
    }
}
