using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingFloor : MonoBehaviour
{
    public Generation script;

    void Start()
    {
        script = GameObject.Find("Creator").GetComponent<Generation>();
        GetComponent<BoxCollider>().size = new Vector3(Mathf.Pow(script.maxX, 2) * script.maxY, 1f, Mathf.Pow(script.maxZ, 2) * script.maxY);
    }

}
