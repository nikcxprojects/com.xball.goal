using UnityEngine.UI;
using UnityEngine;

public class BPGame : MonoBehaviour
{
    private void OnEnable()
    {
        BallPenalty.OnTravelled += OnTravelldEvent;
    }

    private void OnDestroy()
    {
        BallPenalty.OnTravelled -= OnTravelldEvent;
    }

    private void OnTravelldEvent()
    {
        
    }

    private void Start()
    {
        Transform parent = GameObject.Find("Environment").transform;

        Instantiate(Resources.Load<GameObject>("goal"), Vector2.zero, Quaternion.identity, parent);
        Instantiate(Resources.Load<GameObject>("place"), Vector2.down * 3.47f, Quaternion.identity, parent);
        Instantiate(Resources.Load<GameObject>("ball penalty"), Vector2.zero, Quaternion.identity, parent);
    }
}
