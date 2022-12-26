using UnityEngine;

public class Mark : MonoBehaviour
{
    private void Awake()
    {
        Target.OnPressed += (target) =>
        {
            transform.position = target.transform.position;
        };
    }
}
