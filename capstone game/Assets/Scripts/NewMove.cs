using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMove : MonoBehaviour
{
    [Range(0, 100)]
    public int speed, jSpeed, mSpeed, dSpeed;
    public float MouseX, MouseY, jUp, jDown;
    public Vector3 look, mover;
    //public Generation script;
    public Noise script;
    public bool onFloor, zoom = false, doMenu = false;
    public int test = 0, type;
    public Rigidbody rb;
    public GameObject thing, menu;

    void Start(){
      onFloor = false;
      zoom = true;
      Cursor.lockState = CursorLockMode.Locked;
      Application.targetFrameRate = -1;
      rb = GetComponent<Rigidbody>();
      menu = GameObject.Find("Canvas");
    //  transform.position = GameObject.Find("Start(Clone)").transform.position + new Vector3(0, 6, 0);
    //  if(SceneManager.GetActiveScene().buildIndex == 1){
    //  script = GameObject.Find("NoiseMaker").GetComponent<Noise>();
    //    script = GameObject.Find("Creator").GetComponent<Generation>();
    //  transform.position = script.aboveStart;
    //  }
    }
    void OnTriggerEnter(Collider other){
      if(other.CompareTag("Ground")){
        onFloor = true;
        test = 0;
      }
      else if(other.CompareTag("Basic")){
        PlayerPrefs.SetInt("xMax", Random.Range(15, 26));
        PlayerPrefs.SetInt("yMax", Random.Range(15, 26));
        PlayerPrefs.SetInt("zMax", Random.Range(15, 26));
        PlayerPrefs.SetInt("genType", 0);
        SceneManager.LoadScene(1);
      }
      else if(other.CompareTag("Tower")){
        PlayerPrefs.SetInt("xMax", Random.Range(5, 11));
        PlayerPrefs.SetInt("yMax", Random.Range(100, 151));
        PlayerPrefs.SetInt("zMax", Random.Range(5, 11));
        PlayerPrefs.SetInt("genType", 0);
        SceneManager.LoadScene(1);
      }
      else if(other.CompareTag("Maze")){
        PlayerPrefs.SetInt("xMax", Random.Range(40, 51));
        PlayerPrefs.SetInt("yMax", Random.Range(2, 6));
        PlayerPrefs.SetInt("zMax", Random.Range(40, 51));
        PlayerPrefs.SetInt("genType", 0);
        SceneManager.LoadScene(1);
      }
      else if(other.CompareTag("Kill")){
        SceneManager.LoadScene(0);
      }
      else if(other.CompareTag("StartEnemy")){
        other.GetComponent<Transform>().GetChild(0).gameObject.AddComponent<Enemies>();;
      }
      else if(other.CompareTag("Sussy")){
        SceneManager.LoadScene(2);
      }
      else if(other.CompareTag("Classic")){
        PlayerPrefs.SetInt("genType", 1);
        type = Random.Range(0, 3);
        switch(type){
          case 0:
            PlayerPrefs.SetInt("xMax", Random.Range(15, 26));
            PlayerPrefs.SetInt("yMax", Random.Range(15, 26));
            PlayerPrefs.SetInt("zMax", Random.Range(15, 26));
            break;
          case 1:
            PlayerPrefs.SetInt("xMax", Random.Range(5, 11));
            PlayerPrefs.SetInt("yMax", Random.Range(100, 151));
            PlayerPrefs.SetInt("zMax", Random.Range(5, 11));
            break;
          case 2:
            PlayerPrefs.SetInt("xMax", Random.Range(40, 51));
            PlayerPrefs.SetInt("yMax", Random.Range(2, 6));
            PlayerPrefs.SetInt("zMax", Random.Range(40, 51));
            break;
        }
        SceneManager.LoadScene(1);
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
          StartCoroutine(Cooldown());
        }
        if(Input.GetKeyDown("left shift") && zoom){
          zoom = false;
          rb.velocity = transform.forward * dSpeed;
        }
        if(Input.GetKeyDown("escape") && !doMenu){
          Cursor.lockState = CursorLockMode.None;
          menu.GetComponent<CanvasGroup>().alpha = 1;
          doMenu = true;
        }
        else if(Input.GetKeyDown("escape") && doMenu){
          Cursor.lockState = CursorLockMode.Locked;
          menu.GetComponent<CanvasGroup>().alpha = 0;
          doMenu = false;
        }
      }
    void FixedUpdate(){
        if(Input.GetAxisRaw("Vertical") == 1){
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
        if(Input.GetAxisRaw("Vertical") == -1){
        GetComponent<Rigidbody>().MovePosition(transform.position + -transform.forward * Time.deltaTime * speed);
        }
        if(Input.GetAxisRaw("Horizontal") == 1){
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
        if(Input.GetAxisRaw("Horizontal") == -1){
        GetComponent<Rigidbody>().MovePosition(transform.position + -transform.right * Time.deltaTime * speed);
        }
    }
    IEnumerator Cooldown(){
      yield return new WaitForSeconds(3);
      zoom = true;
    }

    public void ByeBye(){
      Application.Quit();
    }
}
