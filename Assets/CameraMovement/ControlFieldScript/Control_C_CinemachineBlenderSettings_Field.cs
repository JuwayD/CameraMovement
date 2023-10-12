using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
    public class Control_C_CinemachineBlenderSettings_Field :ICameraMovementControlField<Cinemachine.CinemachineBlenderSettings>
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineBlenderSettings);

       [UnityEngine.TooltipAttribute("The array containing explicitly defined blends between two Virtual Cameras")]
        public Control_C_CBS_CustomBlend_Field[] m_CustomBlends;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBlenderSettings target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlenderSettings_Config source = (CameraMovement.Control_C_CinemachineBlenderSettings_Config)sourceConfig;
            for(int i = 0;i < (source.m_CustomBlends?.Length ?? 0);i++)
            {
                if(source.m_CustomBlends != null && m_CustomBlends == null) m_CustomBlends = new Control_C_CBS_CustomBlend_Field[source.m_CustomBlends.Length];
                m_CustomBlends?[i].AddByConfig(source.m_CustomBlends[i], id, priority, ref target.m_CustomBlends[i]);            }

        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority, ref Cinemachine.CinemachineBlenderSettings target)
        {
            if(sourceConfig == null) return;
            if(sourceConfig.AttachControlField != AttachControlField) return;
            CameraMovement.Control_C_CinemachineBlenderSettings_Config source = (CameraMovement.Control_C_CinemachineBlenderSettings_Config)sourceConfig;
            for(int i = 0;i < (source.m_CustomBlends?.Length ?? 0);i++)
            {
                m_CustomBlends?[i].RemoveByConfig(source.m_CustomBlends[i], id, priority, ref target.m_CustomBlends[i]);            }

        }
        public void RemoveAll()
        {
            for(int i = 0;i < (m_CustomBlends?.Length ?? 0);i++)
            {
                m_CustomBlends?[i].RemoveAll();            }

        }
        public void ControlCinemachine(ref Cinemachine.CinemachineBlenderSettings target, Dictionary<int, RuntimeTemplate> templateDict)
        {
            // 处理数组字段 m_CustomBlends
            for (int i = 0; i < (target.m_CustomBlends?.Length ?? 0); i++)
            {
                // 生成递归代码
                m_CustomBlends?[i].ControlCinemachine(ref target.m_CustomBlends[i], templateDict);
            }
        }
    }
}
