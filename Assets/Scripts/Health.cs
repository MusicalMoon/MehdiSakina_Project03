using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //heaalth changeable for object
    [SerializeField] public int _maxHealth = 3;

    //healthbar variables
    private int _currentHealth;
    [SerializeField] private HealthBar _healthBar;

    [SerializeField] int _DamageAmount;


    //Flash
    private DamageFlash _flash;

    //Falling to ground
    private Rigidbody rb;

    //Particles
    [SerializeField] ParticleSystem _blood;
    [SerializeField] ParticleSystem _dead;

    //Sound
    [SerializeField] AudioSource _hurt;
    private void Start()
    {
        _currentHealth = _maxHealth;   
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        _flash = this.GetComponent<DamageFlash>();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(_DamageAmount);
        }
    }

    public void TakeDamage(int DamageAmount)
    {
        _flash.FlashStart();
        if (_currentHealth > 0)
        {
            _currentHealth -= DamageAmount;
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
        }   
           

        if(_currentHealth <= 0)
        {
            RigidBody();
        }

        if(_blood != null)
        {
            //Debug.Log("Player blood!");
            Instantiate(_blood, transform.position, transform.rotation);
            
        }
        if (_hurt != null)
        {
            //Debug.Log("Player grunt!");
            AudioSource newSound =
                    Instantiate(_hurt, transform.position, transform.rotation);
            Destroy(newSound.gameObject, newSound.clip.length);
        }
    }
    private void RigidBody()
    {

        rb.useGravity = true;
        if (_blood != null)
        /*{
            //Debug.Log("Player blood!");
            Instantiate(_blood, transform.position, transform.rotation);

        }*/

        Invoke("Die", 3);
    }

    private void Die()
    {
        if (_dead != null)
        {
            Instantiate(_dead, transform.position, transform.rotation);
        }
        gameObject.SetActive(false);
        
    }
}

