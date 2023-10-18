using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_SphereCastCollider_Field :ICameraMovementControlField<Cinemachine.SphereCastCollider>
    {
       public  Type AttachControlField => typeof(Cinemachine.SphereCastCollider);

       [UnityEngine.TooltipAttribute("Obstacles with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
            public DataMixer <System.String> m_IgnoreTag;
       [UnityEngine.TooltipAttribute("Obstacles closer to the target than this will be ignored")]
            public DataMixer <System.Single> m_MinimumDistanceFromTarget;
        public float m_MinimumDistanceFromTargetAlertInit;
        public float m_MinimumDistanceFromTargetDiff;
       [UnityEngine.TooltipAttribute("When enabled, will attempt to resolve situations where the line of sight to the target is blocked by an obstacle")]
            public DataMixer <System.Boolean> m_AvoidObstacles;
       [UnityEngine.TooltipAttribute("The maximum raycast distance when checking if the line of sight to this camera's target is clear.  If the setting is 0 or less, the current actual distance to target will be used.")]
            public DataMixer <System.Single> m_DistanceLimit;
        public float m_DistanceLimitAlertInit;
        public float m_DistanceLimitDiff;
       [UnityEngine.TooltipAttribute("Don't take action unless occlusion has lasted at least this long.")]
            public DataMixer <System.Single> m_MinimumOcclusionTime;
        public float m_MinimumOcclusionTimeAlertInit;
        public float m_MinimumOcclusionTimeDiff;
       [UnityEngine.TooltipAttribute("Camera will try to maintain this distance from any obstacle.  Try to keep this value small.  Increase it if you are seeing inside obstacles due to a large FOV on the camera.")]
            public DataMixer <System.Single> m_CameraRadius;
        public float m_CameraRadiusAlertInit;
        public float m_CameraRadiusDiff;
       [UnityEngine.TooltipAttribute("The way in which the Collider will attempt to preserve sight of the target.")]
            public DataMixer <Cinemachine.SphereCastCollider.ResolutionStrategy> m_Strategy;
       [UnityEngine.TooltipAttribute("Upper limit on how many obstacle hits to process.  Higher numbers may impact performance.  In most environments, 4 is enough.")]
            public DataMixer <System.Int32> m_MaximumEffort;
       [UnityEngine.TooltipAttribute("Smoothing to apply to obstruction resolution.  Nearest camera point is held for at least this long")]
            public DataMixer <System.Single> m_SmoothingTime;
        public float m_SmoothingTimeAlertInit;
        public float m_SmoothingTimeDiff;
       [UnityEngine.TooltipAttribute("How gradually the camera returns to its normal position after having been corrected.  Higher numbers will move the camera more gradually back to normal.")]
            public DataMixer <System.Single> m_Damping;
        public float m_DampingAlertInit;
        public float m_DampingDiff;
       [UnityEngine.TooltipAttribute("How gradually the camera moves to resolve an occlusion.  Higher numbers will move the camera more gradually.")]
            public DataMixer <System.Single> m_DampingWhenOccluded;
        public float m_DampingWhenOccludedAlertInit;
        public float m_DampingWhenOccludedDiff;
       [UnityEngine.HeaderAttribute("Shot Evaluation")]
           [UnityEngine.TooltipAttribute("If greater than zero, a higher score will be given to shots when the target is closer to this distance.  Set this to zero to disable this feature.")]
            public DataMixer <System.Single> m_OptimalTargetDistance;
        public float m_OptimalTargetDistanceAlertInit;
        public float m_OptimalTargetDistanceDiff;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.SphereCastCollider target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_SphereCastCollider_Config source = (CameraMovement.Control_C_SphereCastCollider_Config)sourceConfig;
            if(source.m_IgnoreTag.IsUse)
            {
                m_IgnoreTag.Add(new MixItem<System.String>(id, priority, source.m_IgnoreTag.CalculatorExpression, source.m_IgnoreTag.Value, source.m_IgnoreTag.IsUse));
            }
            if(source.m_MinimumDistanceFromTarget.IsUse)
            {
                m_MinimumDistanceFromTarget.Add(new MixItem<System.Single>(id, priority, source.m_MinimumDistanceFromTarget.CalculatorExpression, source.m_MinimumDistanceFromTarget.Value, source.m_MinimumDistanceFromTarget.IsUse));
               var targetValue = (m_MinimumDistanceFromTarget.IsExpression ? m_MinimumDistanceFromTarget.Value : m_MinimumDistanceFromTarget.PrimitiveValue);
               m_MinimumDistanceFromTargetDiff = targetValue - target.m_MinimumDistanceFromTarget;
               if(templateDict[m_MinimumDistanceFromTarget.Id].Config.alertCurve != null) m_MinimumDistanceFromTargetAlertInit = target.m_MinimumDistanceFromTarget - templateDict[m_MinimumDistanceFromTarget.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumDistanceFromTarget.Id].CostTime / templateDict[m_MinimumDistanceFromTarget.Id].Config.duration) * (m_MinimumDistanceFromTargetDiff);
            }
            if(source.m_AvoidObstacles.IsUse)
            {
                m_AvoidObstacles.Add(new MixItem<System.Boolean>(id, priority, source.m_AvoidObstacles.CalculatorExpression, source.m_AvoidObstacles.Value, source.m_AvoidObstacles.IsUse));
            }
            if(source.m_DistanceLimit.IsUse)
            {
                m_DistanceLimit.Add(new MixItem<System.Single>(id, priority, source.m_DistanceLimit.CalculatorExpression, source.m_DistanceLimit.Value, source.m_DistanceLimit.IsUse));
               var targetValue = (m_DistanceLimit.IsExpression ? m_DistanceLimit.Value : m_DistanceLimit.PrimitiveValue);
               m_DistanceLimitDiff = targetValue - target.m_DistanceLimit;
               if(templateDict[m_DistanceLimit.Id].Config.alertCurve != null) m_DistanceLimitAlertInit = target.m_DistanceLimit - templateDict[m_DistanceLimit.Id].Config.alertCurve.Evaluate(templateDict[m_DistanceLimit.Id].CostTime / templateDict[m_DistanceLimit.Id].Config.duration) * (m_DistanceLimitDiff);
            }
            if(source.m_MinimumOcclusionTime.IsUse)
            {
                m_MinimumOcclusionTime.Add(new MixItem<System.Single>(id, priority, source.m_MinimumOcclusionTime.CalculatorExpression, source.m_MinimumOcclusionTime.Value, source.m_MinimumOcclusionTime.IsUse));
               var targetValue = (m_MinimumOcclusionTime.IsExpression ? m_MinimumOcclusionTime.Value : m_MinimumOcclusionTime.PrimitiveValue);
               m_MinimumOcclusionTimeDiff = targetValue - target.m_MinimumOcclusionTime;
               if(templateDict[m_MinimumOcclusionTime.Id].Config.alertCurve != null) m_MinimumOcclusionTimeAlertInit = target.m_MinimumOcclusionTime - templateDict[m_MinimumOcclusionTime.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumOcclusionTime.Id].CostTime / templateDict[m_MinimumOcclusionTime.Id].Config.duration) * (m_MinimumOcclusionTimeDiff);
            }
            if(source.m_CameraRadius.IsUse)
            {
                m_CameraRadius.Add(new MixItem<System.Single>(id, priority, source.m_CameraRadius.CalculatorExpression, source.m_CameraRadius.Value, source.m_CameraRadius.IsUse));
               var targetValue = (m_CameraRadius.IsExpression ? m_CameraRadius.Value : m_CameraRadius.PrimitiveValue);
               m_CameraRadiusDiff = targetValue - target.m_CameraRadius;
               if(templateDict[m_CameraRadius.Id].Config.alertCurve != null) m_CameraRadiusAlertInit = target.m_CameraRadius - templateDict[m_CameraRadius.Id].Config.alertCurve.Evaluate(templateDict[m_CameraRadius.Id].CostTime / templateDict[m_CameraRadius.Id].Config.duration) * (m_CameraRadiusDiff);
            }
            if(source.m_Strategy.IsUse)
            {
                m_Strategy.Add(new MixItem<Cinemachine.SphereCastCollider.ResolutionStrategy>(id, priority, source.m_Strategy.CalculatorExpression, source.m_Strategy.Value, source.m_Strategy.IsUse));
            }
            if(source.m_MaximumEffort.IsUse)
            {
                m_MaximumEffort.Add(new MixItem<System.Int32>(id, priority, source.m_MaximumEffort.CalculatorExpression, source.m_MaximumEffort.Value, source.m_MaximumEffort.IsUse));
            }
            if(source.m_SmoothingTime.IsUse)
            {
                m_SmoothingTime.Add(new MixItem<System.Single>(id, priority, source.m_SmoothingTime.CalculatorExpression, source.m_SmoothingTime.Value, source.m_SmoothingTime.IsUse));
               var targetValue = (m_SmoothingTime.IsExpression ? m_SmoothingTime.Value : m_SmoothingTime.PrimitiveValue);
               m_SmoothingTimeDiff = targetValue - target.m_SmoothingTime;
               if(templateDict[m_SmoothingTime.Id].Config.alertCurve != null) m_SmoothingTimeAlertInit = target.m_SmoothingTime - templateDict[m_SmoothingTime.Id].Config.alertCurve.Evaluate(templateDict[m_SmoothingTime.Id].CostTime / templateDict[m_SmoothingTime.Id].Config.duration) * (m_SmoothingTimeDiff);
            }
            if(source.m_Damping.IsUse)
            {
                m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
               var targetValue = (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
               m_DampingDiff = targetValue - target.m_Damping;
               if(templateDict[m_Damping.Id].Config.alertCurve != null) m_DampingAlertInit = target.m_Damping - templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (m_DampingDiff);
            }
            if(source.m_DampingWhenOccluded.IsUse)
            {
                m_DampingWhenOccluded.Add(new MixItem<System.Single>(id, priority, source.m_DampingWhenOccluded.CalculatorExpression, source.m_DampingWhenOccluded.Value, source.m_DampingWhenOccluded.IsUse));
               var targetValue = (m_DampingWhenOccluded.IsExpression ? m_DampingWhenOccluded.Value : m_DampingWhenOccluded.PrimitiveValue);
               m_DampingWhenOccludedDiff = targetValue - target.m_DampingWhenOccluded;
               if(templateDict[m_DampingWhenOccluded.Id].Config.alertCurve != null) m_DampingWhenOccludedAlertInit = target.m_DampingWhenOccluded - templateDict[m_DampingWhenOccluded.Id].Config.alertCurve.Evaluate(templateDict[m_DampingWhenOccluded.Id].CostTime / templateDict[m_DampingWhenOccluded.Id].Config.duration) * (m_DampingWhenOccludedDiff);
            }
            if(source.m_OptimalTargetDistance.IsUse)
            {
                m_OptimalTargetDistance.Add(new MixItem<System.Single>(id, priority, source.m_OptimalTargetDistance.CalculatorExpression, source.m_OptimalTargetDistance.Value, source.m_OptimalTargetDistance.IsUse));
               var targetValue = (m_OptimalTargetDistance.IsExpression ? m_OptimalTargetDistance.Value : m_OptimalTargetDistance.PrimitiveValue);
               m_OptimalTargetDistanceDiff = targetValue - target.m_OptimalTargetDistance;
               if(templateDict[m_OptimalTargetDistance.Id].Config.alertCurve != null) m_OptimalTargetDistanceAlertInit = target.m_OptimalTargetDistance - templateDict[m_OptimalTargetDistance.Id].Config.alertCurve.Evaluate(templateDict[m_OptimalTargetDistance.Id].CostTime / templateDict[m_OptimalTargetDistance.Id].Config.duration) * (m_OptimalTargetDistanceDiff);
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.SphereCastCollider target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_SphereCastCollider_Config source = (CameraMovement.Control_C_SphereCastCollider_Config)sourceConfig;
            if(source.m_IgnoreTag.IsUse)
            {
                m_IgnoreTag.Remove(new MixItem<System.String>(id, priority, source.m_IgnoreTag.CalculatorExpression, source.m_IgnoreTag.Value, source.m_IgnoreTag.IsUse));
            }
            if(source.m_MinimumDistanceFromTarget.IsUse)
            {
                m_MinimumDistanceFromTarget.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumDistanceFromTarget.CalculatorExpression, source.m_MinimumDistanceFromTarget.Value, source.m_MinimumDistanceFromTarget.IsUse));
               var targetValue = (m_MinimumDistanceFromTarget.IsExpression ? m_MinimumDistanceFromTarget.Value : m_MinimumDistanceFromTarget.PrimitiveValue);
               m_MinimumDistanceFromTargetDiff = targetValue - target.m_MinimumDistanceFromTarget;
               if(templateDict[m_MinimumDistanceFromTarget.Id].Config.alertCurve != null) m_MinimumDistanceFromTargetAlertInit = target.m_MinimumDistanceFromTarget - templateDict[m_MinimumDistanceFromTarget.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumDistanceFromTarget.Id].CostTime / templateDict[m_MinimumDistanceFromTarget.Id].Config.duration) * (m_MinimumDistanceFromTargetDiff);
            }
            if(source.m_AvoidObstacles.IsUse)
            {
                m_AvoidObstacles.Remove(new MixItem<System.Boolean>(id, priority, source.m_AvoidObstacles.CalculatorExpression, source.m_AvoidObstacles.Value, source.m_AvoidObstacles.IsUse));
            }
            if(source.m_DistanceLimit.IsUse)
            {
                m_DistanceLimit.Remove(new MixItem<System.Single>(id, priority, source.m_DistanceLimit.CalculatorExpression, source.m_DistanceLimit.Value, source.m_DistanceLimit.IsUse));
               var targetValue = (m_DistanceLimit.IsExpression ? m_DistanceLimit.Value : m_DistanceLimit.PrimitiveValue);
               m_DistanceLimitDiff = targetValue - target.m_DistanceLimit;
               if(templateDict[m_DistanceLimit.Id].Config.alertCurve != null) m_DistanceLimitAlertInit = target.m_DistanceLimit - templateDict[m_DistanceLimit.Id].Config.alertCurve.Evaluate(templateDict[m_DistanceLimit.Id].CostTime / templateDict[m_DistanceLimit.Id].Config.duration) * (m_DistanceLimitDiff);
            }
            if(source.m_MinimumOcclusionTime.IsUse)
            {
                m_MinimumOcclusionTime.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumOcclusionTime.CalculatorExpression, source.m_MinimumOcclusionTime.Value, source.m_MinimumOcclusionTime.IsUse));
               var targetValue = (m_MinimumOcclusionTime.IsExpression ? m_MinimumOcclusionTime.Value : m_MinimumOcclusionTime.PrimitiveValue);
               m_MinimumOcclusionTimeDiff = targetValue - target.m_MinimumOcclusionTime;
               if(templateDict[m_MinimumOcclusionTime.Id].Config.alertCurve != null) m_MinimumOcclusionTimeAlertInit = target.m_MinimumOcclusionTime - templateDict[m_MinimumOcclusionTime.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumOcclusionTime.Id].CostTime / templateDict[m_MinimumOcclusionTime.Id].Config.duration) * (m_MinimumOcclusionTimeDiff);
            }
            if(source.m_CameraRadius.IsUse)
            {
                m_CameraRadius.Remove(new MixItem<System.Single>(id, priority, source.m_CameraRadius.CalculatorExpression, source.m_CameraRadius.Value, source.m_CameraRadius.IsUse));
               var targetValue = (m_CameraRadius.IsExpression ? m_CameraRadius.Value : m_CameraRadius.PrimitiveValue);
               m_CameraRadiusDiff = targetValue - target.m_CameraRadius;
               if(templateDict[m_CameraRadius.Id].Config.alertCurve != null) m_CameraRadiusAlertInit = target.m_CameraRadius - templateDict[m_CameraRadius.Id].Config.alertCurve.Evaluate(templateDict[m_CameraRadius.Id].CostTime / templateDict[m_CameraRadius.Id].Config.duration) * (m_CameraRadiusDiff);
            }
            if(source.m_Strategy.IsUse)
            {
                m_Strategy.Remove(new MixItem<Cinemachine.SphereCastCollider.ResolutionStrategy>(id, priority, source.m_Strategy.CalculatorExpression, source.m_Strategy.Value, source.m_Strategy.IsUse));
            }
            if(source.m_MaximumEffort.IsUse)
            {
                m_MaximumEffort.Remove(new MixItem<System.Int32>(id, priority, source.m_MaximumEffort.CalculatorExpression, source.m_MaximumEffort.Value, source.m_MaximumEffort.IsUse));
            }
            if(source.m_SmoothingTime.IsUse)
            {
                m_SmoothingTime.Remove(new MixItem<System.Single>(id, priority, source.m_SmoothingTime.CalculatorExpression, source.m_SmoothingTime.Value, source.m_SmoothingTime.IsUse));
               var targetValue = (m_SmoothingTime.IsExpression ? m_SmoothingTime.Value : m_SmoothingTime.PrimitiveValue);
               m_SmoothingTimeDiff = targetValue - target.m_SmoothingTime;
               if(templateDict[m_SmoothingTime.Id].Config.alertCurve != null) m_SmoothingTimeAlertInit = target.m_SmoothingTime - templateDict[m_SmoothingTime.Id].Config.alertCurve.Evaluate(templateDict[m_SmoothingTime.Id].CostTime / templateDict[m_SmoothingTime.Id].Config.duration) * (m_SmoothingTimeDiff);
            }
            if(source.m_Damping.IsUse)
            {
                m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value, source.m_Damping.IsUse));
               var targetValue = (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
               m_DampingDiff = targetValue - target.m_Damping;
               if(templateDict[m_Damping.Id].Config.alertCurve != null) m_DampingAlertInit = target.m_Damping - templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * (m_DampingDiff);
            }
            if(source.m_DampingWhenOccluded.IsUse)
            {
                m_DampingWhenOccluded.Remove(new MixItem<System.Single>(id, priority, source.m_DampingWhenOccluded.CalculatorExpression, source.m_DampingWhenOccluded.Value, source.m_DampingWhenOccluded.IsUse));
               var targetValue = (m_DampingWhenOccluded.IsExpression ? m_DampingWhenOccluded.Value : m_DampingWhenOccluded.PrimitiveValue);
               m_DampingWhenOccludedDiff = targetValue - target.m_DampingWhenOccluded;
               if(templateDict[m_DampingWhenOccluded.Id].Config.alertCurve != null) m_DampingWhenOccludedAlertInit = target.m_DampingWhenOccluded - templateDict[m_DampingWhenOccluded.Id].Config.alertCurve.Evaluate(templateDict[m_DampingWhenOccluded.Id].CostTime / templateDict[m_DampingWhenOccluded.Id].Config.duration) * (m_DampingWhenOccludedDiff);
            }
            if(source.m_OptimalTargetDistance.IsUse)
            {
                m_OptimalTargetDistance.Remove(new MixItem<System.Single>(id, priority, source.m_OptimalTargetDistance.CalculatorExpression, source.m_OptimalTargetDistance.Value, source.m_OptimalTargetDistance.IsUse));
               var targetValue = (m_OptimalTargetDistance.IsExpression ? m_OptimalTargetDistance.Value : m_OptimalTargetDistance.PrimitiveValue);
               m_OptimalTargetDistanceDiff = targetValue - target.m_OptimalTargetDistance;
               if(templateDict[m_OptimalTargetDistance.Id].Config.alertCurve != null) m_OptimalTargetDistanceAlertInit = target.m_OptimalTargetDistance - templateDict[m_OptimalTargetDistance.Id].Config.alertCurve.Evaluate(templateDict[m_OptimalTargetDistance.Id].CostTime / templateDict[m_OptimalTargetDistance.Id].Config.duration) * (m_OptimalTargetDistanceDiff);
            }
        }
        public void RemoveAll()
        {
            m_IgnoreTag.RemoveAll();
            m_MinimumDistanceFromTarget.RemoveAll();
            m_AvoidObstacles.RemoveAll();
            m_DistanceLimit.RemoveAll();
            m_MinimumOcclusionTime.RemoveAll();
            m_CameraRadius.RemoveAll();
            m_Strategy.RemoveAll();
            m_MaximumEffort.RemoveAll();
            m_SmoothingTime.RemoveAll();
            m_Damping.RemoveAll();
            m_DampingWhenOccluded.RemoveAll();
            m_OptimalTargetDistance.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.SphereCastCollider target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_IgnoreTag.IsUse) target.m_IgnoreTag = m_IgnoreTag.PrimitiveValue;
            if (m_MinimumDistanceFromTarget.IsUse && templateDict.ContainsKey(m_MinimumDistanceFromTarget.Id))
            {
                var targetValue = (m_MinimumDistanceFromTarget.IsExpression ? m_MinimumDistanceFromTarget.Value : m_MinimumDistanceFromTarget.PrimitiveValue);
                target.m_MinimumDistanceFromTarget = Mathf.Approximately(0, templateDict[m_MinimumDistanceFromTarget.Id].Config.duration) ? targetValue : m_MinimumDistanceFromTargetAlertInit + templateDict[m_MinimumDistanceFromTarget.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumDistanceFromTarget.Id].CostTime / templateDict[m_MinimumDistanceFromTarget.Id].Config.duration) * m_MinimumDistanceFromTargetDiff;
            }
            if (m_AvoidObstacles.IsUse) target.m_AvoidObstacles = m_AvoidObstacles.IsExpression ? !Mathf.Approximately(m_AvoidObstacles.Value, 0) : m_AvoidObstacles.PrimitiveValue;
            if (m_DistanceLimit.IsUse && templateDict.ContainsKey(m_DistanceLimit.Id))
            {
                var targetValue = (m_DistanceLimit.IsExpression ? m_DistanceLimit.Value : m_DistanceLimit.PrimitiveValue);
                target.m_DistanceLimit = Mathf.Approximately(0, templateDict[m_DistanceLimit.Id].Config.duration) ? targetValue : m_DistanceLimitAlertInit + templateDict[m_DistanceLimit.Id].Config.alertCurve.Evaluate(templateDict[m_DistanceLimit.Id].CostTime / templateDict[m_DistanceLimit.Id].Config.duration) * m_DistanceLimitDiff;
            }
            if (m_MinimumOcclusionTime.IsUse && templateDict.ContainsKey(m_MinimumOcclusionTime.Id))
            {
                var targetValue = (m_MinimumOcclusionTime.IsExpression ? m_MinimumOcclusionTime.Value : m_MinimumOcclusionTime.PrimitiveValue);
                target.m_MinimumOcclusionTime = Mathf.Approximately(0, templateDict[m_MinimumOcclusionTime.Id].Config.duration) ? targetValue : m_MinimumOcclusionTimeAlertInit + templateDict[m_MinimumOcclusionTime.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumOcclusionTime.Id].CostTime / templateDict[m_MinimumOcclusionTime.Id].Config.duration) * m_MinimumOcclusionTimeDiff;
            }
            if (m_CameraRadius.IsUse && templateDict.ContainsKey(m_CameraRadius.Id))
            {
                var targetValue = (m_CameraRadius.IsExpression ? m_CameraRadius.Value : m_CameraRadius.PrimitiveValue);
                target.m_CameraRadius = Mathf.Approximately(0, templateDict[m_CameraRadius.Id].Config.duration) ? targetValue : m_CameraRadiusAlertInit + templateDict[m_CameraRadius.Id].Config.alertCurve.Evaluate(templateDict[m_CameraRadius.Id].CostTime / templateDict[m_CameraRadius.Id].Config.duration) * m_CameraRadiusDiff;
            }
            if (m_Strategy.IsUse) target.m_Strategy = m_Strategy.IsExpression ? (Cinemachine.SphereCastCollider.ResolutionStrategy)m_Strategy.Value :m_Strategy.PrimitiveValue;
            if (m_MaximumEffort.IsUse) target.m_MaximumEffort = m_MaximumEffort.IsExpression ? (System.Int32)m_MaximumEffort.Value :m_MaximumEffort.PrimitiveValue;
            if (m_SmoothingTime.IsUse && templateDict.ContainsKey(m_SmoothingTime.Id))
            {
                var targetValue = (m_SmoothingTime.IsExpression ? m_SmoothingTime.Value : m_SmoothingTime.PrimitiveValue);
                target.m_SmoothingTime = Mathf.Approximately(0, templateDict[m_SmoothingTime.Id].Config.duration) ? targetValue : m_SmoothingTimeAlertInit + templateDict[m_SmoothingTime.Id].Config.alertCurve.Evaluate(templateDict[m_SmoothingTime.Id].CostTime / templateDict[m_SmoothingTime.Id].Config.duration) * m_SmoothingTimeDiff;
            }
            if (m_Damping.IsUse && templateDict.ContainsKey(m_Damping.Id))
            {
                var targetValue = (m_Damping.IsExpression ? m_Damping.Value : m_Damping.PrimitiveValue);
                target.m_Damping = Mathf.Approximately(0, templateDict[m_Damping.Id].Config.duration) ? targetValue : m_DampingAlertInit + templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * m_DampingDiff;
            }
            if (m_DampingWhenOccluded.IsUse && templateDict.ContainsKey(m_DampingWhenOccluded.Id))
            {
                var targetValue = (m_DampingWhenOccluded.IsExpression ? m_DampingWhenOccluded.Value : m_DampingWhenOccluded.PrimitiveValue);
                target.m_DampingWhenOccluded = Mathf.Approximately(0, templateDict[m_DampingWhenOccluded.Id].Config.duration) ? targetValue : m_DampingWhenOccludedAlertInit + templateDict[m_DampingWhenOccluded.Id].Config.alertCurve.Evaluate(templateDict[m_DampingWhenOccluded.Id].CostTime / templateDict[m_DampingWhenOccluded.Id].Config.duration) * m_DampingWhenOccludedDiff;
            }
            if (m_OptimalTargetDistance.IsUse && templateDict.ContainsKey(m_OptimalTargetDistance.Id))
            {
                var targetValue = (m_OptimalTargetDistance.IsExpression ? m_OptimalTargetDistance.Value : m_OptimalTargetDistance.PrimitiveValue);
                target.m_OptimalTargetDistance = Mathf.Approximately(0, templateDict[m_OptimalTargetDistance.Id].Config.duration) ? targetValue : m_OptimalTargetDistanceAlertInit + templateDict[m_OptimalTargetDistance.Id].Config.alertCurve.Evaluate(templateDict[m_OptimalTargetDistance.Id].CostTime / templateDict[m_OptimalTargetDistance.Id].Config.duration) * m_OptimalTargetDistanceDiff;
            }
        }
    }
}
