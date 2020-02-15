using Unity.Entities;

//Create struct with a IComponentData for an Entity
namespace DOTS.Spawning
{
    public struct Spawner : IComponentData
    {
        public Entity prefab;
        public float max_distance_from_spawner;
        public float seconds_betweens_spawns;
        public float seconds_to_next_spawn;
    }
}
