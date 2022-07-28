using System;
using System.Collections;
using UnityEngine;

namespace Assets
{
    public class ElectricityWall : MonoBehaviour
    {
        [SerializeField] private float m_DelayBeforeStart = 0f;
        [SerializeField] private float m_Duration = 0f;
        [SerializeField] private AudioSource _electrSound;

        private Coroutine _cachedEnableCoroutine;
        private Coroutine _cachedDisableCoroutine;
        private ParticleSystem _cachedParticles;
        private Collider _cachedCollider;
        

        private void Awake()
        {
            _cachedParticles = GetComponent<ParticleSystem>();
            _cachedCollider = GetComponent<Collider>();
        }

        private void Update()
        {
            if (_cachedDisableCoroutine == null && _cachedEnableCoroutine == null)
            {
                _cachedEnableCoroutine ??= StartCoroutine(Timer(
                    m_DelayBeforeStart, () =>
                    {
                        if (_cachedCollider != null)
                            _cachedCollider.enabled = true;

                        if (_cachedParticles != null)
                        {
                            _cachedParticles.Play();
                            _electrSound.Play();
                        }

                        _cachedEnableCoroutine = null;

                        _cachedDisableCoroutine ??= StartCoroutine(Timer(
                            m_Duration, () =>
                            {
                                if (_cachedCollider != null)
                                    _cachedCollider.enabled = false;

                                if (_cachedParticles != null)
                                {
                                    _electrSound.Stop();
                                    _cachedParticles.Stop();
                                }

                                _cachedDisableCoroutine = null;
                            }));
                    }));
            }
        }

        private IEnumerator Timer(float duration, Action action)
        {
            yield return new WaitForSeconds(duration);
            action?.Invoke();
        }
    }
}
