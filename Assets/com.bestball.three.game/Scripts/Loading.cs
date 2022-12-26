using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Loading : MonoBehaviour
{
    [SerializeField] Button getStarted;

    private void Awake()
    {
        getStarted.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }

    private IEnumerator Start()
    {
        getStarted.gameObject.SetActive(false);

        float loadingTime = 2.5f;
        yield return new WaitForSeconds(loadingTime);

        getStarted.gameObject.SetActive(true);
    }
}
