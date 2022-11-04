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

    void Update()
    {
        float time = Time.time + timeOffset;

        stickL = new Vector2(0.5f - Mathf.PerlinNoise(000, time * speed),
                             0.5f - Mathf.PerlinNoise(100, time * speed)).normalized;
        stickR = new Vector2(0.5f - Mathf.PerlinNoise(200, time * speed),
                             0.5f - Mathf.PerlinNoise(300, time * speed)).normalized;

        SetButton1(Mathf.PerlinNoise(400, time * speed) > buttonProba);
        SetButton2(Mathf.PerlinNoise(500, time * speed) > buttonProba);
    }
}
