using UnityEngine;


[DefaultExecutionOrder(2)]
public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float positionSpeed = 15;
    [SerializeField] float rotationSpeed = 15;

    Vector3 lastPosition;
    Quaternion lastRotation;

    void OnEnable()
    {
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void OnDisable()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    void FixedUpdate()
    {
        transform.position = Vector3   .Lerp(lastPosition, target.position, positionSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Lerp(lastRotation, target.rotation, rotationSpeed * Time.fixedDeltaTime);
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }
}
