using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineStateDrivenCamera_Field :ICameraMovementControlField
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
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> LookAtTargetAttachment;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineStateDrivenCamera_Config source = (CameraMovement.Control_C_CinemachineStateDrivenCamera_Config)sourceConfig;
            if(source.m_LayerIndex.IsUse) m_LayerIndex.Add(new MixItem<System.Int32>(id, priority, source.m_LayerIndex.Value));
            if(source.m_ShowDebugText.IsUse) m_ShowDebugText.Add(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.Value));
            for(int i = 0;i < m_Instructions.Length;i++)
            {
                m_Instructions[i].AddByConfig(source.m_Instructions[i], id, priority);            }

            m_DefaultBlend.AddByConfig(source.m_DefaultBlend, id, priority);
            m_CustomBlends.AddByConfig(source.m_CustomBlends, id, priority);
            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].AddByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].AddByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Add(new MixItem<System.Int32>(id, priority, source.m_Priority.Value));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.Value));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Add(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.Value));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Add(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineStateDrivenCamera_Config source = (CameraMovement.Control_C_CinemachineStateDrivenCamera_Config)sourceConfig;
            if(source.m_LayerIndex.IsUse) m_LayerIndex.Remove(new MixItem<System.Int32>(id, priority, source.m_LayerIndex.Value));
            if(source.m_ShowDebugText.IsUse) m_ShowDebugText.Remove(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.Value));
            for(int i = 0;i < m_Instructions.Length;i++)
            {
                m_Instructions[i].RemoveByConfig(source.m_Instructions[i], id, priority);            }

            m_DefaultBlend.RemoveByConfig(source.m_DefaultBlend, id, priority);
            m_CustomBlends.RemoveByConfig(source.m_CustomBlends, id, priority);
            for(int i = 0;i < m_ExcludedPropertiesInInspector.Length;i++)
            {
                m_ExcludedPropertiesInInspector[i].RemoveByConfig(source.m_ExcludedPropertiesInInspector[i], id, priority);            }

            for(int i = 0;i < m_LockStageInInspector.Length;i++)
            {
                m_LockStageInInspector[i].RemoveByConfig(source.m_LockStageInInspector[i], id, priority);            }

            if(source.m_Priority.IsUse) m_Priority.Remove(new MixItem<System.Int32>(id, priority, source.m_Priority.Value));
            if(source.FollowTargetAttachment.IsUse) FollowTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.FollowTargetAttachment.Value));
            if(source.LookAtTargetAttachment.IsUse) LookAtTargetAttachment.Remove(new MixItem<System.Single>(id, priority, source.LookAtTargetAttachment.Value));
            if(source.m_StandbyUpdate.IsUse) m_StandbyUpdate.Remove(new MixItem<Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode>(id, priority, source.m_StandbyUpdate.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineStateDrivenCamera)targetObj;
            target.m_LayerIndex = m_LayerIndex.Value;
            target.m_ShowDebugText = m_ShowDebugText.Value;
            // 处理数组字段 m_Instructions
            for (int i = 0; i < m_Instructions.Length; i++)
            {
                // 生成递归代码
                m_Instructions[i].ControlCinemachine(target.m_Instructions[i], templateDict);
            }
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
            target.m_Priority = m_Priority.Value;
            target.m_StandbyUpdate = m_StandbyUpdate.Value;
        }
    }
}
