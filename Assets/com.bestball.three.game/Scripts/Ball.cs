using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Vector2 InitScale { get; set; } = Vector3.one;
    private Vector2 TargetScale { get; set; } = Vector3.one * 0.5f;

    private Transform Center { get; set; }
    private Transform Target { get; set; }

    //private const float totalDistance = 4.0f;
    public float totalDistance = 4.0f;
    private const float force = 80;

    private static Rigidbody2D Rigidbody { get; set; }
    private static Vector2 Velocity { get; set; }

    private bool EndTravel { get; set; }
    public static Action OnTravelled { get; set; }
    public static Action OnPressed { get; set; }

    private void Start()
    {
        Center = GameObject.Find("center").transform;
        Target = GameObject.Find("target").transform;

        Rigidbody = GetComponent<Rigidbody2D>();

        ResetMe();
    }

    private void OnMouseDown()
    {
        if(Rigidbody.velocity.sqrMagnitude > 0)
        {
            return;
        }

        Rigidbody.WakeUp();
        OnPressed?.Invoke();

        Target.position = new Vector2(Random.Range(-2.21f, 2.21f), Random.Range(-0.5f, 1.72f));
        Vector2 direction = Target.position - transform.position;

        Rigidbody.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        Invoke(nameof(ResetMe), 2.5f);
    }

    private void Update()
    {
        float distanceToGoal = Mathf.Abs(Center.position.y - transform.position.y);
        if(distanceToGoal <= 1 && !EndTravel)
        {
            EndTravel = true;
            OnTravelled?.Invoke();
        }

        transform.localScale = Vector2.Lerp(TargetScale, InitScale, distanceToGoal / totalDistance);
    }

    private void ResetMe()
    {
        EndTravel = false;

        Rigidbody.velocity = Vector2.zero;
        Rigidbody.angularVelocity = 0;

        transform.position = new Vector2(-4.81f, -2.79f);
        Rigidbody.Sleep();
    }
}
