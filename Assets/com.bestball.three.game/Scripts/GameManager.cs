using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get => FindObjectOfType<GameManager>(); }

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

        Instantiate(Resources.Load<GameObject>("goal"), Vector2.zero, Quaternion.identity, parent);
        Instantiate(Resources.Load<GameObject>("place"), Vector2.down * 3.47f, Quaternion.identity, parent);
        Instantiate(Resources.Load<GameObject>("ball penalty"), Vector2.zero, Quaternion.identity, parent);
    }
}
