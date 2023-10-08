using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_CinemachineTransposer_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.CinemachineTransposer);

       [UnityEngine.TooltipAttribute("The coordinate space to use when interpreting the offset from the target.  This is also used to set the camera's Up vector, which will be maintained when aiming the camera.")]
            public DataMixer <Cinemachine.CinemachineTransposer.BindingMode> m_BindingMode;
       [UnityEngine.TooltipAttribute("The distance vector that the transposer will attempt to maintain from the Follow target")]
            public DataMixer <UnityEngine.Vector3> m_FollowOffset;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the X-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_XDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Y-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_YDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to maintain the offset in the Z-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
            public DataMixer <System.Single> m_ZDamping;
        public DataMixer <Cinemachine.CinemachineTransposer.AngularDampingMode> m_AngularDampingMode;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's X angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_PitchDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Y angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_YawDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target rotation's Z angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_RollDamping;
       [UnityEngine.TooltipAttribute("How aggressively the camera tries to track the target's orientation.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
            public DataMixer <System.Single> m_AngularDamping;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineTransposer_Config source = (CameraMovement.Control_C_CinemachineTransposer_Config)sourceConfig;
            if(source.m_BindingMode.IsUse) m_BindingMode.Add(new MixItem<Cinemachine.CinemachineTransposer.BindingMode>(id, priority, source.m_BindingMode.Value));
            if(source.m_FollowOffset.IsUse) m_FollowOffset.Add(new MixItem<UnityEngine.Vector3>(id, priority, source.m_FollowOffset.Value));
            if(source.m_XDamping.IsUse) m_XDamping.Add(new MixItem<System.Single>(id, priority, source.m_XDamping.Value));
            if(source.m_YDamping.IsUse) m_YDamping.Add(new MixItem<System.Single>(id, priority, source.m_YDamping.Value));
            if(source.m_ZDamping.IsUse) m_ZDamping.Add(new MixItem<System.Single>(id, priority, source.m_ZDamping.Value));
            if(source.m_AngularDampingMode.IsUse) m_AngularDampingMode.Add(new MixItem<Cinemachine.CinemachineTransposer.AngularDampingMode>(id, priority, source.m_AngularDampingMode.Value));
            if(source.m_PitchDamping.IsUse) m_PitchDamping.Add(new MixItem<System.Single>(id, priority, source.m_PitchDamping.Value));
            if(source.m_YawDamping.IsUse) m_YawDamping.Add(new MixItem<System.Single>(id, priority, source.m_YawDamping.Value));
            if(source.m_RollDamping.IsUse) m_RollDamping.Add(new MixItem<System.Single>(id, priority, source.m_RollDamping.Value));
            if(source.m_AngularDamping.IsUse) m_AngularDamping.Add(new MixItem<System.Single>(id, priority, source.m_AngularDamping.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_CinemachineTransposer_Config source = (CameraMovement.Control_C_CinemachineTransposer_Config)sourceConfig;
            if(source.m_BindingMode.IsUse) m_BindingMode.Remove(new MixItem<Cinemachine.CinemachineTransposer.BindingMode>(id, priority, source.m_BindingMode.Value));
            if(source.m_FollowOffset.IsUse) m_FollowOffset.Remove(new MixItem<UnityEngine.Vector3>(id, priority, source.m_FollowOffset.Value));
            if(source.m_XDamping.IsUse) m_XDamping.Remove(new MixItem<System.Single>(id, priority, source.m_XDamping.Value));
            if(source.m_YDamping.IsUse) m_YDamping.Remove(new MixItem<System.Single>(id, priority, source.m_YDamping.Value));
            if(source.m_ZDamping.IsUse) m_ZDamping.Remove(new MixItem<System.Single>(id, priority, source.m_ZDamping.Value));
            if(source.m_AngularDampingMode.IsUse) m_AngularDampingMode.Remove(new MixItem<Cinemachine.CinemachineTransposer.AngularDampingMode>(id, priority, source.m_AngularDampingMode.Value));
            if(source.m_PitchDamping.IsUse) m_PitchDamping.Remove(new MixItem<System.Single>(id, priority, source.m_PitchDamping.Value));
            if(source.m_YawDamping.IsUse) m_YawDamping.Remove(new MixItem<System.Single>(id, priority, source.m_YawDamping.Value));
            if(source.m_RollDamping.IsUse) m_RollDamping.Remove(new MixItem<System.Single>(id, priority, source.m_RollDamping.Value));
            if(source.m_AngularDamping.IsUse) m_AngularDamping.Remove(new MixItem<System.Single>(id, priority, source.m_AngularDamping.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.CinemachineTransposer)targetObj;
            target.m_BindingMode = m_BindingMode.Value;
            if (templateDict.ContainsKey(m_XDamping.Id))
                target.m_XDamping = templateDict[m_XDamping.Id].Config.alertCurve.Evaluate(templateDict[m_XDamping.Id].CostTime / templateDict[m_XDamping.Id].Config.duration);
            target.m_XDamping = m_XDamping.Value;
            if (templateDict.ContainsKey(m_YDamping.Id))
                target.m_YDamping = templateDict[m_YDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YDamping.Id].CostTime / templateDict[m_YDamping.Id].Config.duration);
            target.m_YDamping = m_YDamping.Value;
            if (templateDict.ContainsKey(m_ZDamping.Id))
                target.m_ZDamping = templateDict[m_ZDamping.Id].Config.alertCurve.Evaluate(templateDict[m_ZDamping.Id].CostTime / templateDict[m_ZDamping.Id].Config.duration);
            target.m_ZDamping = m_ZDamping.Value;
            target.m_AngularDampingMode = m_AngularDampingMode.Value;
            if (templateDict.ContainsKey(m_PitchDamping.Id))
                target.m_PitchDamping = templateDict[m_PitchDamping.Id].Config.alertCurve.Evaluate(templateDict[m_PitchDamping.Id].CostTime / templateDict[m_PitchDamping.Id].Config.duration);
            target.m_PitchDamping = m_PitchDamping.Value;
            if (templateDict.ContainsKey(m_YawDamping.Id))
                target.m_YawDamping = templateDict[m_YawDamping.Id].Config.alertCurve.Evaluate(templateDict[m_YawDamping.Id].CostTime / templateDict[m_YawDamping.Id].Config.duration);
            target.m_YawDamping = m_YawDamping.Value;
            if (templateDict.ContainsKey(m_RollDamping.Id))
                target.m_RollDamping = templateDict[m_RollDamping.Id].Config.alertCurve.Evaluate(templateDict[m_RollDamping.Id].CostTime / templateDict[m_RollDamping.Id].Config.duration);
            target.m_RollDamping = m_RollDamping.Value;
            if (templateDict.ContainsKey(m_AngularDamping.Id))
                target.m_AngularDamping = templateDict[m_AngularDamping.Id].Config.alertCurve.Evaluate(templateDict[m_AngularDamping.Id].CostTime / templateDict[m_AngularDamping.Id].Config.duration);
            target.m_AngularDamping = m_AngularDamping.Value;
        }
    }
}
