using UnityEngine;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Entities;

//Convert GameoObject to Entity, and give it AddComponentData
namespace DOTS.Rotating
{
    public class RotateAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] float degrees_per_second;
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new Rotate { radians_per_second = math.radians(degrees_per_second)});
            dstManager.AddComponentData(entity, new RotationEulerXYZ());
        }
    }
}