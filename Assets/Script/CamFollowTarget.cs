using UnityEngine;


[DefaultExecutionOrder(3)]
public class CamFollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float positionSpeed = 10;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] LayerMask layer;

    Vector3 posProj;
    Quaternion rotProj;


    void Awake()
    {
        posProj = target.InverseTransformPoint(transform.position);
        rotProj = Quaternion.Inverse(target.rotation) * transform.rotation;
    }

    void FixedUpdate()
    {
        Quaternion rot = target.rotation * rotProj;

        Vector3 pos = target.TransformPoint(posProj);
        Vector3 dir = pos - target.position;

        if (Physics.Raycast(target.position, dir, out RaycastHit hit, dir.magnitude, layer))
            pos = hit.point;

        transform.position = Vector3   .Lerp(transform.position, pos, Time.fixedDeltaTime * positionSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.fixedDeltaTime * rotationSpeed);
    }
}
