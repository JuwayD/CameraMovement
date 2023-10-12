using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CTD_AutoDolly_Field :ICameraMovementControlField<Cinemachine.CinemachineTrackedDolly.AutoDolly>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineTrackedDolly.AutoDolly);

       [UnityEngine.TooltipAttribute("If checked, will enable automatic dolly, which chooses a path position that is as close as possible to the Follow target.  Note: this can have significant performance impact")]
            public DataMixer <System.Boolean> m_Enabled;
       [UnityEngine.TooltipAttribute("Offset, in current position units, from the closest point on the path to the follow target")]
            public DataMixer <System.Single> m_PositionOffset;
        public float m_PositionOffsetAlertInit;
       [UnityEngine.TooltipAttribute("Search up to this many waypoints on either side of the current position.  Use 0 for Entire path.")]
            public DataMixer <System.Int32> m_SearchRadius;
       [UnityEngine.TooltipAttribute("We search between waypoints by dividing the segment into this many straight pieces.  he higher the number, the more accurate the result, but performance is proportionally slower for higher numbers")]
            public DataMixer <System.Int32> m_SearchResolution;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineTrackedDolly.AutoDolly target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CTD_AutoDolly_Config source = (CameraMovement.Control_C_CTD_AutoDolly_Config)sourceConfig;
                if(source.m_Enabled.IsUse)
                {
                    m_Enabled.Add(new MixItem<System.Boolean>(id, priority, source.m_Enabled.CalculatorExpression, source.m_Enabled.Value, source.m_Enabled.IsUse));
                }
                if(source.m_PositionOffset.IsUse)
                {
                    m_PositionOffsetAlertInit = target.m_PositionOffset;
                    m_PositionOffset.Add(new MixItem<System.Single>(id, priority, source.m_PositionOffset.CalculatorExpression, source.m_PositionOffset.Value, source.m_PositionOffset.IsUse));
                }
                if(source.m_SearchRadius.IsUse)
                {
                    m_SearchRadius.Add(new MixItem<System.Int32>(id, priority, source.m_SearchRadius.CalculatorExpression, source.m_SearchRadius.Value, source.m_SearchRadius.IsUse));
                }
                if(source.m_SearchResolution.IsUse)
                {
                    m_SearchResolution.Add(new MixItem<System.Int32>(id, priority, source.m_SearchResolution.CalculatorExpression, source.m_SearchResolution.Value, source.m_SearchResolution.IsUse));
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineTrackedDolly.AutoDolly target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CTD_AutoDolly_Config source = (CameraMovement.Control_C_CTD_AutoDolly_Config)sourceConfig;
                if(source.m_Enabled.IsUse)
                {
                    m_Enabled.Remove(new MixItem<System.Boolean>(id, priority, source.m_Enabled.CalculatorExpression, source.m_Enabled.Value, source.m_Enabled.IsUse));
                }
                if(source.m_PositionOffset.IsUse)
                {
                    m_PositionOffsetAlertInit = target.m_PositionOffset;
                    m_PositionOffset.Remove(new MixItem<System.Single>(id, priority, source.m_PositionOffset.CalculatorExpression, source.m_PositionOffset.Value, source.m_PositionOffset.IsUse));
                }
                if(source.m_SearchRadius.IsUse)
                {
                    m_SearchRadius.Remove(new MixItem<System.Int32>(id, priority, source.m_SearchRadius.CalculatorExpression, source.m_SearchRadius.Value, source.m_SearchRadius.IsUse));
                }
                if(source.m_SearchResolution.IsUse)
                {
                    m_SearchResolution.Remove(new MixItem<System.Int32>(id, priority, source.m_SearchResolution.CalculatorExpression, source.m_SearchResolution.Value, source.m_SearchResolution.IsUse));
                }
        }
        public void RemoveAll()
        {
            m_Enabled.RemoveAll();
            m_PositionOffset.RemoveAll();
            m_SearchRadius.RemoveAll();
            m_SearchResolution.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineTrackedDolly.AutoDolly target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Enabled.IsUse) target.m_Enabled = m_Enabled.IsExpression ? !Mathf.Approximately(m_Enabled.Value, 0) : m_Enabled.PrimitiveValue;
            if (m_PositionOffset.IsUse && templateDict.ContainsKey(m_PositionOffset.Id))
            {
                var targetValue = (m_PositionOffset.IsExpression ? m_PositionOffset.Value : m_PositionOffset.PrimitiveValue);
                target.m_PositionOffset = Mathf.Approximately(0, templateDict[m_PositionOffset.Id].Config.duration) ? targetValue : m_PositionOffsetAlertInit + templateDict[m_PositionOffset.Id].Config.alertCurve.Evaluate(templateDict[m_PositionOffset.Id].CostTime / templateDict[m_PositionOffset.Id].Config.duration) * (targetValue - m_PositionOffsetAlertInit);
            }
            if (m_SearchRadius.IsUse) target.m_SearchRadius = m_SearchRadius.IsExpression ? (System.Int32)m_SearchRadius.Value :m_SearchRadius.PrimitiveValue;
            if (m_SearchResolution.IsUse) target.m_SearchResolution = m_SearchResolution.IsExpression ? (System.Int32)m_SearchResolution.Value :m_SearchResolution.PrimitiveValue;
        }
    }
}
