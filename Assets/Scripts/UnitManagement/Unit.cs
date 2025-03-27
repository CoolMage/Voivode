using UnityEngine;

public enum Faction
{
    Friendly,
    Enemy
}

public class Unit : MonoBehaviour
{
    [Header("Basic Unit Stats")]
    [Header("Sprites by Faction")]
    public Sprite friendlySprite;
    public Sprite enemySprite;
    public string unitName = "New Unit";
    public int health = 100;
    public int morale = 50;

    public Faction unitFaction = Faction.Friendly;

    // Если нужен тип (рат, стрельцы и т.п.)
    public string unitType = "Infantry";

    // Пример позиции. Для 2D можно использовать Vector2, если предпочитаете.
    public Vector3 currentPosition;

    /// <summary>
    /// Метод для инициализации юнита при создании.
    /// </summary>
    public void InitializeUnit(string name, int health, int morale, string type, Faction faction)
    {
        unitName = name;
        this.health = health;
        this.morale = morale;
        unitType = type;
        unitFaction = faction;

        // Установка нужного спрайта в зависимости от фракции
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            if (unitFaction == Faction.Friendly)
            {
                spriteRenderer.sprite = friendlySprite;
            }
            else if (unitFaction == Faction.Enemy)
            {
                spriteRenderer.sprite = enemySprite;
            }
        }
        else
        {
            Debug.LogWarning("SpriteRenderer не найден на объекте юнита!");
        }

        Debug.Log($"Unit {unitName} initialized. Faction: {unitFaction}, Sprite set accordingly.");
    }


    // Переменная для хранения смещения между позицией юнита и позицией клика мыши.
    private Vector3 offset;
    // Флаг, указывающий, что объект перетаскивается.
    private bool isDragging = false;

    // Вызывается, когда по объекту кликают мышью
    private void OnMouseDown()
    {
        // Если юнит не дружеский, выходим из метода.
        if (unitFaction != Faction.Friendly)
            return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
        isDragging = true;
    }


    // Вызывается каждый кадр, пока объект перетаскивается
    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Обновляем позицию объекта с учётом смещения, сохраняя исходное значение Z.
            transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z) + offset;
        }
    }

    // Вызывается, когда отпускают кнопку мыши
    private void OnMouseUp()
    {
        isDragging = false;

        // Здесь можно добавить дополнительную логику, например, "прищелкивание" юнита к сетке.
        // Пример: transform.position = SnapToGrid(transform.position);
    }
}
