using UnityEngine;
using UnityEngine.UI;

public class SettingsBtn : MonoBehaviour
{
    private bool Enable { get; set; }
    [SerializeField] GameObject root;

    private void Start()
    {
        root.SetActive(false);

        GetComponent<Button>().onClick.AddListener(() =>
        {
            Enable = !Enable;
            root.SetActive(Enable);
        });
    }
}
