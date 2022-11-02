using UnityEngine;


public abstract class Controller : MonoBehaviour
{
    public abstract Vector2 StickL { get; }
    public abstract Vector2 StickR { get; }

    public Vector3 StickL3 => new Vector3(StickL.x, 0, StickL.y);
    public Vector3 StickR3 => new Vector3(StickR.x, 0, StickR.y);

    public abstract bool Button1Down { get; }
    public abstract bool Button1Up { get; }
    public abstract bool Button1 { get; }
}
