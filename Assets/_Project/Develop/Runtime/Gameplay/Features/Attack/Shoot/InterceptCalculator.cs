using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack.Shoot
{
    public static class InterceptCalculator
    {
        private const float Epsilon = 0.0001f;

        public static Vector3 GetAimDirection(
            Vector3 shooterPosition,
            Vector3 targetPosition,
            Vector3 targetVelocity,
            float projectileSpeed,
            Vector3 fallbackDirection)
        {
            TryGetInterceptPoint(shooterPosition, targetPosition, targetVelocity, projectileSpeed, out Vector3 interceptPoint);

            Vector3 direction = interceptPoint - shooterPosition;
            direction.y = 0;

            return direction.sqrMagnitude > 0 ? direction.normalized : fallbackDirection;
        }

        public static bool TryGetInterceptPoint(
            Vector3 shooterPosition,
            Vector3 targetPosition,
            Vector3 targetVelocity,
            float projectileSpeed,
            out Vector3 interceptPoint)
        {
            Vector3 toTarget = targetPosition - shooterPosition;
            toTarget.y = 0;

            Vector3 velocity = targetVelocity;
            velocity.y = 0;

            float a = Vector3.Dot(velocity, velocity) - projectileSpeed * projectileSpeed;
            float b = 2f * Vector3.Dot(toTarget, velocity);
            float c = Vector3.Dot(toTarget, toTarget);

            if (TryGetSmallestPositiveRoot(a, b, c, out float time) == false)
            {
                interceptPoint = targetPosition;
                return false;
            }

            interceptPoint = targetPosition + velocity * time;
            return true;
        }

        private static bool TryGetSmallestPositiveRoot(float a, float b, float c, out float root)
        {
            root = 0;

            if (Mathf.Abs(a) < Epsilon)
            {
                if (Mathf.Abs(b) < Epsilon)
                    return false;

                root = -c / b;
                return root > 0;
            }

            float discriminant = b * b - 4f * a * c;

            if (discriminant < 0)
                return false;

            float sqrtDiscriminant = Mathf.Sqrt(discriminant);
            float first = (-b - sqrtDiscriminant) / (2f * a);
            float second = (-b + sqrtDiscriminant) / (2f * a);

            root = Mathf.Min(first, second);

            if (root <= 0)
                root = Mathf.Max(first, second);

            return root > 0;
        }
    }
}
