using UnityEngine;

// S is for Singleton
public class S : MonoBehaviour
{
    // I is for Instance
    public static S I { get; private set; }

    public InputManager IM { get; private set; }
    public ObjectPool ObjectPool { get; private set; }
    public GameManager GameManager { get; private set; }
    public LevelManager LevelManager { get; private set; }
    public PauseManager PauseManager { get; private set; }
    public DataPersistenceManager DataPersistenceManager { get; private set; }
    public HighScoreManager HighScoreManager { get; private set; }

    private void Awake()
    {
        if (I != null && I != this)
        {
            Debug.LogWarning("Found more than one S (Singleton) in the scene.");
            Destroy(this.gameObject);
            return;
        }

        I = this;

        IM = GetComponentInChildren<InputManager>();
        ObjectPool = GetComponentInChildren<ObjectPool>();
        GameManager = GetComponentInChildren<GameManager>();
        LevelManager = GetComponentInChildren<LevelManager>();
        PauseManager = GetComponentInChildren<PauseManager>();
        DataPersistenceManager = GetComponentInChildren<DataPersistenceManager>();
        HighScoreManager = GetComponentInChildren<HighScoreManager>();

        DontDestroyOnLoad(gameObject);
    }
}