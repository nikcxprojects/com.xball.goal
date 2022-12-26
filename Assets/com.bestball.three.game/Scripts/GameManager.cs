using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private GameObject GoalRef { get; set; }
    private GameObject PlaceRef { get; set; }
    private GameObject BallRef { get; set; }
    private GameObject EnemyRef { get; set; }

    private void OnEnable()
    {
        Ball.OnTravelled += OnTravelldEvent;
    }

    private void OnDestroy()
    {
        Ball.OnTravelled -= OnTravelldEvent;
    }

    private void OnTravelldEvent()
    {

    }

    public void StartGame()
    {
        Transform parent = GameObject.Find("Environment").transform;

        GoalRef = Instantiate(Resources.Load<GameObject>("goal"), Vector2.zero, Quaternion.identity, parent);
        PlaceRef = Instantiate(Resources.Load<GameObject>("place"), Vector2.down * 4.69f, Quaternion.identity, parent);
        BallRef = Instantiate(Resources.Load<GameObject>("ball"), new Vector2(-4.81f, -2.79f), Quaternion.identity, parent);
        EnemyRef = Instantiate(Resources.Load<GameObject>("enemy"), new Vector2(0, -0.52f), Quaternion.identity, parent);
    }

    public void EndGame()
    {
        if (!GoalRef || !PlaceRef || !BallRef || !EnemyRef)
        {
            return;
        }

        Destroy(GoalRef);
        Destroy(PlaceRef);
        Destroy(BallRef);
        Destroy(EnemyRef);
    }
}
