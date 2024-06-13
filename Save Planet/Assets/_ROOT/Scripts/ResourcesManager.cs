using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _dronesCount;
    [SerializeField] private TextMeshProUGUI _shipsCount;
    [SerializeField] private TextMeshProUGUI _mineralCount;

    private Dictionary<ResourceType, int> _resources;
    
    private void Start()
    {
        _resources = new Dictionary<ResourceType, int>
        {
            { ResourceType.Minerals, 0 },
            { ResourceType.Drones, 1 },
            { ResourceType.Ships, 5 }
        };
    }

    public enum ResourceType
    {
        Minerals,
        Drones,
        Ships
    }
    
    public void AddResource(ResourceType resourceType, int count)
    {
        if (!_resources.TryAdd(resourceType, count))
        {
            CheckEndGame(resourceType);
            _resources[resourceType] += count;
            _mineralCount.text = _resources[ResourceType.Minerals].ToString();
            _shipsCount.text = _resources[ResourceType.Ships].ToString();
            _dronesCount.text = _resources[ResourceType.Drones].ToString();

        }
    }


    public int GetResourceCount(ResourceType resourceType)
    {
        return _resources.GetValueOrDefault(resourceType, 0);
    }
    private void CheckEndGame(ResourceType resourceType)
    {
        if(_resources[resourceType] < 0)
            Debug.Log("END GAME!");
    }
}
