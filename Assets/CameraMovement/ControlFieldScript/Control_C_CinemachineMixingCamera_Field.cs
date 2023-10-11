using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineMixingCamera_Field :ICameraMovementControlField<Cinemachine.CinemachineMixingCamera>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineMixingCamera);

       [UnityEngine.TooltipAttribute("The weight of the first tracked camera")]
            public DataMixer <System.Single> m_Weight0;
       [UnityEngine.TooltipAttribute("The weight of the second tracked camera")]
            public DataMixer <System.Single> m_Weight1;
       [UnityEngine.TooltipAttribute("The weight of the third tracked camera")]
            public DataMixer <System.Single> m_Weight2;
       [UnityEngine.TooltipAttribute("The weight of the fourth tracked camera")]
            public DataMixer <System.Single> m_Weight3;
       [UnityEngine.TooltipAttribute("The weight of the fifth tracked camera")]
            public DataMixer <System.Single> m_Weight4;
       [UnityEngine.TooltipAttribute("The weight of the sixth tracked camera")]
            public DataMixer <System.Single> m_Weight5;
       [UnityEngine.TooltipAttribute("The weight of the seventh tracked camera")]
            public DataMixer <System.Single> m_Weight6;
       [UnityEngine.TooltipAttribute("The weight of the eighth tracked camera")]
            public DataMixer <System.Single> m_Weight7;
       [UnityEngine.HideInInspector]
        public Control_S_String_Field[] m_ExcludedPropertiesInInspector;
       [UnityEngine.HideInInspector]
        public Control_C_CC_Stage_Field[] m_LockStageInInspector;
       [UnityEngine.TooltipAttribute("The priority will determine which camera becomes active based on the state of other cameras and this camera.  Higher numbers have greater priority.")]
            public DataMixer <System.Int32> m_Priority;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> FollowTargetAttachment;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> LookAtTargetAttachment;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineMixingCamera_Config source = (CameraMovement.Control_C_CinemachineMixingCamera_Config)sourceConfig;
            if(source.m_Weight0.IsUse) m_Weight0.Add(new MixItem<System.Single>(id, priority, source.m_Weight0.CalculatorExpression, source.m_Weight0.Value, source.m_Weight0.IsUse));
            if(source.m_Weight1.IsUse) m_Weight1.Add(new MixItem<System.Single>(id, priority, source.m_Weight1.CalculatorExpression, source.m_Weight1.Value, source.m_Weight1.IsUse));
            if(source.m_Weight2.IsUse) m_Weight2.Add(new MixItem<System.Single>(id, priority, source.m_Weight2.CalculatorExpression, source.m_Weight2.Value, source.m_Weight2.IsUse));
            if(source.m_Weight3.IsUse) m_Weight3.Add(new MixItem<System.Single>(id, priority, source.m_Weight3.CalculatorExpression, source.m_Weight3.Value, source.m_Weight3.IsUse));
            if(source.m_Weight4.IsUse) m_Weight4.Add(new MixItem<System.Single>(id, priority, source.m_Weight4.CalculatorExpression, source.m_Weight4.Value, source.m_Weight4.IsUse));
            if(source.m_Weight5.IsUse) m_Weight5.Add(new MixItem<System.Single>(id, priority, source.m_Weight5.CalculatorExpression, source.m_Weight5.Value, source.m_Weight5.IsUse));
            if(source.m_Weight6.IsUse) m_Weight6.Add(new MixItem<System.Single>(id, priority, source.m_Weight6.CalculatorExpression, source.m_Weight6.Value, source.m_Weight6.IsUse));
            if(source.m_Weight7.IsUse) m_Weight7.Add(new MixItem<System.Single>(id, priority, source.m_Weight7.CalculatorExpression, source.m_Weight7.Value, source.m_Weight7.IsUse));
            for(int i = 0;i < (source.m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                if(source.m_ExcludedPropertiesInInspector != null && m_ExcludedPropertiesInInspector == null) m_ExcludedPropertiesInInspector = new Control_S_String_Field[source.m_ExcludedPropertiesInInspector.Length];
                m_ExcludedPropertiesInInspector?[i].AddByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < (source.m_LockStageInInspector?.Length ?? 0);i++)
            {
                if(source.m_LockStageInInspector != null && m_LockStageInInspector == null) m_LockStageInInspector = new Control_C_CC_Stage_Field[source.m_LockStageInInspector.Length];
                m_LockStageInInspector?[i].AddByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Add(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineMixingCamera_Config source = (CameraMovement.Control_C_CinemachineMixingCamera_Config)sourceConfig;
            if(source.m_Weight0.IsUse) m_Weight0.Remove(new MixItem<System.Single>(id, priority, source.m_Weight0.CalculatorExpression, source.m_Weight0.Value, source.m_Weight0.IsUse));
            if(source.m_Weight1.IsUse) m_Weight1.Remove(new MixItem<System.Single>(id, priority, source.m_Weight1.CalculatorExpression, source.m_Weight1.Value, source.m_Weight1.IsUse));
            if(source.m_Weight2.IsUse) m_Weight2.Remove(new MixItem<System.Single>(id, priority, source.m_Weight2.CalculatorExpression, source.m_Weight2.Value, source.m_Weight2.IsUse));
            if(source.m_Weight3.IsUse) m_Weight3.Remove(new MixItem<System.Single>(id, priority, source.m_Weight3.CalculatorExpression, source.m_Weight3.Value, source.m_Weight3.IsUse));
            if(source.m_Weight4.IsUse) m_Weight4.Remove(new MixItem<System.Single>(id, priority, source.m_Weight4.CalculatorExpression, source.m_Weight4.Value, source.m_Weight4.IsUse));
            if(source.m_Weight5.IsUse) m_Weight5.Remove(new MixItem<System.Single>(id, priority, source.m_Weight5.CalculatorExpression, source.m_Weight5.Value, source.m_Weight5.IsUse));
            if(source.m_Weight6.IsUse) m_Weight6.Remove(new MixItem<System.Single>(id, priority, source.m_Weight6.CalculatorExpression, source.m_Weight6.Value, source.m_Weight6.IsUse));
            if(source.m_Weight7.IsUse) m_Weight7.Remove(new MixItem<System.Single>(id, priority, source.m_Weight7.CalculatorExpression, source.m_Weight7.Value, source.m_Weight7.IsUse));
            for(int i = 0;i < (source.m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                m_ExcludedPropertiesInInspector?[i].RemoveByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < (source.m_LockStageInInspector?.Length ?? 0);i++)
            {
                m_LockStageInInspector?[i].RemoveByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Remove(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
        }
        public void RemoveAll()
        {
            m_Weight0.RemoveAll();
            m_Weight1.RemoveAll();
            m_Weight2.RemoveAll();
            m_Weight3.RemoveAll();
            m_Weight4.RemoveAll();
            m_Weight5.RemoveAll();
            m_Weight6.RemoveAll();
            m_Weight7.RemoveAll();
            for(int i = 0;i < (m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                m_ExcludedPropertiesInInspector?[i].RemoveAll();            }

            for(int i = 0;i < (m_LockStageInInspector?.Length ?? 0);i++)
            {
                m_LockStageInInspector?[i].RemoveAll();            }

            m_Priority.RemoveAll();
            FollowTargetAttachment.RemoveAll();
            LookAtTargetAttachment.RemoveAll();
            m_StandbyUpdate.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineMixingCamera target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_Weight0.IsUse && templateDict.ContainsKey(m_Weight0.Id))
                target.m_Weight0 = Mathf.Approximately(0, templateDict[m_Weight0.Id].Config.duration) ? (m_Weight0.IsExpression ? m_Weight0.Value : m_Weight0.PrimitiveValue) : templateDict[m_Weight0.Id].Config.alertCurve.Evaluate(templateDict[m_Weight0.Id].CostTime / templateDict[m_Weight0.Id].Config.duration) * (m_Weight0.IsExpression ? m_Weight0.Value : m_Weight0.PrimitiveValue);
            if (m_Weight1.IsUse && templateDict.ContainsKey(m_Weight1.Id))
                target.m_Weight1 = Mathf.Approximately(0, templateDict[m_Weight1.Id].Config.duration) ? (m_Weight1.IsExpression ? m_Weight1.Value : m_Weight1.PrimitiveValue) : templateDict[m_Weight1.Id].Config.alertCurve.Evaluate(templateDict[m_Weight1.Id].CostTime / templateDict[m_Weight1.Id].Config.duration) * (m_Weight1.IsExpression ? m_Weight1.Value : m_Weight1.PrimitiveValue);
            if (m_Weight2.IsUse && templateDict.ContainsKey(m_Weight2.Id))
                target.m_Weight2 = Mathf.Approximately(0, templateDict[m_Weight2.Id].Config.duration) ? (m_Weight2.IsExpression ? m_Weight2.Value : m_Weight2.PrimitiveValue) : templateDict[m_Weight2.Id].Config.alertCurve.Evaluate(templateDict[m_Weight2.Id].CostTime / templateDict[m_Weight2.Id].Config.duration) * (m_Weight2.IsExpression ? m_Weight2.Value : m_Weight2.PrimitiveValue);
            if (m_Weight3.IsUse && templateDict.ContainsKey(m_Weight3.Id))
                target.m_Weight3 = Mathf.Approximately(0, templateDict[m_Weight3.Id].Config.duration) ? (m_Weight3.IsExpression ? m_Weight3.Value : m_Weight3.PrimitiveValue) : templateDict[m_Weight3.Id].Config.alertCurve.Evaluate(templateDict[m_Weight3.Id].CostTime / templateDict[m_Weight3.Id].Config.duration) * (m_Weight3.IsExpression ? m_Weight3.Value : m_Weight3.PrimitiveValue);
            if (m_Weight4.IsUse && templateDict.ContainsKey(m_Weight4.Id))
                target.m_Weight4 = Mathf.Approximately(0, templateDict[m_Weight4.Id].Config.duration) ? (m_Weight4.IsExpression ? m_Weight4.Value : m_Weight4.PrimitiveValue) : templateDict[m_Weight4.Id].Config.alertCurve.Evaluate(templateDict[m_Weight4.Id].CostTime / templateDict[m_Weight4.Id].Config.duration) * (m_Weight4.IsExpression ? m_Weight4.Value : m_Weight4.PrimitiveValue);
            if (m_Weight5.IsUse && templateDict.ContainsKey(m_Weight5.Id))
                target.m_Weight5 = Mathf.Approximately(0, templateDict[m_Weight5.Id].Config.duration) ? (m_Weight5.IsExpression ? m_Weight5.Value : m_Weight5.PrimitiveValue) : templateDict[m_Weight5.Id].Config.alertCurve.Evaluate(templateDict[m_Weight5.Id].CostTime / templateDict[m_Weight5.Id].Config.duration) * (m_Weight5.IsExpression ? m_Weight5.Value : m_Weight5.PrimitiveValue);
            if (m_Weight6.IsUse && templateDict.ContainsKey(m_Weight6.Id))
                target.m_Weight6 = Mathf.Approximately(0, templateDict[m_Weight6.Id].Config.duration) ? (m_Weight6.IsExpression ? m_Weight6.Value : m_Weight6.PrimitiveValue) : templateDict[m_Weight6.Id].Config.alertCurve.Evaluate(templateDict[m_Weight6.Id].CostTime / templateDict[m_Weight6.Id].Config.duration) * (m_Weight6.IsExpression ? m_Weight6.Value : m_Weight6.PrimitiveValue);
            if (m_Weight7.IsUse && templateDict.ContainsKey(m_Weight7.Id))
                target.m_Weight7 = Mathf.Approximately(0, templateDict[m_Weight7.Id].Config.duration) ? (m_Weight7.IsExpression ? m_Weight7.Value : m_Weight7.PrimitiveValue) : templateDict[m_Weight7.Id].Config.alertCurve.Evaluate(templateDict[m_Weight7.Id].CostTime / templateDict[m_Weight7.Id].Config.duration) * (m_Weight7.IsExpression ? m_Weight7.Value : m_Weight7.PrimitiveValue);
            // 处理数组字段 m_ExcludedPropertiesInInspector
            for (int i = 0; i < (target.m_ExcludedPropertiesInInspector?.Length ?? 0); i++)
            {
                // 生成递归代码
                m_ExcludedPropertiesInInspector?[i].ControlCinemachine(ref target.m_ExcludedPropertiesInInspector[i], templateDict);
            }
            // 处理数组字段 m_LockStageInInspector
            for (int i = 0; i < (target.m_LockStageInInspector?.Length ?? 0); i++)
            {
                // 生成递归代码
                m_LockStageInInspector?[i].ControlCinemachine(ref target.m_LockStageInInspector[i], templateDict);
            }
            if (m_Priority.IsUse) target.m_Priority = m_Priority.IsExpression ? (System.Int32)m_Priority.Value :m_Priority.PrimitiveValue;
            if (FollowTargetAttachment.IsUse && templateDict.ContainsKey(FollowTargetAttachment.Id))
                target.FollowTargetAttachment = Mathf.Approximately(0, templateDict[FollowTargetAttachment.Id].Config.duration) ? (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue) : templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
            if (LookAtTargetAttachment.IsUse && templateDict.ContainsKey(LookAtTargetAttachment.Id))
                target.LookAtTargetAttachment = Mathf.Approximately(0, templateDict[LookAtTargetAttachment.Id].Config.duration) ? (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue) : templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
            if (m_StandbyUpdate.IsUse) target.m_StandbyUpdate = m_StandbyUpdate.IsExpression ? (Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode)m_StandbyUpdate.Value :m_StandbyUpdate.PrimitiveValue;
        }
    }
}
