using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineVirtualCamera_Field :ICameraMovementControlField<Cinemachine.CinemachineVirtualCamera>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineVirtualCamera);

       [UnityEngine.TooltipAttribute("Specifies the lens properties of this Virtual Camera.  This generally mirrors the Unity Camera's lens settings, and will be used to drive the Unity camera when the vcam is active.")]
        public Control_C_LensSettings_Field m_Lens;
    public Control_C_CVCB_TransitionParams_Field m_Transitions;
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
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineVirtualCamera target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineVirtualCamera_Config source = (CameraMovement.Control_C_CinemachineVirtualCamera_Config)sourceConfig;
            if(source.m_Lens != null && m_Lens == null) m_Lens = new Control_C_LensSettings_Field();
            m_Lens?.AddByConfig(source.m_Lens, id, priority, ref target.m_Lens, templateDict);
            if(source.m_Transitions != null && m_Transitions == null) m_Transitions = new Control_C_CVCB_TransitionParams_Field();
            m_Transitions?.AddByConfig(source.m_Transitions, id, priority, ref target.m_Transitions, templateDict);
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
               FollowTargetAttachmentAlertInit = target.FollowTargetAttachment - templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (FollowTargetAttachmentDiff);
            }
            if(source.LookAtTargetAttachment.IsUse)
            {
                LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
               var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
               LookAtTargetAttachmentDiff = targetValue - target.LookAtTargetAttachment;
               LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment - templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (LookAtTargetAttachmentDiff);
            }
            if(source.m_StandbyUpdate.IsUse)
            {
                m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
            }
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineVirtualCamera target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineVirtualCamera_Config source = (CameraMovement.Control_C_CinemachineVirtualCamera_Config)sourceConfig;
            m_Lens?.RemoveByConfig(source.m_Lens, id, priority, ref target.m_Lens, templateDict);
            m_Transitions?.RemoveByConfig(source.m_Transitions, id, priority, ref target.m_Transitions, templateDict);
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
               FollowTargetAttachmentAlertInit = target.FollowTargetAttachment - templateDict[FollowTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[FollowTargetAttachment.Id].CostTime / templateDict[FollowTargetAttachment.Id].Config.duration) * (FollowTargetAttachmentDiff);
            }
            if(source.LookAtTargetAttachment.IsUse)
            {
                LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value, source.LookAtTargetAttachment.IsUse));
               var targetValue = (LookAtTargetAttachment.IsExpression ? LookAtTargetAttachment.Value : LookAtTargetAttachment.PrimitiveValue);
               LookAtTargetAttachmentDiff = targetValue - target.LookAtTargetAttachment;
               LookAtTargetAttachmentAlertInit = target.LookAtTargetAttachment - templateDict[LookAtTargetAttachment.Id].Config.alertCurve.Evaluate(templateDict[LookAtTargetAttachment.Id].CostTime / templateDict[LookAtTargetAttachment.Id].Config.duration) * (LookAtTargetAttachmentDiff);
            }
            if(source.m_StandbyUpdate.IsUse)
            {
                m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value, source.m_StandbyUpdate.IsUse));
            }
        }
        public void RemoveAll()
        {
            m_Lens.RemoveAll();
            m_Transitions.RemoveAll();
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
        public void ControlCinemachine(ref Cinemachine.CinemachineVirtualCamera target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            // 处理字段 m_Lens
            // 生成递归代码
            m_Lens?.ControlCinemachine(ref target.m_Lens, templateDict);
            // 处理字段 m_Transitions
            // 生成递归代码
            m_Transitions?.ControlCinemachine(ref target.m_Transitions, templateDict);
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
