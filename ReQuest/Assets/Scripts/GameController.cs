using NUnit.Framework;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Resource[] allResources;

    void Start()
    {
        foreach (var resource in allResources) 
        {
            resource.ResetValue();
        }
    }
}
