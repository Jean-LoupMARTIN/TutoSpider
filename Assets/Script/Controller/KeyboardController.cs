using UnityEngine;


public class KeyboardController : Controller
{
    [SerializeField] KeyCode stickL_Left    = KeyCode.Q;
    [SerializeField] KeyCode stickL_Right   = KeyCode.D;
    [SerializeField] KeyCode stickL_Down    = KeyCode.S;
    [SerializeField] KeyCode stickL_Up      = KeyCode.Z;

    [SerializeField] KeyCode stickR_Left    = KeyCode.LeftArrow;
    [SerializeField] KeyCode stickR_Right   = KeyCode.RightArrow;
    [SerializeField] KeyCode stickR_Down    = KeyCode.DownArrow;
    [SerializeField] KeyCode stickR_Up      = KeyCode.UpArrow;

    [SerializeField] KeyCode button1 = KeyCode.Space;

    Vector2 stickL, stickR;

    bool b1Down = false;
    bool b1Up = false;
    bool b1 = false;

    public override Vector2 StickL { get => stickL; }
    public override Vector2 StickR { get => stickR; }

    public override bool Button1Down => b1Down;
    public override bool Button1Up => b1Up;
    public override bool Button1 => b1;

    void Update()
    {
        stickL = Vector2.zero;
        stickR = Vector2.zero;

        if (Input.GetKey(stickL_Left))  stickL.x -= 1;
        if (Input.GetKey(stickL_Right)) stickL.x += 1;
        if (Input.GetKey(stickL_Down))  stickL.y -= 1;
        if (Input.GetKey(stickL_Up))    stickL.y += 1;

        if (Input.GetKey(stickR_Left))  stickR.x -= 1;
        if (Input.GetKey(stickR_Right)) stickR.x += 1;
        if (Input.GetKey(stickR_Down))  stickR.y -= 1;
        if (Input.GetKey(stickR_Up))    stickR.y += 1;

        if (stickL != Vector2.zero) stickL.Normalize();
        if (stickR != Vector2.zero) stickR.Normalize();


        bool nextB1 = Input.GetKey(button1);

        if (!b1 && nextB1)
        {
            b1Down = true;
            b1Up = false;
        }

        else if (b1 && !nextB1)
        {
            b1Down = false;
            b1Up = true;
        }

        else
        {
            b1Down = false;
            b1Up = false;
        }

        b1 = nextB1;
    }


}
