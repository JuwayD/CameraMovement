using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachinePOV_Field :ICameraMovementControlField<Cinemachine.CinemachinePOV>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachinePOV);

        public DataMixer <Cinemachine.CinemachinePOV.RecenterTargetMode> m_RecenterTarget;
       [UnityEngine.TooltipAttribute("The Vertical axis.  Value is -90..90. Controls the vertical orientation")]
        public Control_C_AxisState_Field m_VerticalAxis;
       [UnityEngine.TooltipAttribute("Controls how automatic recentering of the Vertical axis is accomplished")]
        public Control_C_AS_Recentering_Field m_VerticalRecentering;
       [UnityEngine.TooltipAttribute("The Horizontal axis.  Value is -180..180.  Controls the horizontal orientation")]
        public Control_C_AxisState_Field m_HorizontalAxis;
       [UnityEngine.TooltipAttribute("Controls how automatic recentering of the Horizontal axis is accomplished")]
        public Control_C_AS_Recentering_Field m_HorizontalRecentering;
       [UnityEngine.HideInInspector]
           [UnityEngine.TooltipAttribute("Obsolete - no longer used")]
            public DataMixer <System.Boolean> m_ApplyBeforeBody;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachinePOV target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachinePOV_Config source = (CameraMovement.Control_C_CinemachinePOV_Config)sourceConfig;
            if(source.m_RecenterTarget.IsUse)
            {
                m_RecenterTarget.Add(new MixItem<Cinemachine.CinemachinePOV.RecenterTargetMode>(id, priority, source.m_RecenterTarget.CalculatorExpression, source.m_RecenterTarget.Value, source.m_RecenterTarget.IsUse));
            }
            if(source.m_VerticalAxis != null && m_VerticalAxis == null) m_VerticalAxis = new Control_C_AxisState_Field();
            m_VerticalAxis?.AddByConfig(source.m_VerticalAxis, id, priority, ref target.m_VerticalAxis, templateDict);
            if(source.m_VerticalRecentering != null && m_VerticalRecentering == null) m_VerticalRecentering = new Control_C_AS_Recentering_Field();
            m_VerticalRecentering?.AddByConfig(source.m_VerticalRecentering, id, priority, ref target.m_VerticalRecentering, templateDict);
            if(source.m_HorizontalAxis != null && m_HorizontalAxis == null) m_HorizontalAxis = new Control_C_AxisState_Field();
            m_HorizontalAxis?.AddByConfig(source.m_HorizontalAxis, id, priority, ref target.m_HorizontalAxis, templateDict);
            if(source.m_HorizontalRecentering != null && m_HorizontalRecentering == null) m_HorizontalRecentering = new Control_C_AS_Recentering_Field();
            m_HorizontalRecentering?.AddByConfig(source.m_HorizontalRecentering, id, priority, ref target.m_HorizontalRecentering, templateDict);
            if(source.m_ApplyBeforeBody.IsUse)
            {
                m_ApplyBeforeBody.Add(new MixItem<System.Boolean>(id, priority, source.m_ApplyBeforeBody.CalculatorExpression, source.m_ApplyBeforeBody.Value, source.m_ApplyBeforeBody.IsUse));
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachinePOV target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachinePOV_Config source = (CameraMovement.Control_C_CinemachinePOV_Config)sourceConfig;
            if(source.m_RecenterTarget.IsUse)
            {
                m_RecenterTarget.Remove(new MixItem<Cinemachine.CinemachinePOV.RecenterTargetMode>(id, priority, source.m_RecenterTarget.CalculatorExpression, source.m_RecenterTarget.Value, source.m_RecenterTarget.IsUse));
            }
            m_VerticalAxis?.RemoveByConfig(source.m_VerticalAxis, id, priority, ref target.m_VerticalAxis, templateDict);
            m_VerticalRecentering?.RemoveByConfig(source.m_VerticalRecentering, id, priority, ref target.m_VerticalRecentering, templateDict);
            m_HorizontalAxis?.RemoveByConfig(source.m_HorizontalAxis, id, priority, ref target.m_HorizontalAxis, templateDict);
            m_HorizontalRecentering?.RemoveByConfig(source.m_HorizontalRecentering, id, priority, ref target.m_HorizontalRecentering, templateDict);
            if(source.m_ApplyBeforeBody.IsUse)
            {
                m_ApplyBeforeBody.Remove(new MixItem<System.Boolean>(id, priority, source.m_ApplyBeforeBody.CalculatorExpression, source.m_ApplyBeforeBody.Value, source.m_ApplyBeforeBody.IsUse));
            }
        }
        public void RemoveAll()
        {
            m_RecenterTarget.RemoveAll();
            m_VerticalAxis.RemoveAll();
            m_VerticalRecentering.RemoveAll();
            m_HorizontalAxis.RemoveAll();
            m_HorizontalRecentering.RemoveAll();
            m_ApplyBeforeBody.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachinePOV target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_RecenterTarget.IsUse) target.m_RecenterTarget = m_RecenterTarget.IsExpression ? (Cinemachine.CinemachinePOV.RecenterTargetMode)m_RecenterTarget.Value :m_RecenterTarget.PrimitiveValue;
            // 处理字段 m_VerticalAxis
            // 生成递归代码
            m_VerticalAxis?.ControlCinemachine(ref target.m_VerticalAxis, templateDict);
            // 处理字段 m_VerticalRecentering
            // 生成递归代码
            m_VerticalRecentering?.ControlCinemachine(ref target.m_VerticalRecentering, templateDict);
            // 处理字段 m_HorizontalAxis
            // 生成递归代码
            m_HorizontalAxis?.ControlCinemachine(ref target.m_HorizontalAxis, templateDict);
            // 处理字段 m_HorizontalRecentering
            // 生成递归代码
            m_HorizontalRecentering?.ControlCinemachine(ref target.m_HorizontalRecentering, templateDict);
            if (m_ApplyBeforeBody.IsUse) target.m_ApplyBeforeBody = m_ApplyBeforeBody.IsExpression ? !Mathf.Approximately(m_ApplyBeforeBody.Value, 0) : m_ApplyBeforeBody.PrimitiveValue;
        }
    }
}
