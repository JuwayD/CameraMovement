using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineBlenderSettings_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlenderSettings);

       [UnityEngine.TooltipAttribute("The array containing explicitly defined blends between two Virtual Cameras")]
        public Control_C_CBS_CustomBlend_Field[] m_CustomBlends;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlenderSettings_Config source = (CameraMovement.Control_C_CinemachineBlenderSettings_Config)sourceConfig;
            for(int i = 0;i < m_CustomBlends.Length;i++)
            {
                m_CustomBlends[i].AddByConfig(source.m_CustomBlends[i], id, priority);            }

        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlenderSettings_Config source = (CameraMovement.Control_C_CinemachineBlenderSettings_Config)sourceConfig;
            for(int i = 0;i < m_CustomBlends.Length;i++)
            {
                m_CustomBlends[i].RemoveByConfig(source.m_CustomBlends[i], id, priority);            }

        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineBlenderSettings)targetObj;
            // 处理数组字段 m_CustomBlends
            for (int i = 0; i < m_CustomBlends.Length; i++)
            {
                // 生成递归代码
                m_CustomBlends[i].ControlCinemachine(target.m_CustomBlends[i], templateDict);
            }
        }
    }
}
