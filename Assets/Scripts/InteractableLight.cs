using UnityEngine;

public class SimpleInteractableLight : MonoBehaviour
{
    [SerializeField] private Light targetLight;
    [SerializeField] private float boostedIntensity = 20f;
    [SerializeField] private float fadeSpeed = 2f;
    [SerializeField] private float duration = 2f;

    private float originalIntensity;
    private float targetIntensity; 
    private float timer = 0f;
    private bool isPlayerInside = false;

    private void Start()
    {
        originalIntensity = targetLight.intensity;
        targetIntensity = originalIntensity; 
    }

    private void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E) && targetIntensity != boostedIntensity)
        {
            targetIntensity = boostedIntensity; 
            timer = duration; 
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime; 
            if (timer <= 0)
            {
                targetIntensity = originalIntensity;
            }
        }

        targetLight.intensity = Mathf.MoveTowards(targetLight.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerInside = false;
    }
}
