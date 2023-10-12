using Cinemachine;
using UnityEngine;

namespace CameraMovement
{
    /// <summary>
    /// 最基础的三环相机
    /// </summary>
    public class CameraMovementStateFreeLook: CameraMovementStateBase
    {
        #region 字段
        
        protected CinemachineFreeLook virtualCamera_;
        protected CinemachineComponentBase bodyComp_;
        protected CinemachineComponentBase aimComp_;
        protected CinemachineComponentBase noiseComp_;
        protected CinemachineComponentBase finalizeComp_;
        protected Control_C_CinemachineFreeLook_Field controlVirtualCamera_;
        protected ICameraMovementControlField<CinemachineComponentBase> controlBodyComp_;
        protected ICameraMovementControlField<CinemachineComponentBase> controlAimComp_;
        protected ICameraMovementControlField<CinemachineComponentBase> controlNoiseComp_;
        protected ICameraMovementControlField<CinemachineComponentBase> controlFinalizeComp_;

        #endregion

        protected override CinemachineVirtualCameraBase VirtualCamera => virtualCamera_;

        protected override void OnInit(GameObject go, CameraMovementConfigState configState, CameraMovementStateMachine machine)
        {
            virtualCamera_ = go.GetComponent<CinemachineFreeLook>();
            controlVirtualCamera_ = new Control_C_CinemachineFreeLook_Field();
            extensionList_.Add(virtualCamera_.GetComponent<CinemachineCollider>());
        }

        protected override void OnTemplateRemove(int id)
        {
            controlVirtualCamera_.RemoveByConfig(runtimeTemplateDict_[id].Config.controlConfigBaseTemplate, id, runtimeTemplateDict_[id].Config.priority, ref virtualCamera_);
        }

        protected override void AddConfig(CameraMovementConfig config)
        {
            controlVirtualCamera_?.AddByConfig(config.controlConfigBaseTemplate, config.id, config.priority, ref virtualCamera_);
        }

        protected override void ControlCinemachine()
        {
            //更新Cinemachine相机
            if (virtualCamera_ != null && controlVirtualCamera_ != null && controlVirtualCamera_.AttachControlField == virtualCamera_.GetType())
            {
                controlVirtualCamera_.ControlCinemachine(ref virtualCamera_, runtimeTemplateDict_);
            }
            //更新Cinemachine body组件
            if (bodyComp_ != null && controlBodyComp_ != null && controlBodyComp_.AttachControlField == bodyComp_.GetType())
            {
                controlBodyComp_.ControlCinemachine(ref bodyComp_, runtimeTemplateDict_);
            }
            //更新Cinemachine anim组件
            if (aimComp_ != null && controlAimComp_ != null && controlAimComp_.AttachControlField == aimComp_.GetType())
            {
                controlAimComp_.ControlCinemachine(ref aimComp_, runtimeTemplateDict_);
            }
            //更新Cinemachine noise组件
            if (noiseComp_ != null && controlNoiseComp_ != null && controlNoiseComp_.AttachControlField == noiseComp_.GetType())
            {
                controlNoiseComp_.ControlCinemachine(ref noiseComp_, runtimeTemplateDict_);
            }
            //更新Cinemachine finalize组件
            if (finalizeComp_ != null && controlFinalizeComp_ != null && controlFinalizeComp_.AttachControlField == finalizeComp_.GetType())
            {
                controlFinalizeComp_.ControlCinemachine(ref finalizeComp_, runtimeTemplateDict_);
            }

        }

        public override void OnEnter(CameraMovementStateBase fromState)
        {
        }
        
        public override void OnExit(CameraMovementStateBase toState)
        {
        }

        public override void OnUnInit()
        {
            extensionList_.Clear();
            virtualCamera_ = null;
        }

    }
}