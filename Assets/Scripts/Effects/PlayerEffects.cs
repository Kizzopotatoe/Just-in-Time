using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private GameObject pickupEffectPrefab;

    private SkinnedMeshRenderer meshRenderer;
    [SerializeField] private Material currentMaterial;
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float transitionDuration = 1f;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        currentMaterial = meshRenderer.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Minion"))
        {
            StartCoroutine(SmoothMaterialChange(transitionDuration));
            SpawnPickUpEffect();
        }
    }

    private void SpawnPickUpEffect()
    {
        GameObject pickupEffect = Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
        Destroy(pickupEffect, 1f);
    }

    private IEnumerator  SmoothMaterialChange(float duration)
    {
        // Step 1: Switch to the outline material instantly
        meshRenderer.material = outlineMaterial;

        // Step 2: Wait for a brief flash duration (you can adjust this duration)
        float flashDuration = 0.2f;  // How long to keep the outline material visible
        yield return new WaitForSeconds(flashDuration);

        // Step 3: Smoothly transition back to the original material
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            // Smoothly transition back to the original material
            meshRenderer.material.Lerp(outlineMaterial, currentMaterial, timeElapsed / duration);

            yield return null;
        }

        // Ensure the final material is set to the original one at the end of the transition
        meshRenderer.material = currentMaterial;
    }
}
