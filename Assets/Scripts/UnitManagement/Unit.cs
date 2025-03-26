using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Basic Unit Stats")]
    public string unitName = "New Unit";
    public int health = 100;
    public int morale = 50;

    // Если нужен тип (рат, стрельцы и т.п.)
    public string unitType = "Infantry";

    // Пример позиции. Для 2D можно использовать Vector2, если предпочитаете.
    public Vector2 currentPosition;

    /// <summary>
    /// Метод для инициализации юнита при создании.
    /// </summary>
    public void InitializeUnit(string name, int health, int morale, string type)
    {
        unitName = name;
        this.health = health;
        this.morale = morale;
        unitType = type;

        Debug.Log($"Unit {unitName} initialized. Health: {health}, Morale: {morale}, Type: {type}");
    }


    // Переменная для хранения смещения между позицией юнита и позицией клика мыши.
    private Vector3 offset;
    // Флаг, указывающий, что объект перетаскивается.
    private bool isDragging = false;

    // Вызывается, когда по объекту кликают мышью
    private void OnMouseDown()
    {
        // Преобразуем позицию мыши из экранных координат в мировые.
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Вычисляем смещение: разница между позицией юнита и позицией клика.
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
