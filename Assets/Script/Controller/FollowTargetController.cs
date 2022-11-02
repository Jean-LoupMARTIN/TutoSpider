using UnityEngine;


public class FollowTargetController : Controller
{
    [SerializeField] Transform target;
    [SerializeField] float distStop = 1;


    public Transform Target { get => target; set => target = value; }


    protected override bool UpdateButton1() => false;

    protected override (Vector2, Vector2) UpdateSticks()
    {
        if ((transform.position - target.position).magnitude < distStop)
            return (Vector2.zero, Vector2.zero);

        Vector3 targetProj = transform.InverseTransformPoint(target.position);
        targetProj.y = 0;
        targetProj.Normalize();

        float angle = Vector3.SignedAngle(Vector3.forward, targetProj, Vector3.up);

        Vector2 stickL = new Vector2(targetProj.x, targetProj.z);
        Vector2 stickR = new Vector2(angle > 0 ? 1 : -1, 0);

        return (stickL, stickR);
    }
}
