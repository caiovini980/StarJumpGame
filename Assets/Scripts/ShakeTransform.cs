using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeTransform : MonoBehaviour
{
    public class ShakeEvent
    {
        public Vector3 noise;
        
        private float _duration;
        private float _timeRemaining;

        private ShakeTransformEventData _data;
        public ShakeTransformEventData.Target target
        {
            get
            {
                return _data.target;
            }
        }

        private Vector3 _noiseOffset;

        public ShakeEvent(ShakeTransformEventData data)
        {
            _data = data;

            _duration = data.duration;
            _timeRemaining = _duration;

            float random = 32.0f;

            _noiseOffset.x = Random.Range(0.0f, random);
        }

        public void Update()
        {
            float deltaTime = Time.deltaTime;

            _timeRemaining -= deltaTime;

            float noiseOffsetDelta = deltaTime * _data.frequency;

            _noiseOffset.x += noiseOffsetDelta;
            _noiseOffset.y += noiseOffsetDelta;
            _noiseOffset.z += noiseOffsetDelta;

            noise.x = Mathf.PerlinNoise(_noiseOffset.x, 0.0f);
            noise.y = Mathf.PerlinNoise(_noiseOffset.x, 1.0f);
            noise.z = Mathf.PerlinNoise(_noiseOffset.x, 2.0f);

            noise -= Vector3.one * 0.5f;

            noise *= _data.amplitude;

            float agePercent = 1.0f - (_timeRemaining / _duration);
            noise *= _data.blendOverLifetime.Evaluate(agePercent);
        }

        public bool IsAlive()
        {
            return _timeRemaining > 0.0f;
        }
    }

    private List<ShakeEvent> shakeEvents = new List<ShakeEvent>();

    public void AddShakeEvent(ShakeTransformEventData data)
    {
        shakeEvents.Add(new ShakeEvent(data));
    }

    public void AddShakeEvent(float amplitude, float frequency, float duration, AnimationCurve blendOverLifetime,
        ShakeTransformEventData.Target target)
    {
        ShakeTransformEventData data = ScriptableObject.CreateInstance<ShakeTransformEventData>();
        data.Init(amplitude, frequency, duration, blendOverLifetime, target);
        
        AddShakeEvent(data);
    }

    private void LateUpdate()
    {
        Vector3 positionOffset = Vector3.zero;
        Vector3 rotationOffset = Vector3.zero;

        for (int i = shakeEvents.Count - 1; i != -1; i--)
        {
            ShakeEvent shakeEvent = shakeEvents[i];
            shakeEvent.Update();

            if (shakeEvent.target == ShakeTransformEventData.Target.Position)
            {
                positionOffset += shakeEvent.noise;
            }
            else
            {
                rotationOffset += shakeEvent.noise;
            }

            if (!shakeEvent.IsAlive())
            {
                shakeEvents.RemoveAt(i);
            }
        }

        transform.localPosition = positionOffset;
        transform.localEulerAngles = rotationOffset;
    }
}
