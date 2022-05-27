using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    [Range(0, 25)]
    public int speed;
    public GameObject gun, destroyer;

    void Start()
    {
        transform.localPosition = new Vector3(-3.4f, 0.28f, 0);
        transform.localRotation = Quaternion.Euler(90, 0, 90);
        transform.parent = null;
        gun = GameObject.Find("Gun 1");
        Physics.IgnoreCollision(GetComponent<Collider>(), gun.GetComponent<Collider>());
        StartCoroutine(KillMe());
    }

    void Update()
    {
      transform.position += transform.up * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision other){
      if(speed == 15){
        if(other.collider.CompareTag("Construction") || other.collider.CompareTag("Enemy")){
          Destroy(other.gameObject);
          Destroy(gameObject);
        }
        else if(other.collider.CompareTag("Player")){
          SceneManager.LoadScene(0);
        }
      }
      else if(speed == 5){
        if(other.collider.CompareTag("Construction") || other.collider.CompareTag("Enemy")){
          Instantiate(destroyer, transform.position, Quaternion.identity);
          Destroy(gameObject);
        }
        else if(other.collider.CompareTag("Player")){
          SceneManager.LoadScene(0);
        }
      }
    }

    IEnumerator KillMe(){
      yield return new WaitForSeconds(5);
      Destroy(gameObject);
    }
}
