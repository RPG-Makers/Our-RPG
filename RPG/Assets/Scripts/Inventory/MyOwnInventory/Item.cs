using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public abstract class Item : MonoBehaviour, IUsable
{
    [SerializeField] private ItemData _itemData;
    public ItemData ItemData => _itemData;
    //[SerializeField] public int MaxAmount { get; private set; }

    //[SerializeField] private string _name;
    //[SerializeField] private int _price;
    //[SerializeField] private Sprite _sprite;
    //[SerializeField] private bool _stackable;
    //public string Name => _name;
    //public Sprite Sprite => _sprite;
    //public bool Stackable => _stackable;

    //public Action OnCellInventoryClicked; ???

    public abstract void Use();



    public delegate void ItemHandler(Item item, out bool added);
    public static event ItemHandler OnTake;

    private void OnMouseDown()
    {
        //OldInventory.Instance.Add(this);

        Debug.Log("На меня нажали");
        if (_takeable)
        {
            Debug.Log("Ща будем инвокать");
            // На сцене нет инвентаря, поэтому ошибка
            bool added;
            OnTake.Invoke(this, out added);
            if (added)
            {
                Destroy(gameObject);
            }
            // Здесь нужно организовать общение "Предмет - Инвентарь".
            // Инвентарь узнаёт о том, что игрок попытался поднять какой-то предмет, и пытается добавить его (инвентарь пытается добавить предмет).
            // Далее инвентарь сообщает предмету о том, смог ли он добавить предмет. Если смог - уничтожаем Item, не смог - оставляем лежать дальше.

            // Так в событии мы можем передать самого отправителя))))))))))))))))))))
        }
        Debug.Log("Как я тут");

        //Destroy(gameObject);
    }


    private bool _takeable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _takeable = true;
            Debug.Log("Можем подобрать");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _takeable = false;
            Debug.Log("Не можем подобрать");
        }
    }
}
