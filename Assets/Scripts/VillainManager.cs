using System.Collections;
using UnityEngine;
using Cinemachine;

public class VillainManager : MonoBehaviour
{
    [SerializeField] private GameObject villain;
    [SerializeField] private CinemachineVirtualCamera villainVirtualCamera;
    [SerializeField] private float moveDuration = 5f;
    [SerializeField] private float yPositionToStop = 4f;

    [SerializeField] private GameObject lightningEffect;

    private void Awake()
    {
        villain.SetActive(false);
        villainVirtualCamera.gameObject.SetActive(false);
    }

    public void EndSequence()
    {
        StartCoroutine(VillainSequence()); // called when time runs out
    }

    IEnumerator VillainSequence()
    {
        villain.SetActive(true);
        villainVirtualCamera.gameObject.SetActive(true);

        float elapsedTime = 0f;
        Vector3 startPosition = villain.transform.position;

        Vector3 targetPosition = new Vector3(startPosition.x, yPositionToStop, startPosition.z);

        while(elapsedTime < moveDuration)
        {
            villain.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        villain.transform.position = targetPosition;

        // Lightning strikes - building destroyed
        lightningEffect.SetActive(true);
        yield return new WaitForSeconds(5f); // replace with conditional
        // when destroying is done then display game over screen
        GameManager.instance.levelFailedMenu.SetActive(true);
        Time.timeScale = 0;

    }
}
