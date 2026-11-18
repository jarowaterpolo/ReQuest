using TMPro;
using UnityEngine;

public class ResourcePresenter : MonoBehaviour
{
    [SerializeField]
    private Resource resource;
    private TMP_Text ResourceText;

    private void Start()
    {
        UpdateText(0);
    }
    void UpdateText(int value)
    {
        if (resource == null) return;
        if (ResourceText == null)
        {
            ResourceText = GetComponent<TMP_Text>();
        }      
        ResourceText.text = $"{value}";
    }

    private void OnEnable()
    {
        resource.onValueChanged += UpdateText;
    }

    private void OnDisable()
    {
        resource.onValueChanged -= UpdateText;
    }
}
