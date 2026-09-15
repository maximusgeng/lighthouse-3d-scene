using UnityEngine;

public class FogController : MonoBehaviour
{
    private ParticleSystem fogParticleSystem;

    [SerializeField] private float minLifetime = 20f;
    [SerializeField] private float maxLifetime = 40f;
    [SerializeField] private float changeSpeed = 0.15f;

    private ParticleSystem.MainModule fogMainModule;

    private void Start()
    {
        if (fogParticleSystem == null)
        {
            fogParticleSystem = GetComponent<ParticleSystem>();
        }

        fogMainModule = fogParticleSystem.main;
    }

    private void Update()
    {
        if (fogParticleSystem == null) return;

        float rawSin = Mathf.Sin(Time.time * changeSpeed);
        float normalizedSin = (rawSin + 1f) / 2f;
        float currentLifetime = Mathf.Lerp(minLifetime, maxLifetime, normalizedSin);

        fogMainModule.startLifetime = currentLifetime;
    }
}
