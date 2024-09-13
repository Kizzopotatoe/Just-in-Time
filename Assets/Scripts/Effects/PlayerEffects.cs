using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEffects : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private GameObject pickupEffectPrefab;
    [SerializeField] private GameObject rewindFinishEffectPrefab;
    [SerializeField] private GameObject rippleEffectPrefab;

    private SkinnedMeshRenderer meshRenderer;
    [SerializeField] private Material currentMaterial;
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float pickupMaterialTransitionDuration = 1f;
    [SerializeField] private float slowMoMaterialTransitionDuration = 5f;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        currentMaterial = meshRenderer.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Minion"))
        {
            StartCoroutine(FlashMaterialChange(pickupMaterialTransitionDuration));
            SpawnPickUpEffect();
        }
    }

    private void SpawnPickUpEffect()
    {
        GameObject pickupEffect = Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
        Destroy(pickupEffect, 1f);
    }

    public void RewindFinishEffect()
    {
        GameObject rewindFinishEffect = Instantiate(rewindFinishEffectPrefab, transform.position, Quaternion.identity);
        DontDestroyOnLoad(rewindFinishEffect);
        Destroy(rewindFinishEffect, 1f);
    }

    private IEnumerator  FlashMaterialChange(float duration)
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

    public void SlowMoEffect()
    {
        meshRenderer.material = outlineMaterial;
    }

    public void ReverseSlowMo()
    {
        meshRenderer.material = currentMaterial;
    }

}
