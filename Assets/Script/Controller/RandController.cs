using UnityEngine;


public class RandController : Controller
{
    [SerializeField] float speed = 1;
    [SerializeField, Range(0, 1)] float buttonProba = 0.5f;
    float timeOffset;


    void Awake()
    {
        timeOffset = Random.value * 1000;
    }

    protected override (Vector2, Vector2) UpdateSticks()
    {
        float time = Time.time + timeOffset;

        Vector2 stickL = new Vector2(0.5f - Mathf.PerlinNoise(000, time * speed),
                                     0.5f - Mathf.PerlinNoise(100, time * speed)).normalized;
        Vector2 stickR = new Vector2(0.5f - Mathf.PerlinNoise(200, time * speed),
                                     0.5f - Mathf.PerlinNoise(300, time * speed)).normalized;
        return (stickL, stickR);
    }

    protected override bool UpdateButton1() => Mathf.PerlinNoise(400, Time.time + timeOffset * speed) > buttonProba;
}
