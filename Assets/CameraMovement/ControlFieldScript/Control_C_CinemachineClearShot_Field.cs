using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineClearShot_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineClearShot);

       [UnityEngine.TooltipAttribute("When enabled, the current child camera and blend will be indicated in the game window, for debugging")]
            public DataMixer <System.Boolean> m_ShowDebugText;
       [UnityEngine.TooltipAttribute("Wait this many seconds before activating a new child camera")]
            public DataMixer <System.Single> m_ActivateAfter;
       [UnityEngine.TooltipAttribute("An active camera must be active for at least this many seconds")]
            public DataMixer <System.Single> m_MinDuration;
       [UnityEngine.TooltipAttribute("If checked, camera choice will be randomized if multiple cameras are equally desirable.  Otherwise, child list order and child camera priority will be used.")]
            public DataMixer <System.Boolean> m_RandomizeChoice;
       [UnityEngine.TooltipAttribute("The blend which is used if you don't explicitly define a blend between two Virtual Cameras")]
        public Control_C_CinemachineBlendDefinition_Field m_DefaultBlend;
       [UnityEngine.HideInInspector]
        public Control_C_CinemachineBlenderSettings_Field m_CustomBlends;
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
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineClearShot_Config source = (CameraMovement.Control_C_CinemachineClearShot_Config)sourceConfig;
            if(source.m_ShowDebugText.IsUse) m_ShowDebugText.Add(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value));
            if(source.m_ActivateAfter.IsUse) m_ActivateAfter.Add(new MixItem<System.Single>(id, priority, source.m_ActivateAfter.CalculatorExpression, source.m_ActivateAfter.Value));
            if(source.m_MinDuration.IsUse) m_MinDuration.Add(new MixItem<System.Single>(id, priority, source.m_MinDuration.CalculatorExpression, source.m_MinDuration.Value));
            if(source.m_RandomizeChoice.IsUse) m_RandomizeChoice.Add(new MixItem<System.Boolean>(id, priority, source.m_RandomizeChoice.CalculatorExpression, source.m_RandomizeChoice.Value));
            m_DefaultBlend.AddByConfig(source.m_DefaultBlend, id, priority);
            m_CustomBlends.AddByConfig(source.m_CustomBlends, id, priority);
            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].AddByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].AddByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Add(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineClearShot_Config source = (CameraMovement.Control_C_CinemachineClearShot_Config)sourceConfig;
            if(source.m_ShowDebugText.IsUse) m_ShowDebugText.Remove(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value));
            if(source.m_ActivateAfter.IsUse) m_ActivateAfter.Remove(new MixItem<System.Single>(id, priority, source.m_ActivateAfter.CalculatorExpression, source.m_ActivateAfter.Value));
            if(source.m_MinDuration.IsUse) m_MinDuration.Remove(new MixItem<System.Single>(id, priority, source.m_MinDuration.CalculatorExpression, source.m_MinDuration.Value));
            if(source.m_RandomizeChoice.IsUse) m_RandomizeChoice.Remove(new MixItem<System.Boolean>(id, priority, source.m_RandomizeChoice.CalculatorExpression, source.m_RandomizeChoice.Value));
            m_DefaultBlend.RemoveByConfig(source.m_DefaultBlend, id, priority);
            m_CustomBlends.RemoveByConfig(source.m_CustomBlends, id, priority);
            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].RemoveByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].RemoveByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Remove(new MixItem<System.Int32>(id, priority, source.m_Priority.CalculatorExpression, source.m_Priority.Value));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.CalculatorExpression, source.FollowTargetAttachment.Value));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.CalculatorExpression, source.LookAtTargetAttachment.Value));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.CalculatorExpression, source.m_StandbyUpdate.Value));
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
                m_ExcludedPropertiesInInspector[i].RemoveAll();            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].RemoveAll();            }

            m_Priority.RemoveAll();
            FollowTargetAttachment.RemoveAll();
            LookAtTargetAttachment.RemoveAll();
            m_StandbyUpdate.RemoveAll();
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineClearShot)targetObj;
            target.m_ShowDebugText = !Mathf.Approximately(m_ShowDebugText.Value, 0);
            if (templateDict.ContainsKey(m_ActivateAfter.Id))
                target.m_ActivateAfter = templateDict[m_ActivateAfter.Id].Config.alertCurve.Evaluate(templateDict[m_ActivateAfter.Id].CostTime / templateDict[m_ActivateAfter.Id].Config.duration) * m_ActivateAfter.Value;
            target.m_ActivateAfter = (System.Single)m_ActivateAfter.Value;
            if (templateDict.ContainsKey(m_MinDuration.Id))
                target.m_MinDuration = templateDict[m_MinDuration.Id].Config.alertCurve.Evaluate(templateDict[m_MinDuration.Id].CostTime / templateDict[m_MinDuration.Id].Config.duration) * m_MinDuration.Value;
            target.m_MinDuration = (System.Single)m_MinDuration.Value;
            target.m_RandomizeChoice = !Mathf.Approximately(m_RandomizeChoice.Value, 0);
            // 处理字段 m_DefaultBlend
            // 生成递归代码
            m_DefaultBlend.ControlCinemachine(target.m_DefaultBlend, templateDict);
            // 处理字段 m_CustomBlends
            // 生成递归代码
            m_CustomBlends.ControlCinemachine(target.m_CustomBlends, templateDict);
            // 处理数组字段 m_ExcludedPropertiesInInspector
            for (int i = 0; i < m_ExcludedPropertiesInInspector.Length; i++)
            {
                // 生成递归代码
                m_ExcludedPropertiesInInspector[i].ControlCinemachine(target.m_ExcludedPropertiesInInspector[i], templateDict);
            }
            // 处理数组字段 m_LockStageInInspector
            for (int i = 0; i < m_LockStageInInspector.Length; i++)
            {
                // 生成递归代码
                m_LockStageInInspector[i].ControlCinemachine(target.m_LockStageInInspector[i], templateDict);
            }
            target.m_Priority = (System.Int32)m_Priority.Value;
            target.m_StandbyUpdate = (Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode)m_StandbyUpdate.Value;
        }
    }
}
