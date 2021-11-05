using System;
using UnityEngine;

public class AmplitudeAnalytics : MonoBehaviour
{
    private const string SAVED_REG_DAY = "RegDay";
    private const string SAVED_REG_DAY_FULL = "RegDayFull";
    private const string SAVED_SESSION_ID = "SessionID";

    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private ResultMaker _resultMaker;

    private Amplitude _amplitude;

    private string _regDay
    {
        get { return PlayerPrefs.GetString(SAVED_REG_DAY, DateTime.Today.ToString("dd/MM/yy")); }
        set { PlayerPrefs.SetString(SAVED_REG_DAY, value); }
    }

    private string _regDayFull
    {
        get { return PlayerPrefs.GetString(SAVED_REG_DAY_FULL, DateTime.Today.ToString()); }
        set { PlayerPrefs.SetString(SAVED_REG_DAY_FULL, value); }
    }

    private int _sessionID
    {
        get { return PlayerPrefs.GetInt(SAVED_SESSION_ID, 0); }
        set { PlayerPrefs.SetInt(SAVED_SESSION_ID, value); }
    }

    private void Awake()
    {
        _amplitude = Amplitude.Instance;
        _amplitude.logging = true;
        _amplitude.init("ce8d14434281316da75c1a7e51bda9cd");
    }

    private void OnEnable()
    {
        _levelChanger.StartedGame += GameStart;
        _levelChanger.StartedLevel += OnLevelStarted;
        _levelChanger.RestartedLevel += OnLevelRestart;
        _resultMaker.WonLevel += OnLevelWon;
        _resultMaker.FailLevel += OnlevelLost;
    }

    private void OnDisable()
    {
        _levelChanger.StartedLevel -= OnLevelStarted;
        _resultMaker.WonLevel -= OnLevelWon;
        _resultMaker.FailLevel -= OnlevelLost;
    }

    private void GameStart()
    {
        _sessionID++;
        if (_sessionID == 1)
        {
            _regDay = DateTime.Today.ToString("dd/MM/yy");
            _regDayFull = DateTime.Today.ToString();
            _amplitude.setOnceUserProperty("reg_day", _regDay);
        }

        SetBasicProperty();
        FireEvent("game_start");
    }

    private void OnLevelRestart()
    {
        FireEvent("level_restart");
    }

    private void OnlevelLost()
    {
        int time = _resultMaker.SpentTime;
        _amplitude.setUserProperty("spent_time", time);

        FireEvent("level_fail");
    }

    private void OnLevelWon()
    {
        int time = _resultMaker.SpentTime;
        _amplitude.setUserProperty("spent_time", time);

        FireEvent("level_win");
    }

    private void OnLevelStarted()
    {
        FireEvent("level_start");
    }

    private void SetBasicProperty()
    {
        _amplitude.setUserProperty("session_id", _sessionID);

        int lastLevel = _levelChanger.LastScene;
        _amplitude.setUserProperty("last_level", lastLevel);

        int daysAfter = DateTime.Today.Subtract(DateTime.Parse(_regDayFull)).Days;
        _amplitude.setUserProperty("days_after", daysAfter);
    }

    private void FireEvent(string eventName)
    {
        SettingUserProperties();
        _amplitude.logEvent(eventName);
    }

    private void SettingUserProperties()
    {
        int level = _levelChanger.CurrentScene;
        _amplitude.setUserProperty("level", level);
    }
}
