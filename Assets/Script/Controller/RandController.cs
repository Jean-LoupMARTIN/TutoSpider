using UnityEngine;


public class RandController : Controller
{
    [SerializeField] float speed = 1;
    Vector2 stickL, stickR;
    float timeOffset;

    public override Vector2 StickL { get => stickL; }
    public override Vector2 StickR { get => stickR; }

    void Awake()
    {
        timeOffset = Random.value * 1000;
    }

    void Update()
    {
        float time = Time.time + timeOffset;

        stickL = new Vector2(0.5f - Mathf.PerlinNoise(000, time * speed),
                             0.5f - Mathf.PerlinNoise(100, time * speed)).normalized;
        stickR = new Vector2(0.5f - Mathf.PerlinNoise(200, time * speed),
                             0.5f - Mathf.PerlinNoise(300, time * speed)).normalized;
    }
}
