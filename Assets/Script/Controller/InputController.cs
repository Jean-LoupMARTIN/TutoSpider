using UnityEngine;


public class InputController : Controller
{
    Vector2 stickL, stickR;

    public override Vector2 StickL { get => stickL; }
    public override Vector2 StickR { get => stickR; }
    public override bool Button1 { get => Input.GetKey(KeyCode.Space); }

    void Update()
    {
        stickL = Vector2.zero;
        if (Input.GetKey(KeyCode.Q))            stickL.x -= 1;
        if (Input.GetKey(KeyCode.D))            stickL.x += 1;
        if (Input.GetKey(KeyCode.S))            stickL.y -= 1;
        if (Input.GetKey(KeyCode.Z))            stickL.y += 1;
        if (stickL != Vector2.zero)             stickL.Normalize();

        stickR = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))    stickR.x -= 1;
        if (Input.GetKey(KeyCode.RightArrow))   stickR.x += 1;
        if (Input.GetKey(KeyCode.DownArrow))    stickR.y -= 1;
        if (Input.GetKey(KeyCode.UpArrow))      stickR.y += 1;
        if (stickR != Vector2.zero)             stickR.Normalize();
    }

}
