using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;
 
namespace DOTS.Rotating
{
    public class RotateSystem : JobComponentSystem
    {
        //Run the RotateJob
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            float delta_time = Time.DeltaTime;

            var job_handle = Entities.ForEach((ref RotationEulerXYZ eular, in Rotate rotate) =>
           {
               eular.Value.y += rotate.radians_per_second * delta_time;
           }).Schedule(inputDeps);

            return job_handle;
        }
    }
}