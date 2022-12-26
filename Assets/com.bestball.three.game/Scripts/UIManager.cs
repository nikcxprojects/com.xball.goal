using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get => FindObjectOfType<UIManager>(); }

    [SerializeField] GameObject loading;
    [SerializeField] GameObject menu;
    [SerializeField] ChooseCountry chooseCountry;

    [Space(10)]
    [SerializeField] GameObject progress;

    [Space(10)]
    [SerializeField] Button startBtn;
    [SerializeField] Button chooseCountryBtn;

    [Space(10)]
    [SerializeField] Image countryIcon;
    [SerializeField] Text countryName;

    private void Awake()
    {
        Loading.OnLoadingStarted += () =>
        {
            menu.SetActive(false);
            progress.SetActive(false);
            chooseCountry.gameObject.SetActive(false);
        };

        Loading.OnLoadingFinished += () =>
        {
            menu.SetActive(true);
            progress.SetActive(true);
        };

        startBtn.onClick.AddListener(() =>
        {

        });

        chooseCountryBtn.onClick.AddListener(() =>
        {
            menu.SetActive(false);
            chooseCountry.gameObject.SetActive(true);
        });
    }

    private void Start()
    {
        loading.SetActive(true);
    }

    public void SetCountry(Sprite icon, string name, int id)
    {
        countryIcon.sprite = icon;
        countryName.text = name;

        chooseCountry.SetCountry(id);
    }

    public void OpenMenu()
    {
        chooseCountry.gameObject.SetActive(false);
        menu.SetActive(true);
    }
}
