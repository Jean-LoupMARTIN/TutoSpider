using UnityEngine;


public class KeyboardController : Controller
{
    [SerializeField] KeyCode key_stickL_left  = KeyCode.Q;
    [SerializeField] KeyCode key_stickL_right = KeyCode.D;
    [SerializeField] KeyCode key_stickL_down  = KeyCode.S;
    [SerializeField] KeyCode key_stickL_up    = KeyCode.Z;

    [SerializeField] KeyCode key_stickR_left  = KeyCode.LeftArrow;
    [SerializeField] KeyCode key_stickR_right = KeyCode.RightArrow;
    [SerializeField] KeyCode key_stickR_down  = KeyCode.DownArrow;
    [SerializeField] KeyCode key_stickR_up    = KeyCode.UpArrow;

    [SerializeField] KeyCode key_button1 = KeyCode.Space;



    Vector2 UpdateStick(KeyCode left, KeyCode right, KeyCode down, KeyCode up)
    {
        Vector2 stick = Vector2.zero;

        if (Input.GetKey(left))  stick.x -= 1;
        if (Input.GetKey(right)) stick.x += 1;
        if (Input.GetKey(down))  stick.y -= 1;
        if (Input.GetKey(up))    stick.y += 1;

        if (stick != Vector2.zero)
            stick.Normalize();

        return stick;
    }

    Vector2 UpdateStickL() => UpdateStick(key_stickL_left, key_stickL_right, key_stickL_down, key_stickL_up);
    Vector2 UpdateStickR() => UpdateStick(key_stickR_left, key_stickR_right, key_stickR_down, key_stickR_up);

    protected override (Vector2, Vector2) UpdateSticks() => (UpdateStickL(), UpdateStickR());
    protected override bool UpdateButton1() => Input.GetKey(key_button1);
}
