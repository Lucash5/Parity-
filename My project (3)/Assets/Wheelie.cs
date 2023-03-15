using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelie : MonoBehaviour
{
    public GameObject wheel;
    public GameObject staticpart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wheel.transform.position = new Vector3(staticpart.transform.position.x + 1, staticpart.transform.position.y, staticpart.transform.position.z);
    }
}
