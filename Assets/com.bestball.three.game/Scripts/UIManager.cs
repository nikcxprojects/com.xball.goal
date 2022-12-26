using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject loading;
    [SerializeField] GameObject menu;

    [Space(10)]
    [SerializeField] GameObject progress;

    private void Awake()
    {
        Loading.OnLoadingStarted += () =>
        {
            menu.SetActive(false);
            progress.SetActive(false);
        };

        Loading.OnLoadingFinished += () =>
        {
            menu.SetActive(true);
            progress.SetActive(true);
        };
    }

    private void Start()
    {
        loading.SetActive(true);
    }
}
