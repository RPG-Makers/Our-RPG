using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public abstract class Item : MonoBehaviour, IUsable
{
    [SerializeField] private ItemData _itemData;
    public ItemData ItemData => _itemData;

    private bool _takeable;

    //public Action OnCellInventoryClicked; ???

    public abstract void Use();

    public delegate void ItemHandler(Item item, out bool added);
    public static event ItemHandler OnTake;

    private void OnMouseDown()
    {
        //Debug.Log("На меня нажали");
        if (_takeable)
        {
            //Debug.Log("Ща будем инвокать");
            // Если на сцене нет инвентаря, то возникает ошибка.
            bool added;
            //if (OnTake == null)
            //{
            //    Debug.Log("Никто не пришел на фан встречу");
            //}
            OnTake.Invoke(this, out added);
            if (added)
            {
                //transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Destroy(gameObject);
                return;
            }
            //Debug.LogWarning("Не удалось добавить предмет");

            // Здесь нужно организовать общение "Предмет - Инвентарь". UPD: Организовано.
            // Инвентарь узнаёт о том, что игрок попытался поднять какой-то предмет, и пытается добавить его (инвентарь пытается добавить предмет).
            // Далее инвентарь сообщает предмету о том, смог ли он добавить предмет. Если смог - уничтожаем Item, не смог - оставляем лежать дальше.

            // Так в событии мы можем передать самого отправителя))))))))))))))))))))
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool added; // Only for test!!!!! Delete after.
        if (collision.gameObject.CompareTag("Player"))
        {

            OnTake.Invoke(this, out added); // Only for test!!!!! Delete after.
            if (added) // Only for test!!!!! Delete after.
            {
                //transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Destroy(gameObject); // Only for test!!!!! Delete after.
            } // Only for test!!!!! Delete after.

            //////_takeable = true; Restore
            ////////Debug.Log("Можем подобрать"); Restore
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _takeable = false;
            //Debug.Log("Не можем подобрать");
        }
    }

    public void SetItemData(ItemData data)
    {
        _itemData = data;
    }
}
