using UnityEngine;

namespace RoguelikeTD.Core.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _clip;
        [SerializeField, Range(0, 1)] private float _volume = 1f;
        [SerializeField, Range(0, 0.5f)] private float _pitchVariation = 0.05f;
        [SerializeField, Range(0, 0.5f)] private float _volumeVariation;
        [SerializeField, Min(0)] private float _minInterval;

        private float _nextPlayTime;

        public float Duration => _clip.length / _audioSource.pitch;

        private void OnValidate()
        {
            _audioSource ??= GetComponent<AudioSource>();
        }

        public void Play()
        {
            if (Time.unscaledTime < _nextPlayTime)
                return;

            _nextPlayTime = Time.unscaledTime + _minInterval;

            _audioSource.pitch = 1f + Random.Range(-_pitchVariation, _pitchVariation);
            _audioSource.PlayOneShot(_clip, _volume * (1f - Random.Range(0f, _volumeVariation)));
        }
    }
}
