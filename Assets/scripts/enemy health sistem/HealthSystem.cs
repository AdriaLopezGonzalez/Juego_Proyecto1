using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, EnemyTakeDamage
{
    float _currentHealth;

    [SerializeField]
    float _maxHealth;
    public static Action<float> HealthChanged;
    public GameObject particlePrefab;
   
    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth / _maxHealth);
        
    }

    public float CurrentHealth => _currentHealth;
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth / _maxHealth);
        var particle = Instantiate(particlePrefab,GetComponent<Transform>().position,GetComponent<Transform>().rotation);
        
        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
}
