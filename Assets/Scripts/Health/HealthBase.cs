using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    
    public bool destroyOnKill = false;
    public float delayOnKill = 0f;


    private float _currentLife;
    private bool _isDead = false;

    
    
    private void Awake()
    {
        Init();
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
    }

    private void kill()
    {
        _isDead=true;
        if(destroyOnKill ) {
            Destroy(gameObject, delayOnKill);
        }
    }
}
