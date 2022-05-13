using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Range(0, 25)]
    public int speed;

    void Start()
    {
        transform.localPosition = new Vector3(-3, 0.28f, 0);
        transform.localRotation = Quaternion.Euler(90, 0, 90);
    }

    void Update()
    {
      transform.position += transform.up * Time.deltaTime * speed;
    }
}
