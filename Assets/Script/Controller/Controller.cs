using UnityEngine;


public abstract class Controller : MonoBehaviour
{
    protected Vector2 stickL;
    protected Vector2 stickR;

    public Vector2 StickL { get => stickL; }
    public Vector2 StickR { get => stickR; }

    public Vector3 StickL3 => new Vector3(StickL.x, 0, StickL.y);
    public Vector3 StickR3 => new Vector3(StickR.x, 0, StickR.y);

    protected bool button1 = false;
    protected bool button1Down = false;
    protected bool button1Up = false;

    protected bool button2 = false;
    protected bool button2Down = false;
    protected bool button2Up = false;

    public bool Button1     { get => button1; }
    public bool Button1Down { get => button1Down; }
    public bool Button1Up   { get => button1Up; }

    public bool Button2     { get => button2; }
    public bool Button2Down { get => button2Down; }
    public bool Button2Up   { get => button2Up; }

    public void SetButton1(bool b) => SetButton(b, ref button1, ref button1Down, ref button1Up);
    public void SetButton2(bool b) => SetButton(b, ref button2, ref button2Down, ref button2Up);
    public void SetButton(bool b, ref bool button, ref bool buttonDown, ref bool buttonUp)
    {
        buttonDown = !button1 && b;
        buttonUp = button1 && !b;
        button = b;
    }
}
