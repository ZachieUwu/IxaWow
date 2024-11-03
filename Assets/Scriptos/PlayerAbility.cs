using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public GameObject vinePrefab;
    public float delayBetweenVines = 0.1f;
    public int totalVines;
    public float vineDespawnDelay = 3f;
    public float vineSpacing;
    public float spawnDistance = 5f;

    private bool isAbilityActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAbilityActive)
        {
            isAbilityActive = true;
            StartCoroutine(SummonVines());
        }
    }

    private IEnumerator SummonVines()
    {
        Vector3 spawnBasePosition = transform.position + transform.forward * spawnDistance;
        spawnBasePosition.y = 0;

        Quaternion spawnRotation = Quaternion.LookRotation(transform.forward, Vector3.up);

        for (int i = 0; i < totalVines; i++)
        {
            Vector3 spawnPosition = spawnBasePosition + transform.forward * i * vineSpacing;

            GameObject vine = Instantiate(vinePrefab, spawnPosition, spawnRotation);

            vine.transform.SetParent(null);

            vine.GetComponent<VineSummoner>().Initialize(vineDespawnDelay);

            yield return new WaitForSeconds(delayBetweenVines);
        }

        isAbilityActive = false;
    }
}
