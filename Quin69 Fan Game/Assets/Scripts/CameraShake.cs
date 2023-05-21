using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmplitude = 1.2f;
    public float shakeFrequency = 2.0f;

    private CinemachineVirtualCamera virtualCamera;
    private float shakeTimer = 0f;
    private float initialAmplitude;
    private float initialFrequency;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        // Store the initial values of the camera's noise settings
        initialAmplitude = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain;
        initialFrequency = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain;
    }

    public void ShakeCamera(float shakeDuration)
    {
        shakeTimer = shakeDuration;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            // Generate random noise values for camera shake
            float shakeAmplitudeValue = Random.Range(-1f, 1f) * shakeAmplitude;
            float shakeFrequencyValue = Random.Range(-1f, 1f) * shakeFrequency;

            // Set the camera's noise values to create the shake effect
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeAmplitudeValue;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = shakeFrequencyValue;

            // Decrease the timer
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset the camera's noise values to their initial state
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = initialAmplitude;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = initialFrequency;
        }
    }
}
