using UnityEngine;

[CreateAssetMenu(fileName = nameof(Config), menuName = "SavePlanet/" + nameof(Config))]
public class Config : ScriptableObject
{
        public float MineralsTime;
        public int BaseMineralsAdd;
        
        public float SupportTime;
        public int BaseSupportPrice;
        
        public float AttackTime;
        public int BaseAttackersCount;
}
