using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float stunDuration = 2f;

    private bool isStunned = false;

    void Update()
    {
        if (!isStunned && player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    public void Stun()
    {
        if (!isStunned)
        {
            isStunned = true;
            StartCoroutine(StunCoroutine());
        }
    }

    private IEnumerator StunCoroutine()
    {
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
    }
}
