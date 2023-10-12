using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineBlendListCamera_Field :ICameraMovementControlField<Cinemachine.CinemachineBlendListCamera>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlendListCamera);

       [UnityEngine.TooltipAttribute("When enabled, the current child camera and blend will be indicated in the game window, for debugging")]
            public DataMixer <System.Boolean> m_ShowDebugText;
       [UnityEngine.TooltipAttribute("When enabled, the child vcams will cycle indefinitely instead of just stopping at the last one")]
            public DataMixer <System.Boolean> m_Loop;
       [UnityEngine.TooltipAttribute("The set of instructions for enabling child cameras.")]
        public Control_C_CBLC_Instruction_Field[] m_Instructions;
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
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBlendListCamera target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlendListCamera_Config source = (CameraMovement.Control_C_CinemachineBlendListCamera_Config)sourceConfig;
                if(source.m_ShowDebugText.IsUse)
                {
                    m_ShowDebugText.Add(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value, source.m_ShowDebugText.IsUse));
                }
                if(source.m_Loop.IsUse)
                {
                    m_Loop.Add(new MixItem<System.Boolean>(id, priority, source.m_Loop.CalculatorExpression, source.m_Loop.Value, source.m_Loop.IsUse));
                }
            for(int i = 0;i < (source.m_Instructions?.Length ?? 0);i++)
            {
                if(source.m_Instructions != null && m_Instructions == null) m_Instructions = new Control_C_CBLC_Instruction_Field[source.m_Instructions.Length];
                m_Instructions?[i].AddByConfig(source.m_Instructions[i], id, priority, ref target.m_Instructions[i]);            }

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
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBlendListCamera target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlendListCamera_Config source = (CameraMovement.Control_C_CinemachineBlendListCamera_Config)sourceConfig;
                if(source.m_ShowDebugText.IsUse)
                {
                    m_ShowDebugText.Remove(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value, source.m_ShowDebugText.IsUse));
                }
                if(source.m_Loop.IsUse)
                {
                    m_Loop.Remove(new MixItem<System.Boolean>(id, priority, source.m_Loop.CalculatorExpression, source.m_Loop.Value, source.m_Loop.IsUse));
                }
            for(int i = 0;i < (source.m_Instructions?.Length ?? 0);i++)
            {
                m_Instructions?[i].RemoveByConfig(source.m_Instructions[i], id, priority, ref target.m_Instructions[i]);            }

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
            m_ShowDebugText.RemoveAll();
            m_Loop.RemoveAll();
            for(int i = 0;i < (m_Instructions?.Length ?? 0);i++)
            {
                m_Instructions?[i].RemoveAll();            }

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
        public void ControlCinemachine(ref Cinemachine.CinemachineBlendListCamera target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_ShowDebugText.IsUse) target.m_ShowDebugText = m_ShowDebugText.IsExpression ? !Mathf.Approximately(m_ShowDebugText.Value, 0) : m_ShowDebugText.PrimitiveValue;
            if (m_Loop.IsUse) target.m_Loop = m_Loop.IsExpression ? !Mathf.Approximately(m_Loop.Value, 0) : m_Loop.PrimitiveValue;
            // 处理数组字段 m_Instructions
            for (int i = 0; i < (target.m_Instructions?.Length ?? 0); i++)
            {
                // 生成递归代码
                m_Instructions?[i].ControlCinemachine(ref target.m_Instructions[i], templateDict);
            }
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
