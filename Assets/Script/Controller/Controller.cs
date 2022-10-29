using UnityEngine;


public abstract class Controller : MonoBehaviour
{
    public abstract Vector2 StickL { get; }
    public abstract Vector2 StickR { get; }
}
