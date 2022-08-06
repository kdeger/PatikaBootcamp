using UnityEngine;

public static class Extensions
{
    public static Camera MainCamera
    {
        get
        {
            if(_mainCamera == null)
            {
                _mainCamera = Camera.main;
            }
            return _mainCamera;
        }
    }

    private static Camera _mainCamera;
    public static float GetTotalVelocity(this Rigidbody rigidbody) => rigidbody.velocity.x + rigidbody.velocity.y + rigidbody.velocity.z;

    public static void AddStaticForceOnForward(this Rigidbody rigidbody, float forceFactor, ForceMode forceMode = ForceMode.Acceleration)
    {
        rigidbody.AddForce(Vector3.forward * forceFactor, forceMode);
    }
    public static void ManipulateTransform(this Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = scale;
    }
}