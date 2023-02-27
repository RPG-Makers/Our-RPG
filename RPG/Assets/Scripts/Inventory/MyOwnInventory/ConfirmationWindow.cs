using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationWindow : MonoBehaviour
{
    //[Header("Inventory")]
    //[SerializeField] private GameObject _inventoryGO;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _howMany;

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _currentValue;
    [SerializeField] private TextMeshProUGUI _maxValue;

    [SerializeField] private Button _drop;

    [SerializeField] private Toggle _toggle;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = this.transform.parent.GetComponentInChildren<InventoryUI>().Inventory;
    }

    private void OnEnable()
    {
        //
    }

    private void OnDisable()
    {
        // Возможно, OnDisable() вызван кнопкой закрытия окна. В таком случае нужно вернуть ячейку на прежнее место.
    }

    public void InitializeValues(int indexOfCell)
    {
        CellInventory cell = _inventory.GetCell(indexOfCell);

        _howMany.text = $"How many {cell.ItemType} do you want to drop?";

        _maxValue.text = cell.CurrentAmount.ToString();
        _slider.maxValue = Convert.ToInt32(_maxValue.text);
    }

    public void Drop()
    {
        if (_toggle.isOn)
        {
            // Дополнительное окно подтверждения.
        }
        else
        {
            // Выбрасываем.
        }
    }
}
