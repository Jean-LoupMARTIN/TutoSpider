using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(1)]
public class PlayerPivot : MonoBehaviour
{
    [SerializeField] Transform pivot;
    [SerializeField] Scan scan;
    [SerializeField, Range(0, 1)] float positionWeight = 0;
    [SerializeField, Range(0, 1)] float rotationWeight = 1;
    [SerializeField] float echos = 1;
    [SerializeField] bool gizmoDrawEchos = true;

    List<List<(Vector3 pos, Quaternion rot, float weight)>> pointsEchos = new List<List<(Vector3, Quaternion, float)>>();

    void OnDrawGizmosSelected()
    {
        if (gizmoDrawEchos)
        {
            Gizmos.color = Color.yellow;
            foreach (List<(Vector3, Quaternion, float)> points in pointsEchos)
                foreach ((Vector3 pos, Quaternion rot, float weight) point in points)
                    Gizmos.DrawSphere(point.pos, 0.1f);
        }
    }

    void FixedUpdate()
    {
        UpdatePivot();
    }

    void UpdatePivot()
    {
        pointsEchos.Add(scan.Points());

        while (pointsEchos.Count > echos)
            pointsEchos.RemoveAt(0);

        Quaternion rotAvg;
        List<Quaternion> rots = new List<Quaternion>();
        List<float> weights = new List<float>();

        Vector3 posAvg = Vector3.zero;
        int nbPoint = 0;

        foreach (List<(Vector3, Quaternion, float)> points in pointsEchos) {
            foreach ((Vector3 pos, Quaternion rot, float weight) point in points)
            {
                rots.Add(point.rot);
                weights.Add(point.weight);
                posAvg += point.pos;
                nbPoint++;
            }
        }

        posAvg /= nbPoint;
        rotAvg = MathExtension.QuatAvgApprox(rots.ToArray(), weights.ToArray());

        pivot.position = Vector3   .Lerp(transform.position, posAvg, positionWeight);
        pivot.rotation = Quaternion.Lerp(transform.rotation, rotAvg, rotationWeight);
    }
}
