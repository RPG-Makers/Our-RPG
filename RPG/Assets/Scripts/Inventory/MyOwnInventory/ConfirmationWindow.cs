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

    private InventoryUI _inventoryUI;
    private Inventory _inventory;

    private CellUIMovler _UIcell;
    private int _indexOfCell;

    private void Awake()
    {
        _inventoryUI = this.transform.parent.GetComponentInChildren<InventoryUI>();
        _inventory = _inventoryUI.Inventory;
    }

    private void OnEnable()
    {
        //
    }

    private void OnDisable()
    {
        // Возможно, OnDisable() вызван кнопкой закрытия окна. В таком случае нужно вернуть ячейку на прежнее место.
    }

    public void InitializeValues(int indexOfCell, CellUIMovler inputCell)
    {
        _UIcell = inputCell;
        _indexOfCell = indexOfCell;

        CellInventory cell = _inventory.GetCell(indexOfCell);

        _howMany.text = $"How many {cell.ItemType} do you want to drop?";

        _maxValue.text = cell.CurrentAmount.ToString();
        _slider.maxValue = Convert.ToInt32(_maxValue.text);
        _currentValue.text = _slider.value.ToString();
    }

    public void Drop()
    {
        if (_toggle.isOn)
        {
            // Дополнительное окно подтверждения.


            // Пока что выбрасываем здесь. Потом перенесем в else.

            if (_inventory.DecreaseAmount(_indexOfCell, Convert.ToInt32(_currentValue.text)))
            {
                Debug.Log("Успешно выбросили");
                _inventoryUI.InstantiateInventoryUI();
                Destroy(_UIcell.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogWarning("Возникла ошибка при выбрасывании предмета!");
            }
        }
        else
        {
            // Выбрасываем.
        }
    }

    public void ChangeCurrentValue()
    {
        _currentValue.text = _slider.value.ToString();
    }

    public void Close()
    {
        _UIcell.ReturnToStart();

        Destroy(this.gameObject);
    }
}
