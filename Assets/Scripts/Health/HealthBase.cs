using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour

{
    public Action OnKill;
    public int startLife = 10;

    
    public bool destroyOnKill = false;
    public float delayOnKill = 0f;


    private float _currentLife;
    private bool _isDead = false;
   public FlashColor flashColor;
    
    
    private void Awake()
    {
        Init();
        if (flashColor == null )
            flashColor = GetComponent<FlashColor>();
    }
    private void Init() {
        _isDead = false;
        _currentLife = startLife;
    }

    public void damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage; 
        if(_currentLife <= 0 )
        {
            kill();
        }
        if (flashColor != null)
            flashColor.flash();
    }

    private void kill()
    {
        _isDead=true;
        if(destroyOnKill ) {
            Destroy(gameObject, delayOnKill);
        }

        OnKill?.Invoke();
    }
}
