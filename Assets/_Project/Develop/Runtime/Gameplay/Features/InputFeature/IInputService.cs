using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.InputFeature
{
    public interface IInputService
    {
        bool IsEnabled { get; set; }

        Vector3 Direction { get; }
        Vector3 RotationX { get; }
        bool IsMainActionPerformed { get; }
    }
}
