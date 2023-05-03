using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    Material origColor;
    float flashTime = .15f;

    // Start is called before the first frame update
    void Start()
    {
        //on start fills in variable
        //origColor = m.material.color;
        //origColor = enemy.GetComponent<MeshRenderer>();

    }


    public void FlashStart()
    {
        //meshRenderer.material.color = Color.red;
        var asdf = enemy.GetComponent<MeshRenderer>().material;

        if (asdf.color != Color.red)
        {
            asdf.color = Color.red;
        }

        Invoke("FlashStop", flashTime);
    }

    public void FlashStop()
    {
        var asdf = enemy.GetComponent<MeshRenderer>().material;
        asdf.color = Color.blue;
    }
}
