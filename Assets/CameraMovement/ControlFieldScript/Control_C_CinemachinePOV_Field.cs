using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachinePOV_Field :ICameraMovementControlField
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
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachinePOV_Config source = (CameraMovement.Control_C_CinemachinePOV_Config)sourceConfig;
            if(source.m_RecenterTarget.IsUse) m_RecenterTarget.Add(new MixItem<Cinemachine.CinemachinePOV.RecenterTargetMode>(id, priority, source.m_RecenterTarget.CalculatorExpression, source.m_RecenterTarget.Value));
            m_VerticalAxis.AddByConfig(source.m_VerticalAxis, id, priority);
            m_VerticalRecentering.AddByConfig(source.m_VerticalRecentering, id, priority);
            m_HorizontalAxis.AddByConfig(source.m_HorizontalAxis, id, priority);
            m_HorizontalRecentering.AddByConfig(source.m_HorizontalRecentering, id, priority);
            if(source.m_ApplyBeforeBody.IsUse) m_ApplyBeforeBody.Add(new MixItem<System.Boolean>(id, priority, source.m_ApplyBeforeBody.CalculatorExpression, source.m_ApplyBeforeBody.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachinePOV_Config source = (CameraMovement.Control_C_CinemachinePOV_Config)sourceConfig;
            if(source.m_RecenterTarget.IsUse) m_RecenterTarget.Remove(new MixItem<Cinemachine.CinemachinePOV.RecenterTargetMode>(id, priority, source.m_RecenterTarget.CalculatorExpression, source.m_RecenterTarget.Value));
            m_VerticalAxis.RemoveByConfig(source.m_VerticalAxis, id, priority);
            m_VerticalRecentering.RemoveByConfig(source.m_VerticalRecentering, id, priority);
            m_HorizontalAxis.RemoveByConfig(source.m_HorizontalAxis, id, priority);
            m_HorizontalRecentering.RemoveByConfig(source.m_HorizontalRecentering, id, priority);
            if(source.m_ApplyBeforeBody.IsUse) m_ApplyBeforeBody.Remove(new MixItem<System.Boolean>(id, priority, source.m_ApplyBeforeBody.CalculatorExpression, source.m_ApplyBeforeBody.Value));
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
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachinePOV)targetObj;
            target.m_RecenterTarget = (Cinemachine.CinemachinePOV.RecenterTargetMode)m_RecenterTarget.Value;
            // 处理字段 m_VerticalAxis
            // 生成递归代码
            m_VerticalAxis.ControlCinemachine(target.m_VerticalAxis, templateDict);
            // 处理字段 m_VerticalRecentering
            // 生成递归代码
            m_VerticalRecentering.ControlCinemachine(target.m_VerticalRecentering, templateDict);
            // 处理字段 m_HorizontalAxis
            // 生成递归代码
            m_HorizontalAxis.ControlCinemachine(target.m_HorizontalAxis, templateDict);
            // 处理字段 m_HorizontalRecentering
            // 生成递归代码
            m_HorizontalRecentering.ControlCinemachine(target.m_HorizontalRecentering, templateDict);
            target.m_ApplyBeforeBody = !Mathf.Approximately(m_ApplyBeforeBody.Value, 0);
        }
    }
}
