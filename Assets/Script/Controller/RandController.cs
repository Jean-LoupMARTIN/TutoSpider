using UnityEngine;


public class RandController : Controller
{
    [SerializeField] float speed = 1;
    [SerializeField, Range(0, 1)] float buttonProba = 0.5f;
    float timeOffset;

    Vector2 stickL, stickR;

    bool button1Down = false;
    bool button1Up = false;
    bool button1 = false;

    public override Vector2 StickL { get => stickL; }
    public override Vector2 StickR { get => stickR; }

    public override bool Button1Down => button1Down;
    public override bool Button1Up => button1Up;
    public override bool Button1 => button1;



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

        bool nextButton1 = Mathf.PerlinNoise(400, time * speed) > buttonProba;

        if (!button1 && nextButton1)
        {
            button1Down = true;
            button1Up = false;
        }

        else if (button1 && !nextButton1)
        {
            button1Down = false;
            button1Up = true;
        }

        else {
            button1Down = false;
            button1Up = false;
        }

        button1 = nextButton1;
    }
}
