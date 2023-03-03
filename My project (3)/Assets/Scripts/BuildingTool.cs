using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTool : MonoBehaviour
{
    public float rootObjectUpMultiplier = 2f;
    public bool mode;
    public float rayDist;
    public GameObject prefab;
    public GameObject prefab1;
    public GameObject SelectedPrefab;
    public int blockid;
    GameObject previewObject;

    public Camera cam;
    Animator anim;

    GameObject rootObject;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame

    private void Update()
    {
        InstantiateAtMousePos();
        CheckForLaunch();
        CheckForPrefab();
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

                // JOS OLET JO LUONUT ROOT OBJEKTIN JA ET OSU BUILDINGBLOCKKIIN POISTU TÄSTÄ KOKONAAN
                if (rootObject != null && !objectHit.GetComponent<BuildingBlock>())
                    return;
                

                GameObject newObj = Instantiate(SelectedPrefab, newPos, Quaternion.identity);

                if (rootObject == null)
                {
                    rootObject = newObj;
                    rootObject.transform.position += Vector3.up * rootObjectUpMultiplier;
                }

                if (objectHit.GetComponent<BuildingBlock>())
                {
                    newObj.transform.parent = objectHit;
                }

                
                SelectedPrefab.transform.rotation = Quaternion.Euler(0,90,0);
                
                
                Debug.Log("Placed " + SelectedPrefab.name + " on " + objectHit.name);
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

    void CheckForLaunch()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (rootObject != null)
            {
                Rigidbody rb = rootObject.AddComponent<Rigidbody>();
                rb.mass = rootObject.transform.childCount;
            }
        }
    }

    void CheckForPrefab()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedPrefab = prefab1;
            blockid = 1;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedPrefab = prefab;
            blockid = 0;
        }
    }
}
