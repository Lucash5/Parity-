using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTool : MonoBehaviour
{
    public bool mode;
    public float rayDist;
    public GameObject prefab;
    GameObject previewObject;

    public Camera cam;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame

    private void Update()
    {
        InstantiateAtMousePos();
    }

    void InstantiateAtMousePos()
    {
        RaycastHit hit;


        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out hit, rayDist))
        {
            Transform objectHit = hit.transform;

            Vector3 newPos = hit.point;
            newPos.x = Mathf.Round(newPos.x);
            newPos.y = Mathf.Round(newPos.y);
            newPos.z = Mathf.Round(newPos.z);

            //place the object when left click is pressed
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log(Vector3.Distance(cam.transform.position, hit.point));
                GameObject newObj = Instantiate(prefab, newPos, Quaternion.identity);

                if (objectHit.GetComponent<BuildingBlock>())
                {
                    newObj.transform.parent = objectHit;
                }

                Debug.Log("Placed " + prefab.name + " on " + objectHit.name);
                anim.Play("PlaceBlock");
            }

            if (Input.GetMouseButtonDown(0) && hit.transform.GetComponent<BuildingBlock>())
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * rayDist);
    }
}
