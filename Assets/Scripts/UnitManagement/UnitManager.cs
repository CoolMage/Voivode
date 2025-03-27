using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    // Список всех активных юнитов в игре
    private List<Unit> allUnits = new List<Unit>();

    [Header("Unit Prefab")]
    public GameObject unitPrefab;

    private void Awake()
    {
        // Аналогично TacticalMapManager, можно (по желанию) сделать Singleton
        // или же оставить обычным классом, если это не критично.
    }

    /// <summary>
    /// Создаёт новый юнит и добавляет его в список.
    /// </summary>
    public Unit CreateUnit(string name, int health, int morale, string type, Vector3 spawnPosition, Faction faction)
    {
        if (unitPrefab == null)
        {
            Debug.LogError("Unit prefab is not assigned in UnitManager!");
            return null;
        }

        // Создаём экземпляр префаба
        GameObject newUnitObj = Instantiate(unitPrefab, spawnPosition, Quaternion.identity);
        Unit newUnit = newUnitObj.GetComponent<Unit>();

        // Инициализируем юнит с учетом фракции
        newUnit.InitializeUnit(name, health, morale, type, faction);
        newUnit.currentPosition = spawnPosition;

        // Добавляем в общий список
        allUnits.Add(newUnit);

        return newUnit;
    }


    /// <summary>
    /// Обновляет состояние всех юнитов, если нужно.
    /// </summary>
    public void UpdateUnits()
    {
        // Пример: проверка здоровья, логика перемещения, и т.д.
        foreach (var unit in allUnits)
        {
            // Ваш код обновления
        }
    }

    /// <summary>
    /// Возвращает список всех юнитов (при необходимости).
    /// </summary>
    public List<Unit> GetAllUnits()
    {
        return allUnits;
    }
}
