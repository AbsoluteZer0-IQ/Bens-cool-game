using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMove : MonoBehaviour
{
    [Range(0, 100)]
    public int speed;
    [Range(0, 100)]
    public int jSpeed;
    [Range(0, 100)]
    public int mSpeed;
    public float MouseX, MouseY;
    public Vector3 look, mover;
    //public Generation script;
    public Noise script;
    public bool onFloor;
    public int test = 0;

    void Start(){
      onFloor = false;
      Cursor.lockState = CursorLockMode.Locked;
      if(SceneManager.GetActiveScene().buildIndex == 1){
        script = GameObject.Find("NoiseMaker").GetComponent<Noise>();
    //    script = GameObject.Find("Creator").GetComponent<Generation>();
        transform.position = new Vector3(0, 6, 0);
      }
    }
    void OnTriggerEnter(Collider other){
      if(other.CompareTag("Ground")){
        onFloor = true;
        test = 0;
      }
      if(other.CompareTag("Basic")){
        PlayerPrefs.SetInt("xMax", Random.Range(15, 26));
        PlayerPrefs.SetInt("yMax", Random.Range(15, 26));
        PlayerPrefs.SetInt("zMax", Random.Range(15, 26));
        SceneManager.LoadScene(1);
      }
      if(other.CompareTag("Tower")){
        PlayerPrefs.SetInt("xMax", Random.Range(5, 11));
        PlayerPrefs.SetInt("yMax", Random.Range(100, 151));
        PlayerPrefs.SetInt("zMax", Random.Range(5, 11));
        SceneManager.LoadScene(1);
      }
      if(other.CompareTag("Maze")){
        PlayerPrefs.SetInt("xMax", Random.Range(40, 51));
        PlayerPrefs.SetInt("yMax", Random.Range(2, 6));
        PlayerPrefs.SetInt("zMax", Random.Range(40, 51));
        SceneManager.LoadScene(1);
      }
      if(other.CompareTag("Kill")){
        SceneManager.LoadScene(0);
      }
    }
//    void OnTriggerExit(Collider other){
  //    if (other.CompareTag("Ground")){
  //      onFloor = false;
  //    }
//    }
    void Update(){
      //  mover = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//        MouseY = Input.GetAxis("Mouse Y") * mSpeed;
        MouseX = Input.GetAxis("Mouse X") * mSpeed;
        transform.Rotate(MouseY, MouseX, 0);
        if(Input.GetAxisRaw("Jump") == 1){
          //onFloor = false;
          GetComponent<Rigidbody>().AddForce(transform.up * jSpeed * Time.deltaTime);
        }
        }
    void FixedUpdate(){
        if(Input.GetAxisRaw("Vertical") == 1){
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
    }
}
