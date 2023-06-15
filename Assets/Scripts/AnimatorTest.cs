using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
   public Animator animator;

   public string triggerToPlay = "Fly";
   public KeyCode keyToPlay = KeyCode.A;
   public KeyCode keyToExit = KeyCode.S;

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(keyToPlay)) {
            animator.SetBool(triggerToPlay, true);
        }
        else if(Input.GetKeyDown(keyToExit)) {
            animator.SetBool(triggerToPlay, false);
        }

    }
}
