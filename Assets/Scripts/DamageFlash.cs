using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{

    Material meshRenderer;
    Color origColor;
    float flashTime = .15f;

    // Start is called before the first frame update
    void Start()
    {
        //on start fills in variable
        //origColor = m.material.color;
        GetComponent<Material>().color = Color.red;
    }


    public void FlashStart()
    {
        //meshRenderer.material.color = Color.red;
        Invoke("FlashStop", flashTime);
    }

    public void FlashStop()
    {
        //meshRenderer.material.color = origColor;
    }
}
