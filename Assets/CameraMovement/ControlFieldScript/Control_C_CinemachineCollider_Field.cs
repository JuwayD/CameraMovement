using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineCollider_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineCollider);

       [UnityEngine.TooltipAttribute("Obstacles with this tag will be ignored.  It is a good idea to set this field to the target's tag")]
            public DataMixer <System.String> m_IgnoreTag;
       [UnityEngine.TooltipAttribute("Obstacles closer to the target than this will be ignored")]
            public DataMixer <System.Single> m_MinimumDistanceFromTarget;
       [UnityEngine.TooltipAttribute("When enabled, will attempt to resolve situations where the line of sight to the target is blocked by an obstacle")]
            public DataMixer <System.Boolean> m_AvoidObstacles;
       [UnityEngine.TooltipAttribute("The maximum raycast distance when checking if the line of sight to this camera's target is clear.  If the setting is 0 or less, the current actual distance to target will be used.")]
            public DataMixer <System.Single> m_DistanceLimit;
       [UnityEngine.TooltipAttribute("Don't take action unless occlusion has lasted at least this long.")]
            public DataMixer <System.Single> m_MinimumOcclusionTime;
       [UnityEngine.TooltipAttribute("Camera will try to maintain this distance from any obstacle.  Try to keep this value small.  Increase it if you are seeing inside obstacles due to a large FOV on the camera.")]
            public DataMixer <System.Single> m_CameraRadius;
       [UnityEngine.TooltipAttribute("The way in which the Collider will attempt to preserve sight of the target.")]
            public DataMixer <Cinemachine.CinemachineCollider.ResolutionStrategy> m_Strategy;
       [UnityEngine.TooltipAttribute("Upper limit on how many obstacle hits to process.  Higher numbers may impact performance.  In most environments, 4 is enough.")]
            public DataMixer <System.Int32> m_MaximumEffort;
       [UnityEngine.TooltipAttribute("Smoothing to apply to obstruction resolution.  Nearest camera point is held for at least this long")]
            public DataMixer <System.Single> m_SmoothingTime;
       [UnityEngine.TooltipAttribute("How gradually the camera returns to its normal position after having been corrected.  Higher numbers will move the camera more gradually back to normal.")]
            public DataMixer <System.Single> m_Damping;
       [UnityEngine.TooltipAttribute("How gradually the camera moves to resolve an occlusion.  Higher numbers will move the camera more gradually.")]
            public DataMixer <System.Single> m_DampingWhenOccluded;
       [UnityEngine.HeaderAttribute("Shot Evaluation")]
           [UnityEngine.TooltipAttribute("If greater than zero, a higher score will be given to shots when the target is closer to this distance.  Set this to zero to disable this feature.")]
            public DataMixer <System.Single> m_OptimalTargetDistance;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineCollider_Config source = (CameraMovement.Control_C_CinemachineCollider_Config)sourceConfig;
            if(source.m_IgnoreTag.IsUse) m_IgnoreTag.Add(new MixItem<System.String>(id, priority, source.m_IgnoreTag.CalculatorExpression, source.m_IgnoreTag.Value));
            if(source.m_MinimumDistanceFromTarget.IsUse) m_MinimumDistanceFromTarget.Add(new MixItem<System.Single>(id, priority, source.m_MinimumDistanceFromTarget.CalculatorExpression, source.m_MinimumDistanceFromTarget.Value));
            if(source.m_AvoidObstacles.IsUse) m_AvoidObstacles.Add(new MixItem<System.Boolean>(id, priority, source.m_AvoidObstacles.CalculatorExpression, source.m_AvoidObstacles.Value));
            if(source.m_DistanceLimit.IsUse) m_DistanceLimit.Add(new MixItem<System.Single>(id, priority, source.m_DistanceLimit.CalculatorExpression, source.m_DistanceLimit.Value));
            if(source.m_MinimumOcclusionTime.IsUse) m_MinimumOcclusionTime.Add(new MixItem<System.Single>(id, priority, source.m_MinimumOcclusionTime.CalculatorExpression, source.m_MinimumOcclusionTime.Value));
            if(source.m_CameraRadius.IsUse) m_CameraRadius.Add(new MixItem<System.Single>(id, priority, source.m_CameraRadius.CalculatorExpression, source.m_CameraRadius.Value));
            if(source.m_Strategy.IsUse) m_Strategy.Add(new MixItem<Cinemachine.CinemachineCollider.ResolutionStrategy>(id, priority, source.m_Strategy.CalculatorExpression, source.m_Strategy.Value));
            if(source.m_MaximumEffort.IsUse) m_MaximumEffort.Add(new MixItem<System.Int32>(id, priority, source.m_MaximumEffort.CalculatorExpression, source.m_MaximumEffort.Value));
            if(source.m_SmoothingTime.IsUse) m_SmoothingTime.Add(new MixItem<System.Single>(id, priority, source.m_SmoothingTime.CalculatorExpression, source.m_SmoothingTime.Value));
            if(source.m_Damping.IsUse) m_Damping.Add(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value));
            if(source.m_DampingWhenOccluded.IsUse) m_DampingWhenOccluded.Add(new MixItem<System.Single>(id, priority, source.m_DampingWhenOccluded.CalculatorExpression, source.m_DampingWhenOccluded.Value));
            if(source.m_OptimalTargetDistance.IsUse) m_OptimalTargetDistance.Add(new MixItem<System.Single>(id, priority, source.m_OptimalTargetDistance.CalculatorExpression, source.m_OptimalTargetDistance.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineCollider_Config source = (CameraMovement.Control_C_CinemachineCollider_Config)sourceConfig;
            if(source.m_IgnoreTag.IsUse) m_IgnoreTag.Remove(new MixItem<System.String>(id, priority, source.m_IgnoreTag.CalculatorExpression, source.m_IgnoreTag.Value));
            if(source.m_MinimumDistanceFromTarget.IsUse) m_MinimumDistanceFromTarget.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumDistanceFromTarget.CalculatorExpression, source.m_MinimumDistanceFromTarget.Value));
            if(source.m_AvoidObstacles.IsUse) m_AvoidObstacles.Remove(new MixItem<System.Boolean>(id, priority, source.m_AvoidObstacles.CalculatorExpression, source.m_AvoidObstacles.Value));
            if(source.m_DistanceLimit.IsUse) m_DistanceLimit.Remove(new MixItem<System.Single>(id, priority, source.m_DistanceLimit.CalculatorExpression, source.m_DistanceLimit.Value));
            if(source.m_MinimumOcclusionTime.IsUse) m_MinimumOcclusionTime.Remove(new MixItem<System.Single>(id, priority, source.m_MinimumOcclusionTime.CalculatorExpression, source.m_MinimumOcclusionTime.Value));
            if(source.m_CameraRadius.IsUse) m_CameraRadius.Remove(new MixItem<System.Single>(id, priority, source.m_CameraRadius.CalculatorExpression, source.m_CameraRadius.Value));
            if(source.m_Strategy.IsUse) m_Strategy.Remove(new MixItem<Cinemachine.CinemachineCollider.ResolutionStrategy>(id, priority, source.m_Strategy.CalculatorExpression, source.m_Strategy.Value));
            if(source.m_MaximumEffort.IsUse) m_MaximumEffort.Remove(new MixItem<System.Int32>(id, priority, source.m_MaximumEffort.CalculatorExpression, source.m_MaximumEffort.Value));
            if(source.m_SmoothingTime.IsUse) m_SmoothingTime.Remove(new MixItem<System.Single>(id, priority, source.m_SmoothingTime.CalculatorExpression, source.m_SmoothingTime.Value));
            if(source.m_Damping.IsUse) m_Damping.Remove(new MixItem<System.Single>(id, priority, source.m_Damping.CalculatorExpression, source.m_Damping.Value));
            if(source.m_DampingWhenOccluded.IsUse) m_DampingWhenOccluded.Remove(new MixItem<System.Single>(id, priority, source.m_DampingWhenOccluded.CalculatorExpression, source.m_DampingWhenOccluded.Value));
            if(source.m_OptimalTargetDistance.IsUse) m_OptimalTargetDistance.Remove(new MixItem<System.Single>(id, priority, source.m_OptimalTargetDistance.CalculatorExpression, source.m_OptimalTargetDistance.Value));
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
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineCollider)targetObj;
            target.m_IgnoreTag = (String)m_IgnoreTag.PrimitiveValue;
            if (templateDict.ContainsKey(m_MinimumDistanceFromTarget.Id))
                target.m_MinimumDistanceFromTarget = templateDict[m_MinimumDistanceFromTarget.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumDistanceFromTarget.Id].CostTime / templateDict[m_MinimumDistanceFromTarget.Id].Config.duration) * m_MinimumDistanceFromTarget.Value;
            target.m_MinimumDistanceFromTarget = (System.Single)m_MinimumDistanceFromTarget.Value;
            target.m_AvoidObstacles = !Mathf.Approximately(m_AvoidObstacles.Value, 0);
            if (templateDict.ContainsKey(m_DistanceLimit.Id))
                target.m_DistanceLimit = templateDict[m_DistanceLimit.Id].Config.alertCurve.Evaluate(templateDict[m_DistanceLimit.Id].CostTime / templateDict[m_DistanceLimit.Id].Config.duration) * m_DistanceLimit.Value;
            target.m_DistanceLimit = (System.Single)m_DistanceLimit.Value;
            if (templateDict.ContainsKey(m_MinimumOcclusionTime.Id))
                target.m_MinimumOcclusionTime = templateDict[m_MinimumOcclusionTime.Id].Config.alertCurve.Evaluate(templateDict[m_MinimumOcclusionTime.Id].CostTime / templateDict[m_MinimumOcclusionTime.Id].Config.duration) * m_MinimumOcclusionTime.Value;
            target.m_MinimumOcclusionTime = (System.Single)m_MinimumOcclusionTime.Value;
            if (templateDict.ContainsKey(m_CameraRadius.Id))
                target.m_CameraRadius = templateDict[m_CameraRadius.Id].Config.alertCurve.Evaluate(templateDict[m_CameraRadius.Id].CostTime / templateDict[m_CameraRadius.Id].Config.duration) * m_CameraRadius.Value;
            target.m_CameraRadius = (System.Single)m_CameraRadius.Value;
            target.m_Strategy = (Cinemachine.CinemachineCollider.ResolutionStrategy)m_Strategy.Value;
            target.m_MaximumEffort = (System.Int32)m_MaximumEffort.Value;
            if (templateDict.ContainsKey(m_SmoothingTime.Id))
                target.m_SmoothingTime = templateDict[m_SmoothingTime.Id].Config.alertCurve.Evaluate(templateDict[m_SmoothingTime.Id].CostTime / templateDict[m_SmoothingTime.Id].Config.duration) * m_SmoothingTime.Value;
            target.m_SmoothingTime = (System.Single)m_SmoothingTime.Value;
            if (templateDict.ContainsKey(m_Damping.Id))
                target.m_Damping = templateDict[m_Damping.Id].Config.alertCurve.Evaluate(templateDict[m_Damping.Id].CostTime / templateDict[m_Damping.Id].Config.duration) * m_Damping.Value;
            target.m_Damping = (System.Single)m_Damping.Value;
            if (templateDict.ContainsKey(m_DampingWhenOccluded.Id))
                target.m_DampingWhenOccluded = templateDict[m_DampingWhenOccluded.Id].Config.alertCurve.Evaluate(templateDict[m_DampingWhenOccluded.Id].CostTime / templateDict[m_DampingWhenOccluded.Id].Config.duration) * m_DampingWhenOccluded.Value;
            target.m_DampingWhenOccluded = (System.Single)m_DampingWhenOccluded.Value;
            if (templateDict.ContainsKey(m_OptimalTargetDistance.Id))
                target.m_OptimalTargetDistance = templateDict[m_OptimalTargetDistance.Id].Config.alertCurve.Evaluate(templateDict[m_OptimalTargetDistance.Id].CostTime / templateDict[m_OptimalTargetDistance.Id].Config.duration) * m_OptimalTargetDistance.Value;
            target.m_OptimalTargetDistance = (System.Single)m_OptimalTargetDistance.Value;
        }
    }
}
