using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CameraMovement;

namespace CameraMovement{
        public class Control_C_LensSettings_Field :ICameraMovementControlField
    {
       public  Type AttachControlField => typeof(Cinemachine.LensSettings);

       [UnityEngine.TooltipAttribute("This is the camera view in degrees. Display will be in vertical degress, unless the associated camera has its FOV axis setting set to Horizontal, in which case display will be in horizontal degress.  Internally, it is always vertical degrees.  For cinematic people, a 50mm lens on a super-35mm sensor would equal a 19.6 degree FOV")]
            public DataMixer <System.Single> FieldOfView;
       [UnityEngine.TooltipAttribute("When using an orthographic camera, this defines the half-height, in world coordinates, of the camera view.")]
            public DataMixer <System.Single> OrthographicSize;
       [UnityEngine.TooltipAttribute("This defines the near region in the renderable range of the camera frustum. Raising this value will stop the game from drawing things near the camera, which can sometimes come in handy.  Larger values will also increase your shadow resolution.")]
            public DataMixer <System.Single> NearClipPlane;
       [UnityEngine.TooltipAttribute("This defines the far region of the renderable range of the camera frustum. Typically you want to set this value as low as possible without cutting off desired distant objects")]
            public DataMixer <System.Single> FarClipPlane;
       [UnityEngine.TooltipAttribute("Camera Z roll, or tilt, in degrees.")]
            public DataMixer <System.Single> Dutch;
       [UnityEngine.TooltipAttribute("Allows you to select a different camera mode to apply to the Camera component when Cinemachine activates this Virtual Camera.  The changes applied to the Camera component through this setting will remain after the Virtual Camera deactivation.")]
            public DataMixer <Cinemachine.LensSettings.OverrideModes> ModeOverride;
        public DataMixer <UnityEngine.Camera.GateFitMode> GateFit;
        public DataMixer <System.Single> FocusDistance;
        public void AddByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_LensSettings_Config source = (CameraMovement.Control_C_LensSettings_Config)sourceConfig;
            if(source.FieldOfView.IsUse) FieldOfView.Add(new MixItem<System.Single>(id, priority, source.FieldOfView.Value));
            if(source.OrthographicSize.IsUse) OrthographicSize.Add(new MixItem<System.Single>(id, priority, source.OrthographicSize.Value));
            if(source.NearClipPlane.IsUse) NearClipPlane.Add(new MixItem<System.Single>(id, priority, source.NearClipPlane.Value));
            if(source.FarClipPlane.IsUse) FarClipPlane.Add(new MixItem<System.Single>(id, priority, source.FarClipPlane.Value));
            if(source.Dutch.IsUse) Dutch.Add(new MixItem<System.Single>(id, priority, source.Dutch.Value));
            if(source.ModeOverride.IsUse) ModeOverride.Add(new MixItem<Cinemachine.LensSettings.OverrideModes>(id, priority, source.ModeOverride.Value));
            if(source.GateFit.IsUse) GateFit.Add(new MixItem<UnityEngine.Camera.GateFitMode>(id, priority, source.GateFit.Value));
            if(source.FocusDistance.IsUse) FocusDistance.Add(new MixItem<System.Single>(id, priority, source.FocusDistance.Value));
        }
        public void RemoveByConfig(CameraMovementControlConfigBase sourceConfig,int id,int priority)
        {
            if(sourceConfig.GetType() != AttachControlField) return;
            CameraMovement.Control_C_LensSettings_Config source = (CameraMovement.Control_C_LensSettings_Config)sourceConfig;
            if(source.FieldOfView.IsUse) FieldOfView.Remove(new MixItem<System.Single>(id, priority, source.FieldOfView.Value));
            if(source.OrthographicSize.IsUse) OrthographicSize.Remove(new MixItem<System.Single>(id, priority, source.OrthographicSize.Value));
            if(source.NearClipPlane.IsUse) NearClipPlane.Remove(new MixItem<System.Single>(id, priority, source.NearClipPlane.Value));
            if(source.FarClipPlane.IsUse) FarClipPlane.Remove(new MixItem<System.Single>(id, priority, source.FarClipPlane.Value));
            if(source.Dutch.IsUse) Dutch.Remove(new MixItem<System.Single>(id, priority, source.Dutch.Value));
            if(source.ModeOverride.IsUse) ModeOverride.Remove(new MixItem<Cinemachine.LensSettings.OverrideModes>(id, priority, source.ModeOverride.Value));
            if(source.GateFit.IsUse) GateFit.Remove(new MixItem<UnityEngine.Camera.GateFitMode>(id, priority, source.GateFit.Value));
            if(source.FocusDistance.IsUse) FocusDistance.Remove(new MixItem<System.Single>(id, priority, source.FocusDistance.Value));
        }
        public void ControlCinemachine(object targetObj, Dictionary<int, RuntimeTemplate> templateDict)
        {
            var target = (Cinemachine.LensSettings)targetObj;
        }
    }
}
