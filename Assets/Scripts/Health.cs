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
    

    private void Start()
    {
        _currentHealth = _maxHealth;
        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(_DamageAmount);
            //_flash.FlashStart();
           
        }
    }

    public void TakeDamage(int DamageAmount)
    {
        
            if (_currentHealth > 0)
            {
                //particle
                _currentHealth -= DamageAmount;
                _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
            }   
           

            if(_currentHealth <= 0)
            {

                //WaitForSeconds(2);
                RigidBody();
            }
        
    }
    private void RigidBody()
    {
        
        //Rigidbody gameObjectsRigidBody = this.AddComponent<Rigidbody>(); // Add the rigidbody.
        //gameObjectsRigidBody.mass = 5; // Set the GO's mass to 5 via the Rigidbody.

        Invoke("Die", 3);
    }

    private void Die()
    {
        
        gameObject.SetActive(false);
    }
}

