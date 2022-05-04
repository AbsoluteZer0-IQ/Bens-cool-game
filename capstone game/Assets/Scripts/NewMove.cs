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
    public float MouseX, MouseY, jUp, jDown;
    public Vector3 look, mover;
    //public Generation script;
    public Noise script;
    public bool onFloor;
    public int test = 0;
    public Rigidbody rb;
    public GameObject thing;

    void Start(){
      onFloor = false;
      Cursor.lockState = CursorLockMode.Locked;
      Application.targetFrameRate = -1;
      rb = GetComponent<Rigidbody>();
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
      if(other.CompareTag("StartEnemy")){
        other.GetComponent<Transform>().GetChild(0).gameObject.AddComponent<Enemies>();;
      }
    }

    void Update(){
        if(transform.position.y < -5){
          SceneManager.LoadScene(0);
        }

        MouseX = Input.GetAxis("Mouse X") * mSpeed;
        transform.Rotate(MouseY, MouseX, 0);

        if(rb.velocity.y < 0){
          rb.velocity += Vector3.up * jUp * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump")){
          rb.velocity += Vector3.up * jDown * Time.deltaTime;
        }
        if(Input.GetButtonDown("Jump") && onFloor){
          onFloor = false;
          rb.velocity = Vector3.up * jSpeed;
        }
      }
    void FixedUpdate(){
        if(Input.GetAxisRaw("Vertical") == 1){
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
    }
}
