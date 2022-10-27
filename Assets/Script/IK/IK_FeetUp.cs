using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[ExecuteInEditMode]
public class IK_FeetUp : MonoBehaviour
{
    float feetLenght;
    [SerializeField] Transform[] knees;
    [SerializeField] Transform feet, target;
    [SerializeField] float angleMin = 0, angleMax = 180, angleStep = 5;
    List<(float angle, float dist)> distAngle = new List<(float, float)>();


    void OnValidate()
    {
        Cache();
    }

    void Awake()
    {
        Cache();
    }

    void LateUpdate()
    {
        MatchTarget();
    }

    void Cache()
    {
        if (!feet || knees.Length < 1)
            return;

        feetLenght = (knees.Last().position - feet.position).magnitude;
        CacheDistAngle();
    }


    void CacheDistAngle()
    {
        distAngle.Clear();

        if (angleStep <= 0)
            return;

        for (float angle = angleMin; angle < angleMax; angle += angleStep)
            distAngle.Add((angle, LastKneeDist(angle)));

        //SwortDistAngle();
    }

    void SwortDistAngle()
    {
        for (int i = 0; i < distAngle.Count - 1; i++)
        {
            for (int j = i + 1; j < distAngle.Count; j++)
            {
                (float angle, float dist) left = distAngle[i];
                (float angle, float dist) right = distAngle[j];

                if (right.dist > left.dist)
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

        if (dist >= distAngle[0].dist)
            return distAngle[0].angle;

        for (int i = 1; i < distAngle.Count; i++)
        {
            (float angle, float dist) e1 = distAngle[i];

            if (distAngle[i].dist < dist)
            {
                (float angle, float dist) e2 = distAngle[i-1];
                float progress = Mathf.InverseLerp(e2.dist, e1.dist, dist);
                return Mathf.Lerp(e2.angle, e1.angle, progress);
            }
        }

        return distAngle.Last().angle;
    }


    void MatchTarget()
    {
        if (!feet || !target)
            return;

        // find knees angle
        Vector3 kneeTarget = target.position + target.up * feetLenght;
        float dist = (transform.position - kneeTarget).magnitude;
        SetAngle(LinearSearchAngle(dist));

        // look last knee target
        Transform lastKnee = knees.Last();
        Vector3 forward = kneeTarget - transform.position;
        Vector3 right = Vector3.Cross(target.up, forward);
        Vector3 up = Vector3.Cross(forward, right);
        transform.rotation = Quaternion.LookRotation(forward, up);

        float angle = Vector3.SignedAngle(transform.forward, lastKnee.position - transform.position, transform.right);
        transform.Rotate(-angle, 0, 0);

        // feet look target
        forward = target.position - lastKnee.position;
        knees.Last().rotation = Quaternion.LookRotation(forward, Vector3.Cross(forward, lastKnee.right));
    }

    float LastKneeDist(float angle)
    {
        SetAngle(angle);
        return (transform.position - knees.Last().position).magnitude;
    }


    void SetAngle(float angle)
    {
        foreach (Transform knee in knees)
            knee.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}

