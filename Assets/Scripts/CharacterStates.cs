using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStates : MonoBehaviour
{
    public int NumLivesRemaining;

    public int CurrentHealth;
    public int MaxHealth;    

    void Awake()
    {
        Events.PlayerDamaged.AddListener(Hit);
        Events.PlayerRespawned.AddListener(Respawn);
        Events.LivesRemainingIncrease.AddListener(IncreaseLives);
        Events.HealthPickedUp.AddListener(IncreaseCurrentHealth);
    }

    private void Start()
    {        
        CurrentHealth = MaxHealth;
        Events.PlayerHealthChanged.Invoke(CurrentHealth);
        Events.PlayerLivesChanged.Invoke(NumLivesRemaining);
    }

    [ContextMenu("Hit")]
    void Hit()
    {
        CurrentHealth--;
        Events.PlayerHealthChanged.Invoke(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Events.PlayerDied.Invoke();
        }
    }

    void Respawn()
    {
        NumLivesRemaining--;
        Events.PlayerLivesChanged.Invoke(NumLivesRemaining);
        if (NumLivesRemaining < 0)
        {
            Events.PlayerOutOfLives.Invoke();
        }
        CurrentHealth = MaxHealth;
        Events.PlayerHealthChanged.Invoke(CurrentHealth);
    }

    void IncreaseLives()
    {
        NumLivesRemaining++;
    }

    void IncreaseCurrentHealth()
    {
        if(CurrentHealth == MaxHealth)
        {
            Events.PlayerAtMaxHealth.Invoke();
        }
        else
        {
            CurrentHealth++;
        }
    }
}

