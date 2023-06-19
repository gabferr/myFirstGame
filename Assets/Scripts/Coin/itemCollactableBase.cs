using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public new ParticleSystem particleSystem;
    public int timeToHide = 3;
    public GameObject graphicItem;
    private void Awake()
    {
       // if (particleSystem != null) particleSystem.transform.SetParent(null);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(compareTag)) {
            Collect();
        }
            
    }
    protected virtual void Collect() {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    protected virtual void OnCollect() {
    if(particleSystem != null) particleSystem.Play();
        
    }
}
