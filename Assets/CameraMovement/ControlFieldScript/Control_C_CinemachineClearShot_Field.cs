using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineClearShot_Field :ICameraMovementControlField<Cinemachine.CinemachineClearShot>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineClearShot);

       [UnityEngine.TooltipAttribute("When enabled, the current child camera and blend will be indicated in the game window, for debugging")]
            public DataMixer <System.Boolean> m_ShowDebugText;
       [UnityEngine.TooltipAttribute("Wait this many seconds before activating a new child camera")]
            public DataMixer <System.Single> m_ActivateAfter;
        public float m_ActivateAfterAlertInit;
        public float m_ActivateAfterDiff;
       [UnityEngine.TooltipAttribute("An active camera must be active for at least this many seconds")]
            public DataMixer <System.Single> m_MinDuration;
        public float m_MinDurationAlertInit;
        public float m_MinDurationDiff;
       [UnityEngine.TooltipAttribute("If checked, camera choice will be randomized if multiple cameras are equally desirable.  Otherwise, child list order and child camera priority will be used.")]
            public DataMixer <System.Boolean> m_RandomizeChoice;
       [UnityEngine.TooltipAttribute("The blend which is used if you don't explicitly define a blend between two Virtual Cameras")]
        public Control_C_CinemachineBlendDefinition_Field m_DefaultBlend;
       [UnityEngine.HideInInspector]
        public Control_C_CinemachineBlenderSettings_Field m_CustomBlends;
       [UnityEngine.HideInInspector]
            public DataMixer<System.String>[] m_ExcludedPropertiesInInspector;
       [UnityEngine.HideInInspector]
            public DataMixer<Cinemachine.CinemachineCore.Stage>[] m_LockStageInInspector;
       [UnityEngine.TooltipAttribute("The priority will determine which camera becomes active based on the state of other cameras and this camera.  Higher numbers have greater priority.")]
            public DataMixer <System.Int32> m_Priority;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> FollowTargetAttachment;
        public float FollowTargetAttachmentAlertInit;
        public float FollowTargetAttachmentDiff;
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> LookAtTargetAttachment;
        public float LookAtTargetAttachmentAlertInit;
        public float LookAtTargetAttachmentDiff;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineClearShot target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineClearShot_Config source = (CameraMovement.Control_C_CinemachineClearShot_Config)sourceConfig;
            if(source.m_ShowDebugText.IsUse)
            {
                m_ShowDebugText.Add(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value, source.m_ShowDebugText.IsUse));
            }
            if(source.m_ActivateAfter.IsUse)
            {
                m_ActivateAfter.Add(new MixItem<System.Single>(id, priority, source.m_ActivateAfter.CalculatorExpression, source.m_ActivateAfter.Value, source.m_ActivateAfter.IsUse));
               var targetValue = (m_ActivateAfter.IsExpression ? m_ActivateAfter.Value : m_ActivateAfter.PrimitiveValue);
               m_ActivateAfterDiff = targetValue - target.m_ActivateAfter;
               if(templateDict[m_ActivateAfter.Id].Config.alertCurve != null) m_ActivateAfterAlertInit = target.m_ActivateAfter - templateDict[m_ActivateAfter.Id].Config.alertCurve.Evaluate(templateDict[m_ActivateAfter.Id].CostTime / templateDict[m_ActivateAfter.Id].Config.duration) * (m_ActivateAfterDiff);
            }
            if(source.m_MinDuration.IsUse)
            {
                m_MinDuration.Add(new MixItem<System.Single>(id, priority, source.m_MinDuration.CalculatorExpression, source.m_MinDuration.Value, source.m_MinDuration.IsUse));
               var targetValue = (m_MinDuration.IsExpression ? m_MinDuration.Value : m_MinDuration.PrimitiveValue);
               m_MinDurationDiff = targetValue - target.m_MinDuration;
               if(templateDict[m_MinDuration.Id].Config.alertCurve != null) m_MinDurationAlertInit = target.m_MinDuration - templateDict[m_MinDuration.Id].Config.alertCurve.Evaluate(templateDict[m_MinDuration.Id].CostTime / templateDict[m_MinDuration.Id].Config.duration) * (m_MinDurationDiff);
            }
            if(source.m_RandomizeChoice.IsUse)
            {
                m_RandomizeChoice.Add(new MixItem<System.Boolean>(id, priority, source.m_RandomizeChoice.CalculatorExpression, source.m_RandomizeChoice.Value, source.m_RandomizeChoice.IsUse));
            }
            if(source.m_DefaultBlend != null && m_DefaultBlend == null) m_DefaultBlend = new Control_C_CinemachineBlendDefinition_Field();
            m_DefaultBlend?.AddByConfig(source.m_DefaultBlend, id, priority, ref target.m_DefaultBlend, templateDict);
            if(source.m_CustomBlends != null && m_CustomBlends == null) m_CustomBlends = new Control_C_CinemachineBlenderSettings_Field();
            m_CustomBlends?.AddByConfig(source.m_CustomBlends, id, priority, ref target.m_CustomBlends, templateDict);
            for(int i = 0;i < (m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                if(source.m_ExcludedPropertiesInInspector[i].IsUse)
                {
                    m_ExcludedPropertiesInInspector[i].Add(new MixItem<System.String>(id, priority, source.m_ExcludedPropertiesInInspector[i].CalculatorExpression, source.m_ExcludedPropertiesInInspector[i].Value, source.m_ExcludedPropertiesInInspector[i].IsUse));
                }
            }
            for(int i = 0;i < (m_LockStageInInspector?.Length ?? 0);i++)
            {
                if(source.m_LockStageInInspector[i].IsUse)
                {
                    m_LockStageInInspector[i].Add(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_LockStageInInspector[i].CalculatorExpression, source.m_LockStageInInspector[i].Value, source.m_LockStageInInspector[i].IsUse));
                }
            }
            if(source.m_Priority.IsUse)
            {
                m_Priority.Add(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
            }
            if(source.FollowTargetAttachment.IsUse)
            {
                FollowTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
               var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
               FollowTargetAttachmentDiff = targetValue - target.FollowTargetAttachment;
               if(templateDict[FollowTargetAttachment.Id].Config.alertCurve != null) FollowTargetAttachmentAlertInit = target.FollowTargetAttachment - templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (FollowTargetAttachmentDiff);
            }
            if(source.LookAtTargetAttachment.IsUse)
            {
                LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
               var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
               LookAtTargetAttachmentDiff = targetValue - target.LookAtTargetAttachment;
               if(templateDict[LookAtTargetAttachment.Id].Config.alertCurve != null) LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment - templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (LookAtTargetAttachmentDiff);
            }
            if(source.m_StandbyUpdate.IsUse)
            {
                m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineClearShot target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineClearShot_Config source = (CameraMovement.Control_C_CinemachineClearShot_Config)sourceConfig;
            if(source.m_ShowDebugText.IsUse)
            {
                m_ShowDebugText.Remove(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value, source.m_ShowDebugText.IsUse));
            }
            if(source.m_ActivateAfter.IsUse)
            {
                m_ActivateAfter.Remove(new MixItem<System.Single>(id, priority, source.m_ActivateAfter.CalculatorExpression, source.m_ActivateAfter.Value, source.m_ActivateAfter.IsUse));
               var targetValue = (m_ActivateAfter.IsExpression ? m_ActivateAfter.Value : m_ActivateAfter.PrimitiveValue);
               m_ActivateAfterDiff = targetValue - target.m_ActivateAfter;
               if(templateDict[m_ActivateAfter.Id].Config.alertCurve != null) m_ActivateAfterAlertInit = target.m_ActivateAfter - templateDict[m_ActivateAfter.Id].Config.alertCurve.Evaluate(templateDict[m_ActivateAfter.Id].CostTime / templateDict[m_ActivateAfter.Id].Config.duration) * (m_ActivateAfterDiff);
            }
            if(source.m_MinDuration.IsUse)
            {
                m_MinDuration.Remove(new MixItem<System.Single>(id, priority, source.m_MinDuration.CalculatorExpression, source.m_MinDuration.Value, source.m_MinDuration.IsUse));
               var targetValue = (m_MinDuration.IsExpression ? m_MinDuration.Value : m_MinDuration.PrimitiveValue);
               m_MinDurationDiff = targetValue - target.m_MinDuration;
               if(templateDict[m_MinDuration.Id].Config.alertCurve != null) m_MinDurationAlertInit = target.m_MinDuration - templateDict[m_MinDuration.Id].Config.alertCurve.Evaluate(templateDict[m_MinDuration.Id].CostTime / templateDict[m_MinDuration.Id].Config.duration) * (m_MinDurationDiff);
            }
            if(source.m_RandomizeChoice.IsUse)
            {
                m_RandomizeChoice.Remove(new MixItem<System.Boolean>(id, priority, source.m_RandomizeChoice.CalculatorExpression, source.m_RandomizeChoice.Value, source.m_RandomizeChoice.IsUse));
            }
            m_DefaultBlend?.RemoveByConfig(source.m_DefaultBlend, id, priority, ref target.m_DefaultBlend, templateDict);
            m_CustomBlends?.RemoveByConfig(source.m_CustomBlends, id, priority, ref target.m_CustomBlends, templateDict);
            for(int i = 0;i < (m_ExcludedPropertiesInInspector?.Length ?? 0);i++)
            {
                if(source.m_ExcludedPropertiesInInspector[i].IsUse)
                {
                    m_ExcludedPropertiesInInspector[i].Remove(new MixItem<System.String>(id, priority, source.m_ExcludedPropertiesInInspector[i].CalculatorExpression, source.m_ExcludedPropertiesInInspector[i].Value, source.m_ExcludedPropertiesInInspector[i].IsUse));
                }
            }
            for(int i = 0;i < (m_LockStageInInspector?.Length ?? 0);i++)
            {
                if(source.m_LockStageInInspector[i].IsUse)
                {
                    m_LockStageInInspector[i].Remove(new MixItem<Cinemachine.CinemachineCore.Stage>(id, priority, source.m_LockStageInInspector[i].CalculatorExpression, source.m_LockStageInInspector[i].Value, source.m_LockStageInInspector[i].IsUse));
                }
            }
            if(source.m_Priority.IsUse)
            {
                m_Priority.Remove(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value, source.m_Priority.IsUse));
            }
            if(source.FollowTargetAttachment.IsUse)
            {
                FollowTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value, source.FollowTargetAttachment.IsUse));
               var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
               FollowTargetAttachmentDiff = targetValue - target.FollowTargetAttachment;
               if(templateDict[FollowTargetAttachment.Id].Config.alertCurve != null) FollowTargetAttachmentAlertInit = target.FollowTargetAttachment - templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (FollowTargetAttachmentDiff);
            }
            if(source.LookAtTargetAttachment.IsUse)
            {
                LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
               var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
               LookAtTargetAttachmentDiff = targetValue - target.LookAtTargetAttachment;
               if(templateDict[LookAtTargetAttachment.Id].Config.alertCurve != null) LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment - templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (LookAtTargetAttachmentDiff);
            }
            if(source.m_StandbyUpdate.IsUse)
            {
                m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
            }
        }
        public void RemoveAll()
        {
            m_ShowDebugText.RemoveAll();
            m_ActivateAfter.RemoveAll();
            m_MinDuration.RemoveAll();
            m_RandomizeChoice.RemoveAll();
            m_DefaultBlend.RemoveAll();
            m_CustomBlends.RemoveAll();
            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].RemoveAll();
            }
            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].RemoveAll();
            }
            m_Priority.RemoveAll();
            FollowTargetAttachment.RemoveAll();
            LookAtTargetAttachment.RemoveAll();
            m_StandbyUpdate.RemoveAll();
        }
        public void ControlCinemachine(ref Cinemachine.CinemachineClearShot target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if (m_ShowDebugText.IsUse) target.m_ShowDebugText = m_ShowDebugText.IsExpression ? !Mathf.Approximately(m_ShowDebugText.Value, 0) : m_ShowDebugText.PrimitiveValue;
            if (m_ActivateAfter.IsUse && templateDict.ContainsKey(m_ActivateAfter.Id))
            {
                var targetValue = (m_ActivateAfter.IsExpression ? m_ActivateAfter.Value : m_ActivateAfter.PrimitiveValue);
                target.m_ActivateAfter = Mathf.Approximately(0, templateDict[m_ActivateAfter.Id].Config.duration) ? targetValue : m_ActivateAfterAlertInit + templateDict[m_ActivateAfter.Id].Config.alertCurve.Evaluate(templateDict[m_ActivateAfter.Id].CostTime / templateDict[m_ActivateAfter.Id].Config.duration) * m_ActivateAfterDiff;
            }
            if (m_MinDuration.IsUse && templateDict.ContainsKey(m_MinDuration.Id))
            {
                var targetValue = (m_MinDuration.IsExpression ? m_MinDuration.Value : m_MinDuration.PrimitiveValue);
                target.m_MinDuration = Mathf.Approximately(0, templateDict[m_MinDuration.Id].Config.duration) ? targetValue : m_MinDurationAlertInit + templateDict[m_MinDuration.Id].Config.alertCurve.Evaluate(templateDict[m_MinDuration.Id].CostTime / templateDict[m_MinDuration.Id].Config.duration) * m_MinDurationDiff;
            }
            if (m_RandomizeChoice.IsUse) target.m_RandomizeChoice = m_RandomizeChoice.IsExpression ? !Mathf.Approximately(m_RandomizeChoice.Value, 0) : m_RandomizeChoice.PrimitiveValue;
            // 处理字段 m_DefaultBlend
            // 生成递归代码
            m_DefaultBlend?.ControlCinemachine(ref target.m_DefaultBlend, templateDict);
            // 处理字段 m_CustomBlends
            // 生成递归代码
            m_CustomBlends?.ControlCinemachine(ref target.m_CustomBlends, templateDict);
            // 处理数组字段 m_ExcludedPropertiesInInspector
            for (int i = 0; i < (m_ExcludedPropertiesInInspector?.Length ?? 0); i++)
            {
                // 生成递归代码
                if (m_ExcludedPropertiesInInspector[i].IsUse) target.m_ExcludedPropertiesInInspector[i] = m_ExcludedPropertiesInInspector[i].PrimitiveValue;
            }
            // 处理数组字段 m_LockStageInInspector
            for (int i = 0; i < (m_LockStageInInspector?.Length ?? 0); i++)
            {
                // 生成递归代码
                if (m_LockStageInInspector[i].IsUse) target.m_LockStageInInspector[i] = (m_LockStageInInspector[i].IsExpression ? (Cinemachine.CinemachineCore.Stage)m_LockStageInInspector[i].Value : (Cinemachine.CinemachineCore.Stage)m_LockStageInInspector[i].PrimitiveValue);
            }
            if (m_Priority.IsUse) target.m_Priority = m_Priority.IsExpression ? (System.Int32)m_Priority.Value :m_Priority.PrimitiveValue;
            if (FollowTargetAttachment.IsUse && templateDict.ContainsKey(FollowTargetAttachment.Id))
            {
                var targetValue = (FollowTargetAttachment.IsExpression ? FollowTargetAttachment.Value : FollowTargetAttachment.PrimitiveValue);
                target.FollowTargetAttachment = Mathf.Approximately(0, templateDict[FollowTargetAttachment.Id].Config.duration) ? targetValue : FollowTargetAttachmentAlertInit + templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * FollowTargetAttachmentDiff;
            }
            if (LookAtTargetAttachment.IsUse && templateDict.ContainsKey(LookAtTargetAttachment.Id))
            {
                var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
                target.LookAtTargetAttachment = Mathf.Approximately(0, templateDict[LookAtTargetAttachment.Id].Config.duration) ? targetValue : LookAtTargetAttachmentAlertInit + templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * LookAtTargetAttachmentDiff;
            }
            if (m_StandbyUpdate.IsUse) target.m_StandbyUpdate = m_StandbyUpdate.IsExpression ? (Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode)m_StandbyUpdate.Value :m_StandbyUpdate.PrimitiveValue;
        }
    }
}
