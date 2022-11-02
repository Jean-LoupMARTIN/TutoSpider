using UnityEngine;


public class KeyboardController : Controller
{
    [SerializeField] KeyCode stickL_left = KeyCode.Q;
    [SerializeField] KeyCode stickL_right = KeyCode.D;
    [SerializeField] KeyCode stickL_down = KeyCode.S;
    [SerializeField] KeyCode stickL_up = KeyCode.Z;

    [SerializeField] KeyCode stickR_left = KeyCode.LeftArrow;
    [SerializeField] KeyCode stickR_right = KeyCode.RightArrow;
    [SerializeField] KeyCode stickR_down = KeyCode.DownArrow;
    [SerializeField] KeyCode stickR_up = KeyCode.UpArrow;

    [SerializeField] KeyCode button1 = KeyCode.Space;



    Vector2 UpdateStick(KeyCode left, KeyCode right, KeyCode down, KeyCode up)
    {
        Vector2 stick = Vector2.zero;

        if (Input.GetKey(left)) stick.x -= 1;
        if (Input.GetKey(right)) stick.x += 1;
        if (Input.GetKey(down)) stick.y -= 1;
        if (Input.GetKey(up)) stick.y += 1;

        if (stick != Vector2.zero)
            stick.Normalize();

        return stick;
    }

    Vector2 UpdateStickL() => UpdateStick(stickL_left, stickL_right, stickL_down, stickL_up);
    Vector2 UpdateStickR() => UpdateStick(stickR_left, stickR_right, stickR_down, stickR_up);

    protected override (Vector2, Vector2) UpdateSticks() => (UpdateStickL(), UpdateStickR());
    protected override bool UpdateButton1() => Input.GetKey(button1);
}
