using UnityEngine;
public interface IPoolable
{
    void Activate(Vector2 position);
    void Deactivate();
    System.Action OnDeactivate { get; set; }
    GameObject GameObject { get; }
}
