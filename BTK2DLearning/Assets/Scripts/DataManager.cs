using TigerForge;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private int throwedProjectileCount;
    public int totalThrowedProjectileCount;
    private int enemyKilledCount;
    public int totalEnemyKilledCount;

    EasyFileSave BTK2DPlatformerSave;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitSaveProcess();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ThrowedProjectile
    {
        get
        {
            return throwedProjectileCount;
        }
        set
        {
            throwedProjectileCount = value;
            GameObject.Find("TextThrowedProjectile").GetComponent<TextMeshProUGUI>().text = "Fýrlatýlan Testere: " + throwedProjectileCount.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilledCount;
        }
        set
        {
            enemyKilledCount = value;
            GameObject.Find("TextEnemyKilled").GetComponent<TextMeshProUGUI>().text = "Öldürülen Düþman: " + enemyKilledCount.ToString();
            GameManager.instance.WinProcess();
        }
    }

    public void SaveResetGameData()
    {
        SaveData();
        throwedProjectileCount = 0;
        enemyKilledCount = 0;
    }

    public void InitSaveProcess()
    {
        BTK2DPlatformerSave = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        totalThrowedProjectileCount += throwedProjectileCount;
        totalEnemyKilledCount += enemyKilledCount;

        BTK2DPlatformerSave.Add("totalThrowedProjectileCount", totalThrowedProjectileCount);
        BTK2DPlatformerSave.Add("totalEnemyKilledCount", totalEnemyKilledCount);

        BTK2DPlatformerSave.Save();
    }

    public void LoadData()
    {
        if (BTK2DPlatformerSave.Load())
        {
            totalThrowedProjectileCount = BTK2DPlatformerSave.GetInt("totalThrowedProjectileCount");
            totalEnemyKilledCount = BTK2DPlatformerSave.GetInt("totalEnemyKilledCount");

            BTK2DPlatformerSave.Dispose();
        }
    }
}
