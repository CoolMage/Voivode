using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Статическая переменная для хранения ссылки на единственный экземпляр GameManager
    private static GameManager _instance;
    
    // Публичное свойство для доступа к экземпляру GameManager
    public static GameManager Instance
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

    // Метод инициализации игры (загрузка настроек, подготовка ресурсов и т.д.)
    public void InitializeGame()
    {
        Debug.Log("GameManager: InitializeGame()");
        // Здесь может быть код инициализации ваших систем
    }

    private void Start()
    {
        InitializeGame();
        StartGame();
    }

    // Метод для старта игры (запуск игрового процесса)
    public void StartGame()
    {
        Debug.Log("GameManager: StartGame()");

        // 1. Ищем TacticalMapManager
        TacticalMapManager mapManager = FindAnyObjectByType<TacticalMapManager>();
        if (mapManager != null)
        {
            mapManager.SetupBattlefield();
            mapManager.PlaceUnits();
        }

        // 2. Ищем UnitManager
        UnitManager unitManager = FindAnyObjectByType<UnitManager>();
        if (unitManager != null)
        {
            // Пример: создадим 2 юнита на разных позициях
            unitManager.CreateUnit("Spearman", 100, 50, "Infantry", new Vector3(0, 0, 0));
            unitManager.CreateUnit("Archer", 80, 40, "Ranged", new Vector3(2, 0, 0));
        }
        else
        {
            Debug.LogWarning("UnitManager not found in the scene!");
        }
    }


    // Метод, вызываемый каждый кадр (обновление логики игры)
    public void UpdateGame()
    {
        // В реальном проекте сюда можно добавить общую логику,
        // которая должна выполняться каждый кадр.
    }

    // Метод завершения игры (например, при выходе из игры или возвращении в меню)
    public void EndGame()
    {
        Debug.Log("GameManager: EndGame()");
        // Логика завершения: сохранение прогресса, остановка систем и т.д.
    }

    // Встроенный Unity-метод Update, который вызывается каждый кадр
    private void Update()
    {
        // Здесь просто вызываем UpdateGame, чтобы отделить «ядро» логики от Unity-цикла
        UpdateGame();
    }
}
