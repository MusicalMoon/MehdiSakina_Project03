using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //heaalth changeable for object
    [SerializeField] public int _maxHealth = 3;

    //healthbar variables
    private int _currentHealth;
    [SerializeField] private healthBar _healthBar;

    [SerializeField] int _DamageAmount;

    private void Start()
    {
        _currentHealth = _maxHealth;
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
        

            if (_currentHealth > 0)
            {
                //particle
                _currentHealth -= DamageAmount;
                Debug.Log("Health Remaining" + _maxHealth);

                _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
            }   
           

            if(_currentHealth <= 0)
            {
                Die();
            }
            
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

