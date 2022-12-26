using UnityEngine.UI;
using UnityEngine;

public class ChooseCountry : MonoBehaviour
{
    [SerializeField] Button[] countries;

    private void Start()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            for (int i = 0; i < countries.Length; i++)
            {
                countries[i].interactable = true;
            }
        });
    }

    public void SetCountry(int id)
    {
        for(int i = 0; i < countries.Length; i++)
        {
            countries[i].interactable = id == i;
        }
    }
}
