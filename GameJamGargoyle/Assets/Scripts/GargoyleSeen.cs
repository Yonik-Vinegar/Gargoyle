using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GargoyleScript : MonoBehaviour
{
    public GameObject gargoyle;
    public bool die = false;
    public Image gameOver;
    Color currentColour;
    static public bool isSeen = false;
    //Renderer gargoyleRenderer;
    //MeshRenderer gargoyleRenderer;
    SkinnedMeshRenderer gargoyleRenderer;
    int layerMask = 1 << 7;
    // Start is called before the first frame update
    void Start()
    {
        gargoyleRenderer = gargoyle.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (die)
        {
            while (Mathf.Abs(currentColour.a - 1f) > 0.0001f)
            {
                currentColour.a = Mathf.Lerp(currentColour.a, 1f, 50f * Time.deltaTime);
                gameOver.color = currentColour;
                currentColour.r = 255f;
                currentColour.g = 255f;
                currentColour.b = 255f;
            }
            if (currentColour.a == 255) { SceneManager.LoadScene("Menu"); }
        }
        if (gargoyleRenderer.isVisible)
        {
            RaycastHit distance;
            if (Physics.Raycast(transform.position, (gargoyle.transform.parent.position - transform.position), out distance, 7.5f, layerMask))
            {
                isSeen = true;
            }
            else isSeen = false;
        }
        else isSeen = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gargoyle" && !GargoyleScript.isSeen)
        {
            die = true;
        }
    }
}
