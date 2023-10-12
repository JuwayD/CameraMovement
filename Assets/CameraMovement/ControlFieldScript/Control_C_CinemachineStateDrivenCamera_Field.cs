using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineStateDrivenCamera_Field :ICameraMovementControlField<Cinemachine.CinemachineStateDrivenCamera>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineStateDrivenCamera);

       [UnityEngine.TooltipAttribute("Which layer in the target state machine to observe")]
            public DataMixer <System.Int32> m_LayerIndex;
       [UnityEngine.TooltipAttribute("When enabled, the current child camera and blend will be indicated in the game window, for debugging")]
            public DataMixer <System.Boolean> m_ShowDebugText;
       [UnityEngine.TooltipAttribute("The set of instructions associating virtual cameras with states.  These instructions are used to choose the live child at any given moment")]
        public Control_C_CSDC_Instruction_Field[] m_Instructions;
       [UnityEngine.TooltipAttribute("The blend which is used if you don't explicitly define a blend between two Virtual Camera children")]
        public Control_C_CinemachineBlendDefinition_Field m_DefaultBlend;
       [UnityEngine.TooltipAttribute("This is the asset which contains custom settings for specific child blends")]
        public Control_C_CinemachineBlenderSettings_Field m_CustomBlends;
       [UnityEngine.HideInInspector]
        public Control_S_String_Field[] m_ExcludedPropertiesInInspector;
       [UnityEngine.HideInInspector]
        public Control_C_CC_Stage_Field[] m_LockStageInInspector;
       [UnityEngine.TooltipAttribute("The priority will determine which camera becomes active based on the state of other cameras and this camera.  Higher numbers have greater priority.")]
            public DataMixer <System.Int32> m_Priority;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> FollowTargetAttachment;
        public float FollowTargetAttachmentAlertInit;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> LookAtTargetAttachment;
        public float LookAtTargetAttachmentAlertInit;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineStateDrivenCamera target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineStateDrivenCamera_Config source = (CameraMovement.Control_C_CinemachineStateDrivenCamera_Config)sourceConfig;
                if(source.m_LayerIndex.IsUse)
                {
                    m_LayerIndex.Add(new MixItem<System.Int32>(id, priority, source.m_LayerIndex.CalculatorExpression, source.m_LayerIndex.Value, source.m_LayerIndex.IsUse));
                }
                if(source.m_ShowDebugText.IsUse)
                {
                    m_ShowDebugText.Add(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value, source.m_ShowDebugText.IsUse));
                }
            for(int i = 0;i < (source.m_Instructions?.Length ?? 0);i++)
            {
                if(source.m_Instructions != null && m_Instructions == null) m_Instructions = new Control_C_CSDC_Instruction_Field[source.m_Instructions.Length];
                m_Instructions?[i].AddByConfig(source.m_Instructions[i], id, priority, ref target.m_Instructions[i]);            }

                if(source.m_DefaultBlend != null && m_DefaultBlend == null) m_DefaultBlend = new Control_C_CinemachineBlendDefinition_Field();
            m_DefaultBlend?.AddByConfig(source.m_DefaultBlend, id, priority, ref target.m_DefaultBlend);
                if(source.m_CustomBlends != null && m_CustomBlends == null) m_CustomBlends = new Control_C_CinemachineBlenderSettings_Field();
            m_CustomBlends?.AddByConfig(source.m_CustomBlends, id, priority, ref target.m_CustomBlends);
            for(int i = 0;i < (source.m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                if(source.m_ExcludedPropertiesInInspector != null && m_ExcludedPropertiesInInspector == null) m_ExcludedPropertiesInInspector = new Control_S_String_Field[source.m_ExcludedPropertiesInInspector.Length];
                m_ExcludedPropertiesInInspector?[i].AddByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority, ref target.m_ExcludedPropertiesInInspector[i]);            }

            for(int i = 0;i < (source.m_LockStageInInspector?.Length ?? 0);i++)
            {
                if(source.m_LockStageInInspector != null && m_LockStageInInspector == null) m_LockStageInInspector = new Control_C_CC_Stage_Field[source.m_LockStageInInspector.Length];
                m_LockStageInInspector?[i].AddByConfig(source.m_LockStageInInspector[i], id, priority, ref target.m_LockStageInInspector[i]);            }

                if(source.m_Priority.IsUse)
                {
                    m_Priority.Add(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
                }
                if(source.FollowTargetAttachment.IsUse)
                {
                    FollowTargetAttachmentAlertInit = target.FollowTargetAttachment;
                    FollowTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
                }
                if(source.LookAtTargetAttachment.IsUse)
                {
                    LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment;
                    LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
                }
                if(source.m_StandbyUpdate.IsUse)
                {
                    m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
                }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineStateDrivenCamera target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineStateDrivenCamera_Config source = (CameraMovement.Control_C_CinemachineStateDrivenCamera_Config)sourceConfig;
                if(source.m_LayerIndex.IsUse)
                {
                    m_LayerIndex.Remove(new MixItem<System.Int32>(id, priority, source.m_LayerIndex.CalculatorExpression, source.m_LayerIndex.Value, source.m_LayerIndex.IsUse));
                }
                if(source.m_ShowDebugText.IsUse)
                {
                    m_ShowDebugText.Remove(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value, source.m_ShowDebugText.IsUse));
                }
            for(int i = 0;i < (source.m_Instructions?.Length ?? 0);i++)
            {
                m_Instructions?[i].RemoveByConfig(source.m_Instructions[i], id, priority, ref target.m_Instructions[i]);            }

            m_DefaultBlend?.RemoveByConfig(source.m_DefaultBlend, id, priority, ref target.m_DefaultBlend);
            m_CustomBlends?.RemoveByConfig(source.m_CustomBlends, id, priority, ref target.m_CustomBlends);
            for(int i = 0;i < (source.m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                m_ExcludedPropertiesInInspector?[i].RemoveByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority, ref target.m_ExcludedPropertiesInInspector[i]);            }

            for(int i = 0;i < (source.m_LockStageInInspector?.Length ?? 0);i++)
            {
                m_LockStageInInspector?[i].RemoveByConfig(source.m_LockStageInInspector[i], id, priority, ref target.m_LockStageInInspector[i]);            }

                if(source.m_Priority.IsUse)
                {
                    m_Priority.Remove(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
                }
                if(source.FollowTargetAttachment.IsUse)
                {
                    FollowTargetAttachmentAlertInit = target.FollowTargetAttachment;
                    FollowTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
                }
                if(source.LookAtTargetAttachment.IsUse)
                {
                    LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment;
                    LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
                }
                if(source.m_StandbyUpdate.IsUse)
                {
                    m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
                }
        }
        public void RemoveAll()
        {
            m_LayerIndex.RemoveAll();
            m_ShowDebugText.RemoveAll();
            for(int i = 0;i < (m_Instructions?.Length ?? 0);i++)
            {
                m_Instructions?[i].RemoveAll();            }

            m_DefaultBlend?.RemoveAll();
            m_CustomBlends?.RemoveAll();
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
        public void ControlCinemachine(ref Cinemachine.CinemachineStateDrivenCamera target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_LayerIndex.IsUse) target.m_LayerIndex = m_LayerIndex.IsExpression ? (System.Int32)m_LayerIndex.Value :m_LayerIndex.PrimitiveValue;
            if (m_ShowDebugText.IsUse) target.m_ShowDebugText = m_ShowDebugText.IsExpression ? !Mathf.Approximately(m_ShowDebugText.Value, 0) : m_ShowDebugText.PrimitiveValue;
            // 处理数组字段 m_Instructions
            for (int i = 0; i < (target.m_Instructions?.Length ?? 0); i++)
            {
                // 生成递归代码
                m_Instructions?[i].ControlCinemachine(ref target.m_Instructions[i], templateDict);
            }
            // 处理字段 m_DefaultBlend
            // 生成递归代码
            m_DefaultBlend?.ControlCinemachine(ref target.m_DefaultBlend, templateDict);
            // 处理字段 m_CustomBlends
            // 生成递归代码
            m_CustomBlends?.ControlCinemachine(ref target.m_CustomBlends, templateDict);
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
            {
                var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
                target.FollowTargetAttachment = Mathf.Approximately(0, templateDict[FollowTargetAttachment.Id].Config.duration) ? targetValue : FollowTargetAttachmentAlertInit + templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (targetValue - FollowTargetAttachmentAlertInit);
            }
            if (LookAtTargetAttachment.IsUse && templateDict.ContainsKey(LookAtTargetAttachment.Id))
            {
                var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
                target.LookAtTargetAttachment = Mathf.Approximately(0, templateDict[LookAtTargetAttachment.Id].Config.duration) ? targetValue : LookAtTargetAttachmentAlertInit + templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (targetValue - LookAtTargetAttachmentAlertInit);
            }
            if (m_StandbyUpdate.IsUse) target.m_StandbyUpdate = m_StandbyUpdate.IsExpression ? (Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode)m_StandbyUpdate.Value :m_StandbyUpdate.PrimitiveValue;
        }
    }
}
