// Script to set all relevant data for game

public class GameData : Singleton<GameData> {
    private int score = 0;
    private int coins = 0;
    private int waveCount = 0;
    private int upgradeCount = 0;
    private int health = 100;

    private void OnLevelWasLoaded(int level)
    {
        // Set defaults whenever any scene is loaded
        if (level == 0 || level == 1)
        {
            score = 0;
            coins = 0;
            waveCount = 0;
            upgradeCount = 0;
            health = 100;
        }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }

    public int WaveCount
    {
        get { return waveCount; }
        set { waveCount = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int UpgradeCount
    {
        get { return upgradeCount; }
        set { upgradeCount = value; }
    }
}
