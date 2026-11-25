using TMPro;
using UnityEngine;

public class ResourceConverter : MonoBehaviour
{
    [SerializeField]
    private Resource startResource;
    [SerializeField]
    private Resource targetResource;
    [SerializeField]
    private TMP_Text conversionText;

    private Vector2Int _conversionRate;

    private int _amountToConvert;

    private void Start()
    {
        _conversionRate = new(targetResource.ConversionValue, startResource.ConversionValue);
        SetText();
    }
    public void SetAmountToConvertInt(int amountToConvert)
    {
        _amountToConvert = amountToConvert;
    }
    public void SetAmountToConvertString(string amountToConvert)
    {
        if (int.TryParse(amountToConvert, out int result)) { _amountToConvert = result; }
    }
    public void Convert()
    {
        int divisor = Calculator.GCD(_conversionRate.x, _conversionRate.y);
        int cost = _conversionRate.x / divisor;
        int result = _conversionRate.y / divisor;

        //Debug.Log($"tried to convert {startResource.name} to {targetResource.name} \n" +
        //    $"their divisor = {divisor}, cost: {cost}, result: {result} \n" +
        //    $"available for conversion = {_amountToConvert} \n" +
        //    $"{_amountToConvert} >= {cost} == {_amountToConvert>=cost} \n");
        
        if (_amountToConvert >= cost && _amountToConvert <= startResource.value) 
        { 
            int amountOfConversions = _amountToConvert / cost;
            int totalCost = amountOfConversions * cost;
            int totalResult = amountOfConversions * result;
            startResource.value -= totalCost;
            targetResource.value += totalResult;
        }
    }
    public void ConvertAll()
    {
        int divisor = Calculator.GCD(_conversionRate.x, _conversionRate.y);
        int cost = _conversionRate.x / divisor;
        int result = _conversionRate.y / divisor;

        if (startResource.value >= cost)
        {
            int amountOfConversions = startResource.value / cost;
            int totalCost = amountOfConversions * cost;
            int totalResult = amountOfConversions * result;
            startResource.value -= totalCost;
            targetResource.value += totalResult;
        }
    }
    public void SetText()
    {
        conversionText.text = $"{_conversionRate.x}/{_conversionRate.y}";
    }
}
