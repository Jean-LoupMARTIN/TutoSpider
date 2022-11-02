using UnityEngine;


public abstract class Controller : MonoBehaviour
{
    Vector2 stickL;
    Vector2 stickR;

    public Vector2 StickL { get => stickL; }
    public Vector2 StickR { get => stickR; }

    public Vector3 StickL3 => new Vector3(StickL.x, 0, StickL.y);
    public Vector3 StickR3 => new Vector3(StickR.x, 0, StickR.y);

    bool button1 = false;
    bool button1Down = false;
    bool button1Up = false;

    public bool Button1 { get => button1; }
    public bool Button1Down { get => button1Down; }
    public bool Button1Up { get => button1Up; }

    void SetButton1(bool b)
    {
        if (b == button1)
            return;

        button1Down = !button1 && b;
        button1Up = button1 && !b;
        button1 = b;
    }

    void Update()
    {
        (stickL, stickR) = UpdateSticks();
        SetButton1(UpdateButton1());
    }

    protected abstract (Vector2, Vector2) UpdateSticks();
    protected abstract bool UpdateButton1();
}
