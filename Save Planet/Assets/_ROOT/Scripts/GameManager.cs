using System;
using UnityEngine;

public class GameManager : MonoBehaviour, IDisposable
{
    [SerializeField] private Config _config;
    [SerializeField] private MineralsTimer _mineralsTimer;
    [SerializeField] private ResourcesManager _resourcesManager;
    private void Start()
    {
        _mineralsTimer.MineralsTimerElapsed += OnMineralsTimerElapsed;
        _mineralsTimer.SupportTimerElapsed += OnSupportTimerElapsed;
    }


    private void OnMineralsTimerElapsed()
    {
        var mineralsAddCount = _config.BaseMineralsAdd * 
                               _resourcesManager.GetResourceCount(ResourcesManager.ResourceType.Drones);
        _resourcesManager.AddResource(ResourcesManager.ResourceType.Minerals, mineralsAddCount);
    }
    private void OnSupportTimerElapsed()
    {
        var supportAddCount = _config.BaseSupportPrice -
                              _resourcesManager.GetResourceCount(ResourcesManager.ResourceType.Ships);
        _resourcesManager.AddResource(ResourcesManager.ResourceType.Minerals, supportAddCount);
    }

    public void Dispose()
    {
        _mineralsTimer.MineralsTimerElapsed -= OnMineralsTimerElapsed;
        _mineralsTimer.SupportTimerElapsed -= OnSupportTimerElapsed;
    }
}
