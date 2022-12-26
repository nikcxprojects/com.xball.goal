using UnityEngine;
using UnityEngine.UI;

public class Country : MonoBehaviour
{
    [SerializeField] string _name;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            UIManager.Instance.SetCountry(GetComponent<Image>().sprite, _name);
        });
    }
}
