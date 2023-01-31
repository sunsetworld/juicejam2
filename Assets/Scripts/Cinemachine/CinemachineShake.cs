using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    
    private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private float _timer;

    [SerializeField] private Transform camTransform;

    private void Awake()
    {
        Instance = this;
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                camTransform.rotation = new Quaternion(0, 0, 0, 1);
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }

    }

    public void ShakeCam(float intensity, float timer)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        _timer = timer;


    }
}
