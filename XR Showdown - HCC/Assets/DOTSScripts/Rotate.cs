using Unity.Entities;

//Create struct with a IComponentData for an Entity
namespace DOTS.Rotating
{
    public struct Rotate : IComponentData
    {
        public float radians_per_second;
    }
}
