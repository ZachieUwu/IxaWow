using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineController : MonoBehaviour
{
    private Animator animator;
    public float lifeDuration = 5f;
    public float outroAnimationDuration = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();

        PlayGrow();

        Invoke("PlayOutro", lifeDuration);
    }

    void PlayGrow()
    {
        if (animator != null)
        {
            animator.Play("IxaSpawn");
        }
    }

    void PlayOutro()
    {
        if (animator != null)
        {
            animator.Play("IxaDespawn");

            Destroy(gameObject, outroAnimationDuration);
        }
    }
}
