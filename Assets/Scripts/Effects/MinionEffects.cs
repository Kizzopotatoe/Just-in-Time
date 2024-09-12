using UnityEngine;

public class MinionEffects : MonoBehaviour
{
    [SerializeField] private GameObject blastEffectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnBlastEffect();
        }
    }

    public void SpawnBlastEffect()
    {
        GameObject blastEffect = Instantiate(blastEffectPrefab, transform.position, Quaternion.identity);
        Destroy(blastEffect, 1f);
    }
}
