using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    Color origColor;
    Material material;
    float flashTime = .15f;

    // Start is called before the first frame update
    void Start()
    {
        //on start fills in variable
        //origColor = m.material.color;
        material = enemy.GetComponent<MeshRenderer>().material;
        origColor = material.color;
    }


    public void FlashStart()
    {
        

        if (material.color != Color.red)
        {
            material.color = Color.red;
        }

        Invoke("FlashStop", flashTime);
    }

    public void FlashStop()
    {
        
        material.color = origColor;
    }
}
