using System.Collections;
using UnityEngine;

public class VineSummoner : MonoBehaviour
{
    private Animator animator;
    private float despawnDelay;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Initialize(float despawnDelay)
    {
        this.despawnDelay = despawnDelay;
        animator.SetTrigger("Summon");

        StartCoroutine(DespawnAfterDelay());
    }

    private IEnumerator DespawnAfterDelay()
    {
        yield return new WaitForSeconds(despawnDelay);

        animator.SetTrigger("Desummon");
        yield return new WaitForSeconds(1f);            
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Stun();
            }
        }
    }
}
