// Systems/AdjustSchoolCapacitySystem.cs
// Applies ASC settings to all school-related entities including school extensions.
// Captures vanilla baselines once per entity, then reapplies when settings change / on load.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal.Serialization.Entities;
    using Game;
    using Game.Prefabs;
    using Unity.Collections;
    using Unity.Entities;

    public sealed partial class AdjustSchoolCapacitySystem : GameSystemBase
    {
        // ---- Baseline cache ----
        private readonly Dictionary<Entity, BaselineData> m_BaselineByEntity =
            new Dictionary<Entity, BaselineData>(128);

        // ---- Queries & flags ----
        private EntityQuery m_SchoolQuery;
        private bool m_ReapplyRequested;

        // ---- Lifecycle ----
        protected override void OnCreate()
        {
            base.OnCreate();

            m_SchoolQuery = GetEntityQuery(
                ComponentType.ReadWrite<SchoolData>(),
                ComponentType.ReadWrite<ConsumptionData>());

            RequireForUpdate(m_SchoolQuery);

            // Run only when requested (load or settings Apply)
            Enabled = false;
        }

        protected override void OnGamePreload(Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);

            // When a city is loading, do one pass after prefabs are available
            if (mode == GameMode.Game)
            {
                m_ReapplyRequested = true;
                Enabled = true;
            }
        }

        protected override void OnUpdate()
        {
            if (!m_ReapplyRequested)
            {
                Enabled = false;
                return;
            }

            NativeArray<Entity> schools = m_SchoolQuery.ToEntityArray(Allocator.Temp);
            if (!schools.IsCreated || schools.Length == 0)
            {
                if (schools.IsCreated)
                {
                    schools.Dispose();
                }

                m_ReapplyRequested = false;
                Enabled = false;
                return;
            }

            Setting? setting = Mod.Setting;
            if (setting == null)
            {
                schools.Dispose();
                m_ReapplyRequested = false;
                Enabled = false;
                return;
            }

            for (int i = 0; i < schools.Length; i++)
            {
                Entity entity = schools[i];

                // Read current components
                SchoolData schoolData = EntityManager.GetComponentData<SchoolData>(entity);

                // Cache baseline once
                if (!m_BaselineByEntity.TryGetValue(entity, out BaselineData baseline))
                {
                    baseline = new BaselineData
                    {
                        StudentCapacity = schoolData.m_StudentCapacity,
                        EducationLevel = schoolData.m_EducationLevel
                    };
                    m_BaselineByEntity.Add(entity, baseline);
                }

                // Compute scalar by level and apply to capacity
                double scalar = GetScalar(setting, baseline.EducationLevel);
                schoolData.m_StudentCapacity = (int)(baseline.StudentCapacity * scalar);
                EntityManager.SetComponentData(entity, schoolData);
            }

            schools.Dispose();

            m_ReapplyRequested = false;
            Enabled = false;
        }

        // ---- Public API (called from Setting.Apply) ----
        public void RequestReapplyFromSettings()
        {
            m_ReapplyRequested = true;
            Enabled = true;
#if DEBUG
            Mod.s_Log.Info("[ASC] Settings changed → reapply requested.");
#endif
        }

        // ---- Helpers ----
        private static double GetScalar(Setting setting, byte level)
        {
            switch ((SchoolLevel)level)
            {
                case SchoolLevel.Elementary:
                    return setting.ElementarySlider / 100.0;
                case SchoolLevel.HighSchool:
                    return setting.HighSchoolSlider / 100.0;
                case SchoolLevel.College:
                    return setting.CollegeSlider / 100.0;
                case SchoolLevel.University:
                    return setting.UniversitySlider / 100.0;
                default:
                    return 1.0;
            }
        }

        private struct BaselineData
        {
            public int StudentCapacity;
            public byte EducationLevel;
        }
    }
}
