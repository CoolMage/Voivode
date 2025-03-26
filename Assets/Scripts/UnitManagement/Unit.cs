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
}
