using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlockBehaviour : MonoBehaviour
{
    public GameObject prefab1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }


    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
        }
    }
}
