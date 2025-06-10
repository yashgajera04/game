using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthControler : MonoBehaviour
{
    [SerializeField]
    private float CurrentHealth;
    [SerializeField]
    private float MaxHealth;

    public float RemainingHealth
    {
        get { return CurrentHealth / MaxHealth; }
    }

    public bool Invisible{ get; set; }
    public UnityEvent OnDeath;
    public UnityEvent OnDamege;
    public UnityEvent OnHealthChange;
    public void TakeDameage(float damage)
    {
        if (CurrentHealth == 0)
        {
            return;
        }
        if (Invisible)
        {
            return;
        }
        CurrentHealth -= damage;
        OnHealthChange.Invoke();
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
        if (CurrentHealth == 0)
        {
            OnDeath.Invoke();
        }
        else
        {
            OnDamege.Invoke();
        }
    }

    public void AddHealth(float health)
    {
        if (CurrentHealth == MaxHealth)
        {
            return;
        }
        CurrentHealth += health;
        OnHealthChange.Invoke();
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
}
