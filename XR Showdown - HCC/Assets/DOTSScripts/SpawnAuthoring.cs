using UnityEngine;
using Unity.Entities;
using System.Collections.Generic;

//Convert GameoObject to Entity, and give it AddComponentData
namespace DOTS.Spawning
{
    public class SpawnAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float spawn_rate;
        [SerializeField] private float max_distance_from_spawner;

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(prefab);
        }

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(
                entity,
                new Spawner { prefab = conversionSystem.GetPrimaryEntity(prefab), max_distance_from_spawner = max_distance_from_spawner, seconds_betweens_spawns = 1 / spawn_rate, seconds_to_next_spawn = 0f });
        }
    }
}