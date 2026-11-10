using UnityEngine;

namespace RoguelikeTD.Core.Audio
{
    public class OneShotSoundSpawner : MonoBehaviour
    {
        [SerializeField] private OneShotSound _soundPrefab;

        public void Spawn() => Instantiate(_soundPrefab);
    }
}
