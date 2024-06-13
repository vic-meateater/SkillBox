using System;
using UnityEngine;
using UnityEngine.UI;

public class MineralsTimer : MonoBehaviour
{
    [SerializeField] private Config _config;
    [SerializeField] private Image _mineralsImage;
    [SerializeField] private Image _supportImage;
    [SerializeField] private Image _timeToAttackImage;

    public event Action MineralsTimerElapsed;
    public event Action SupportTimerElapsed;
    public event Action AttackTimerElapsed;

    private float _currentMineralsTime;
    private float _currentSupportTime;
    private float _currentAttackTime;
    
    private void Start()
    {
        _currentMineralsTime = 0;
        _currentSupportTime = 0;
        _currentAttackTime = 0;
    }
    
    private void Update()
    {
        UpdateMineralsTimer();
        UpdateSupportTimer();
        UpdateAttackTimer();
    }

    private void UpdateMineralsTimer()
    {
        _currentMineralsTime += Time.deltaTime;
        if (_currentMineralsTime >= _config.MineralsTime)
        {
            _currentMineralsTime = 0;
            MineralsTimerElapsed?.Invoke();
        }

        _mineralsImage.fillAmount = _currentMineralsTime / _config.MineralsTime;
    }
    
    private void UpdateSupportTimer()
    {
        _currentSupportTime += Time.deltaTime;
        if (_currentSupportTime >= _config.SupportTime)
        {
            _currentSupportTime = 0;
            SupportTimerElapsed?.Invoke();
        }
        
        _supportImage.fillAmount = _currentSupportTime / _config.SupportTime;
    }
    
    private void UpdateAttackTimer()
    {
        _currentAttackTime += Time.deltaTime;
        if (_currentAttackTime >= _config.AttackTime)
        {
            _currentAttackTime = 0;
            AttackTimerElapsed?.Invoke();
        }
        
        _timeToAttackImage.fillAmount = _currentAttackTime / _config.AttackTime;
    }
}
