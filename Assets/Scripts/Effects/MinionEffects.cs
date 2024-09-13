using System.Collections;
using UnityEngine;

public class MinionEffects : MonoBehaviour
{
    [Header("Blast Effect")]
    [SerializeField] private GameObject blastEffectPrefab;

    public void SpawnBlastEffect()
    {
        GameObject blastEffect = Instantiate(blastEffectPrefab, transform.position, Quaternion.identity);
        Destroy(blastEffect, 1f);
    }
}
