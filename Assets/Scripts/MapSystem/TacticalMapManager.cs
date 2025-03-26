using UnityEngine;
using UnityEngine.Tilemaps; // если используете Tilemap

public class TacticalMapManager : MonoBehaviour
{
    [Header("Tilemap References")]
    // Ссылка на ваш Tilemap, если вы используете 2D Tilemap
    public Tilemap terrainTilemap;

    private static TacticalMapManager _instance;
    public static TacticalMapManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        // Проверяем, не существует ли уже экземпляр GameManager
        if (_instance != null && _instance != this)
        {
            // Если экземпляр уже есть, уничтожаем новый
            Destroy(gameObject);
        }
        else
        {
            // Если экземпляра нет, назначаем текущий и делаем его неразрушаемым при загрузке новой сцены
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// Настраивает (или загружает) тактическую карту.
    /// </summary>
    public void SetupBattlefield()
    {
        Debug.Log("TacticalMapManager: SetupBattlefield()");

        // Если вы хотите генерировать карту программно, можно написать логику здесь.
        // Или если карта уже размещена в сцене, достаточно просто иметь ссылку на Tilemap.
    }

    /// <summary>
    /// Размещает юниты на тактической карте в нужных координатах.
    /// </summary>
    public void PlaceUnits()
    {
        Debug.Log("TacticalMapManager: PlaceUnits()");
        // Логика расстановки юнитов, например, на определённые клетки Tilemap
        // или координаты в 3D-пространстве.
    }
}
