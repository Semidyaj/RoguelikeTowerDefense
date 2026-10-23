using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public class DesktopInput : IInputService
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";
        private const string HorizontalMouseAxisName = "Mouse X";

        public bool IsEnabled { get; set; } = true;

        public Vector3 Direction
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                return new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));
            }
        }

        public Vector3 RotationX
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                float mouseX = Input.GetAxis(HorizontalMouseAxisName);

                return new Vector3(0, Input.GetAxis(HorizontalMouseAxisName), 0);
            }
        }

        public bool IsMainActionPerformed
        {
            get
            {
                if (IsEnabled == false)
                    return false;

                return Input.GetMouseButtonDown(0);
            }
        }
    }
}
