using System.Collections;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;

public class VillainManager : MonoBehaviour
{
    [SerializeField] private GameObject villain;
    private GameObject player;
    [SerializeField] private CinemachineVirtualCamera villainVirtualCamera;

    [Header("Movement")]
    [SerializeField] private float moveDuration = 5f;
    [SerializeField] private float yPositionToStop = 4f;

    [Header("Effects")]
    [SerializeField] private GameObject lightningEffect;

    [Header("Flashing Lights")]
    [SerializeField] private GameObject lightsParentObject;
    [SerializeField] private Light[] lights;
    [SerializeField] private float flashSpeed = 1f;
    [SerializeField] private float maxIntensity = 2f;
    private bool isOn = false;
    private float timer = 0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        villain.SetActive(false);
        villainVirtualCamera.gameObject.SetActive(false);
        lightsParentObject.SetActive(false);

        if (lights.Length == 0)
        {
            Debug.Log("No Lights assigned in villain manager lights array");
        }
    }

    public void EndSequence()
    {
        player.SetActive(false);
        StartCoroutine(VillainSequence()); // called when time runs out
        FlashLight();
    }

    IEnumerator VillainSequence()
    {
        lightsParentObject.SetActive(true);

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

    private void FlashLight()
    {
        timer += Time.deltaTime;

        if(timer >= flashSpeed)
        {
            isOn = !isOn;

            foreach(Light light in lights)
            {
                if(light != null)
                {
                    light.intensity = isOn ? maxIntensity : 0f;
                }
            }

            timer = 0f;
        }
    }

    
}
