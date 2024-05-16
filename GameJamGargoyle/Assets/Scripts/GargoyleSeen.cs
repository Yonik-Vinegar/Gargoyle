using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleScript : MonoBehaviour
{
    public GameObject gargoyle;
    static public bool isSeen;
    Renderer gargoyleRenderer;
    int layerMask = 1 << 7;
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
            if (Physics.Raycast(transform.position, (gargoyle.transform.position - transform.position), out distance, 7f, layerMask))
            {
                isSeen = true;
            }
            else isSeen = false;
        }
        else isSeen = false;
    }
}
