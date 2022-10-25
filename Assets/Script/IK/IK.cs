using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class IK : MonoBehaviour
{
    [SerializeField] Transform[] knees;
    [SerializeField] Transform feet, target, dir;
    [SerializeField] float angleMin = 0, angleMax = 180, angleStep = 5;
    List<(float angle, float dist)> distAngle = new List<(float, float)>();


    void OnDrawGizmos()
    {
        if (feet && target && dir)
            MatchTarget();
    }

    void OnValidate()
    {
        if (feet && target && dir)
            CacheDistAngle();
    }

    void Awake()
    {
        CacheDistAngle();
    }

    void LateUpdate()
    {
        MatchTarget();
    }


    void CacheDistAngle()
    {
        distAngle.Clear();

        if (angleStep <= 0)
            return;

        for (float angle = angleMin; angle < angleMax; angle += angleStep)
            distAngle.Add((angle, FeetDist(angle)));

        SwortDistAngle();
    }

    void SwortDistAngle()
    {
        for (int i = 0; i < distAngle.Count - 1; i++)
        {
            for (int j = i + 1; j < distAngle.Count; j++)
            {
                (float angle, float dist) left = distAngle[i];
                (float angle, float dist) right = distAngle[j];

                if (right.dist < left.dist)
                {
                    distAngle[i] = right;
                    distAngle[j] = left;
                }
            }
        }
    }

    float LinearSearchAngle(float dist)
    {
        if (distAngle.Count == 0)
            return 0;

        if (dist <= distAngle[0].dist)
            return distAngle[0].angle;

        for (int i = 1; i < distAngle.Count; i++)
        {
            if (distAngle[i].dist > dist)
            {
                (float angle, float dist) right = distAngle[i];
                (float angle, float dist) left  = distAngle[i-1];
                float progress = Mathf.InverseLerp(left.dist, right.dist, dist);
                return Mathf.Lerp(left.angle, right.angle, progress);
            }
        }

        return distAngle.Last().angle;
    }


    void MatchTarget()
    {
        // find knees angle
        float targetDist = (transform.position - target.position).magnitude;
        SetAngle(LinearSearchAngle(targetDist));

        // look target
        Vector3 forward = target.position - transform.position;
        Vector3 up = Vector3.Cross(forward, dir.right);
        transform.rotation = Quaternion.LookRotation(forward, up);

        float angle = Vector3.SignedAngle(transform.forward, feet.position - transform.position, transform.right);
        transform.Rotate(-angle, 0, 0);
    }

    float FeetDist(float angle)
    {
        SetAngle(angle);
        return (transform.position - feet.position).magnitude;
    }

    void SetAngle(float angle)
    {
        foreach (Transform knee in knees)
            knee.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}