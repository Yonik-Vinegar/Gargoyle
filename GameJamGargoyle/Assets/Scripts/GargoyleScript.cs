using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleScript : MonoBehaviour
{
    public GameObject gargoyle;
    Renderer gargoyleRenderer;
    // Start is called before the first frame update
    void Start()
    {
        gargoyleRenderer = gargoyle.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gargoyleRenderer.isVisible)
        {
            RaycastHit distance;
            if (Physics.Raycast(transform.position, (transform.position - gargoyle.transform.position), out distance, 17f))
            {
                Debug.Log("Object is visible");
            }
            else {Debug.Log("Object is no longer visible");}
        }
        else Debug.Log("Object is no longer visible");
    }
}
