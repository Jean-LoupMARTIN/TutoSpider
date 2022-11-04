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

    [SerializeField] KeyCode key_A = KeyCode.N;
    [SerializeField] KeyCode key_B = KeyCode.J;
    [SerializeField] KeyCode key_X = KeyCode.H;
    [SerializeField] KeyCode key_Y = KeyCode.U;



    Vector2 Stick(KeyCode left, KeyCode right, KeyCode down, KeyCode up)
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


    void Update()
    {
        stickL = Stick(key_stickL_left, key_stickL_right, key_stickL_down, key_stickL_up);
        stickR = Stick(key_stickR_left, key_stickR_right, key_stickR_down, key_stickR_up);
        A.IsPressed = Input.GetKey(key_A);
        B.IsPressed = Input.GetKey(key_B);
        X.IsPressed = Input.GetKey(key_X);
        Y.IsPressed = Input.GetKey(key_Y);
    }
}
