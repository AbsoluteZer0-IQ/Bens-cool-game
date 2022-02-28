using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCon : MonoBehaviour
{
  public Transform spot;
  public NewMove script;
  public float thing;
    // Start is called before the first frame update
    void Start()
    {
      script = GameObject.Find("Player").GetComponent<NewMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = spot.transform.position;
//        transform.rotation = spot.transform.rotation;
        thing = (Input.GetAxis("Mouse Y") * script.mSpeed * -1);
        transform.Rotate(Input.GetAxis("Mouse Y") * script.mSpeed * -1, 0, 0);

    }
}
