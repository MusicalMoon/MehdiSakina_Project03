using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class HealthBar : MonoBehaviour
{

    [SerializeField] private Image _FronthealthBarSprite;
    [SerializeField] private Image _backhealthBarSprite;
    private float math;

    [SerializeField] float chipTime = 0.5f;

    private Camera _cam;


    // Start is called before the first frame update
    private void Start()
    {
        _cam = Camera.main;
    }

    
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        //float backFill = _backhealthBarSprite.fillAmount;
        math = currentHealth / maxHealth;
        _FronthealthBarSprite.fillAmount = math;

    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);

        _backhealthBarSprite.fillAmount = Mathf.MoveTowards(_backhealthBarSprite.fillAmount,
            math, chipTime * Time.deltaTime);
    }

}
