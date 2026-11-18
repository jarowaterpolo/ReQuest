using UnityEngine;

public class TestResource : MonoBehaviour
{
    [SerializeField]
    private Resource resource;
    public void IncreaseResource(int value)
    {
        resource.value += value;
        Debug.Log($"{resource.value}");
    }
}
