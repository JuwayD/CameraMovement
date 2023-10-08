using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineTrackedDolly_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineTrackedDolly);

       [UnityEngine.TooltipAttribute("The position along the path at which the camera will be placed.  This can be animated directly, or set automatically by the Auto-Dolly feature to get as close as possible to the Follow target.  The value is interpreted according to the Position Units setting.")]
            public DataMixer <System.Single> m_PathPosition;
       [UnityEngine.TooltipAttribute("How to interpret Path Position.  If set to Path Units, values are as follows: 0 represents the first waypoint on the path, 1 is the second, and so on.  Values in-between are points on the path in between the waypoints.  If set to Distance, then Path Position represents distance along the path.")]
            public DataMixer <Cinemachine.CinemachinePathBase.PositionUnits> m_PositionUnits;
       [UnityEngine.TooltipAttribute("Where to put the camera relative to the path position.  X is perpendicular to the path, Y is up, and Z is parallel to the path.  This allows the camera to be offset from the path itself (as if on a tripod, for example).")]
            public DataMixer <UnityEngine.Vector3> m_PathOffset;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain its position in a direction perpendicular to the path.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_XDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain its position in the path-local up direction.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_YDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain its position in a direction parallel to the path.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_ZDamping;
       [UnityEngine.TooltipAttribute("How to set the virtual camera's Up vector.  This will affect the screen composition, because the camera Aim behaviours will always try to respect the Up direction.")]
            public DataMixer <Cinemachine.CinemachineTrackedDolly.CameraUpMode> m_CameraUp;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's X angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_PitchDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Y angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_YawDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Z angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_RollDamping;
       [UnityEngine.TooltipAttribute("Controls how automatic dollying occurs.  A Follow target is necessary to use this feature.")]
        public Control_C_CTD_AutoDolly_Field m_AutoDolly;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineTrackedDolly_Config source = (CameraMovement.Control_C_CinemachineTrackedDolly_Config)sourceConfig;
            if(source.m_PathPosition.IsUse) m_PathPosition.Add(new MixItem<System.Single>(id, priority, source.m_PathPosition.Value));
            if(source.m_PositionUnits.IsUse) m_PositionUnits.Add(new MixItem<Cinemachine.CinemachinePathBase.PositionUnits>(id, priority, source.m_PositionUnits.Value));
            if(source.m_PathOffset.IsUse) m_PathOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_PathOffset.Value));
            if(source.m_XDamping.IsUse) m_XDamping.Add(new MixItem<System.Single>(id, priority, source.m_XDamping.Value));
            if(source.m_YDamping.IsUse) m_YDamping.Add(new MixItem<System.Single>(id, priority, source.m_YDamping.Value));
            if(source.m_ZDamping.IsUse) m_ZDamping.Add(new MixItem<System.Single>(id, priority, source.m_ZDamping.Value));
            if(source.m_CameraUp.IsUse) m_CameraUp.Add(new MixItem<Cinemachine.CinemachineTrackedDolly.CameraUpMode>(id, priority, source.m_CameraUp.Value));
            if(source.m_PitchDamping.IsUse) m_PitchDamping.Add(new MixItem<System.Single>(id, priority, source.m_PitchDamping.Value));
            if(source.m_YawDamping.IsUse) m_YawDamping.Add(new MixItem<System.Single>(id, priority, source.m_YawDamping.Value));
            if(source.m_RollDamping.IsUse) m_RollDamping.Add(new MixItem<System.Single>(id, priority, source.m_RollDamping.Value));
            m_AutoDolly.AddByConfig(source.m_AutoDolly, id, priority);
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineTrackedDolly_Config source = (CameraMovement.Control_C_CinemachineTrackedDolly_Config)sourceConfig;
            if(source.m_PathPosition.IsUse) m_PathPosition.Remove(new MixItem<System.Single>(id, priority, source.m_PathPosition.Value));
            if(source.m_PositionUnits.IsUse) m_PositionUnits.Remove(new MixItem<Cinemachine.CinemachinePathBase.PositionUnits>(id, priority, source.m_PositionUnits.Value));
            if(source.m_PathOffset.IsUse) m_PathOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_PathOffset.Value));
            if(source.m_XDamping.IsUse) m_XDamping.Remove(new MixItem<System.Single>(id, priority, source.m_XDamping.Value));
            if(source.m_YDamping.IsUse) m_YDamping.Remove(new MixItem<System.Single>(id, priority, source.m_YDamping.Value));
            if(source.m_ZDamping.IsUse) m_ZDamping.Remove(new MixItem<System.Single>(id, priority, source.m_ZDamping.Value));
            if(source.m_CameraUp.IsUse) m_CameraUp.Remove(new MixItem<Cinemachine.CinemachineTrackedDolly.CameraUpMode>(id, priority, source.m_CameraUp.Value));
            if(source.m_PitchDamping.IsUse) m_PitchDamping.Remove(new MixItem<System.Single>(id, priority, source.m_PitchDamping.Value));
            if(source.m_YawDamping.IsUse) m_YawDamping.Remove(new MixItem<System.Single>(id, priority, source.m_YawDamping.Value));
            if(source.m_RollDamping.IsUse) m_RollDamping.Remove(new MixItem<System.Single>(id, priority, source.m_RollDamping.Value));
            m_AutoDolly.RemoveByConfig(source.m_AutoDolly, id, priority);
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineTrackedDolly)targetObj;
            if (templateDict.ContainsKey(m_PathPosition.Id))
                target.m_PathPosition = templateDict[m_PathPosition.Id].Config.alertCurve.Evaluate(templateDict[m_PathPosition.Id].CostTime / templateDict[m_PathPosition.Id].Config.duration);
            target.m_PathPosition = m_PathPosition.Value;
            target.m_PositionUnits = m_PositionUnits.Value;
            if (templateDict.ContainsKey(m_XDamping.Id))
                target.m_XDamping = templateDict[m_XDamping.Id].Config.alertCurve.Evaluate(templateDict[m_XDamping.Id].CostTime / templateDict[m_XDamping.Id].Config.duration);
            target.m_XDamping = m_XDamping.Value;
            if (templateDict.ContainsKey(m_YDamping.Id))
                target.m_YDamping = templateDict[m_YDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YDamping.Id].CostTime / templateDict[m_YDamping.Id].Config.duration);
            target.m_YDamping = m_YDamping.Value;
            if (templateDict.ContainsKey(m_ZDamping.Id))
                target.m_ZDamping = templateDict[m_ZDamping.Id].Config.alertCurve.Evaluate(templateDict[m_ZDamping.Id].CostTime / templateDict[m_ZDamping.Id].Config.duration);
            target.m_ZDamping = m_ZDamping.Value;
            target.m_CameraUp = m_CameraUp.Value;
            if (templateDict.ContainsKey(m_PitchDamping.Id))
                target.m_PitchDamping = templateDict[m_PitchDamping.Id].Config.alertCurve.Evaluate(templateDict[m_PitchDamping.Id].CostTime / templateDict[m_PitchDamping.Id].Config.duration);
            target.m_PitchDamping = m_PitchDamping.Value;
            if (templateDict.ContainsKey(m_YawDamping.Id))
                target.m_YawDamping = templateDict[m_YawDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YawDamping.Id].CostTime / templateDict[m_YawDamping.Id].Config.duration);
            target.m_YawDamping = m_YawDamping.Value;
            if (templateDict.ContainsKey(m_RollDamping.Id))
                target.m_RollDamping = templateDict[m_RollDamping.Id].Config.alertCurve.Evaluate(templateDict[m_RollDamping.Id].CostTime / templateDict[m_RollDamping.Id].Config.duration);
            target.m_RollDamping = m_RollDamping.Value;
            // 处理字段 m_AutoDolly
            // 生成递归代码
            m_AutoDolly.ControlCinemachine(target.m_AutoDolly, templateDict);
        }
    }
}
