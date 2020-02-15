using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;
using Time = UnityEngine.Time;

namespace DOTS.Spawning
{
    public class SpawnerSystem : JobComponentSystem
    {
        private EndSimulationEntityCommandBufferSystem endSimulationEntityCommand;

        //Gets called at the start of the game/simulation
        protected override void OnCreate()
        {
            endSimulationEntityCommand = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        //IJobForEachWithEntity : We want this job to happen on everything that has a Spawner, and a LocalToWorld(Transform)
        private struct SpawnerJob : IJobForEachWithEntity<Spawner, LocalToWorld>
        {
            private EntityCommandBuffer.Concurrent entity_command_buffer;
            private Random random;
            private readonly float delta_time;

            public SpawnerJob(EntityCommandBuffer.Concurrent entity_command_buffer, Random random, float delta_time)
            {
                this.delta_time = delta_time;
                this.random = random;
                this.entity_command_buffer = entity_command_buffer;
            }

            //Spawn prefabs then move their Transforms to Random position in the world
            public void Execute(Entity entity, int index, ref Spawner spawner, [ReadOnly] ref LocalToWorld local_to_world)
            {
                spawner.seconds_to_next_spawn -= delta_time;

                if (spawner.seconds_to_next_spawn >= 0) { return; }

                spawner.seconds_to_next_spawn += spawner.seconds_betweens_spawns;

                Entity instance = entity_command_buffer.Instantiate(index, spawner.prefab);

                entity_command_buffer.SetComponent(index, instance, new Translation { Value = local_to_world.Position + random.NextFloat3Direction() * random.NextFloat() * spawner.max_distance_from_spawner });
            }
        }

        //Run the SpawnerJob
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var spawner_job = new SpawnerJob(endSimulationEntityCommand.CreateCommandBuffer().ToConcurrent(), new Random((uint)UnityEngine.Random.Range(0, int.MaxValue)), Time.DeltaTime);

            JobHandle job_handle = spawner_job.Schedule(this, inputDeps);

            endSimulationEntityCommand.AddJobHandleForProducer(job_handle);

            return job_handle;
        }
    }
}
