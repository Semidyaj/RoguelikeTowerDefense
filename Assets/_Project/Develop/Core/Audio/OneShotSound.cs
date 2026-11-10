using UnityEngine;

namespace RoguelikeTD.Core.Audio
{
    [RequireComponent(typeof(SoundPlayer))]
    public class OneShotSound : MonoBehaviour
    {
        [SerializeField] private SoundPlayer _soundPlayer;

        private void OnValidate()
        {
            _soundPlayer ??= GetComponent<SoundPlayer>();
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _soundPlayer.Play();
            Destroy(gameObject, _soundPlayer.Duration);
        }
    }
}
