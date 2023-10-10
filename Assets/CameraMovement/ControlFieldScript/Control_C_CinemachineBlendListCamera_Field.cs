using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineBlendListCamera_Field :ICameraMovementControlField
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
       [System.NonSerializedAttribute]
            public DataMixer <System.Single> LookAtTargetAttachment;
       [UnityEngine.TooltipAttribute("When the virtual camera is not live, this is how often the virtual camera will be updated.  Set this to tune for performance. Most of the time Never is fine, unless the virtual camera is doing shot evaluation.")]
            public DataMixer <Cinemachine.CinemachineVirtualCameraBase.StandbyUpdateMode> m_StandbyUpdate;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlendListCamera_Config source = (CameraMovement.Control_C_CinemachineBlendListCamera_Config)sourceConfig;
            if(source.m_ShowDebugText.IsUse) m_ShowDebugText.Add(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value));
            if(source.m_Loop.IsUse) m_Loop.Add(new MixItem<System.Boolean>(id, priority, source.m_Loop.CalculatorExpression, source.m_Loop.Value));
            for(int i = 0;i < m_Instructions.Length;i++)
            {
                m_Instructions[i].AddByConfig(source.m_Instructions[i], id, priority);            }

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
            CameraMovement.Control_C_CinemachineBlendListCamera_Config source = (CameraMovement.Control_C_CinemachineBlendListCamera_Config)sourceConfig;
            if(source.m_ShowDebugText.IsUse) m_ShowDebugText.Remove(new MixItem<System.Boolean>(id, priority, source.m_ShowDebugText.CalculatorExpression, source.m_ShowDebugText.Value));
            if(source.m_Loop.IsUse) m_Loop.Remove(new MixItem<System.Boolean>(id, priority, source.m_Loop.CalculatorExpression, source.m_Loop.Value));
            for(int i = 0;i < m_Instructions.Length;i++)
            {
                m_Instructions[i].RemoveByConfig(source.m_Instructions[i], id, priority);            }

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
            m_Loop.RemoveAll();
            for(int i = 0;i < m_Instructions.Length;i++)
            {
                m_Instructions[i].RemoveAll();            }

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
            var target = (Cinemachine.CinemachineBlendListCamera)targetObj;
            target.m_ShowDebugText = !Mathf.Approximately(m_ShowDebugText.Value, 0);
            target.m_Loop = !Mathf.Approximately(m_Loop.Value, 0);
            // 处理数组字段 m_Instructions
            for (int i = 0; i < m_Instructions.Length; i++)
            {
                // 生成递归代码
                m_Instructions[i].ControlCinemachine(target.m_Instructions[i], templateDict);
            }
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
