using UnityEngine;
using Cinemachine;

public class CameraShake : StaticInstance<CameraShake>
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    private float shakeTimer;

    private void Start()
    {
        GetCinemachineComponents();
    }
    private void GetCinemachineComponents()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
    }
    private void Update()
    {
        UpdateShakeCamera();
    }
    private void UpdateShakeCamera()
    {
        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.unscaledDeltaTime;
            if (shakeTimer <= 0f) // Timer over
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
    public void ShakeCamera(float intensityOfShake = 5f, float timeToShake = 0.1f)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensityOfShake;
        shakeTimer = timeToShake;
    }
}
