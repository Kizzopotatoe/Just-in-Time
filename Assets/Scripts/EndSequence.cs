using System.Collections;
using UnityEngine;
using Cinemachine;

public class EndSequence : MonoBehaviour
{
    [SerializeField] private GameObject villain;
    [SerializeField] private CinemachineVirtualCamera villainVirtualCamera;
    [SerializeField] private float moveDuration = 5f;
    [SerializeField] private float yPositionToStop = 2.5f;

    [SerializeField] private GameObject lightningEffect;

    private void Start()
    {
        villain.SetActive(false);
        villainVirtualCamera.gameObject.SetActive(false);
    }

    public void VillainEndSequence()
    {
        StartCoroutine(EndingSequence());
    }

    IEnumerator EndingSequence()
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
