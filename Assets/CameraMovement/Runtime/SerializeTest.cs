using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace CameraMovement
{
    [CreateAssetMenu(menuName = "test")]
    public class SerializeTest:SerializedScriptableObject
    {
        public A A;
    }

    public class A
    {
        public float a;
        public float a1;
        public float a2;
        public B B;
    }

    public class B
    {
        public int b;
    }
}