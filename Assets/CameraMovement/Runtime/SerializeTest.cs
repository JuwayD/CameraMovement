using System;
using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace CameraMovement
{
    [CreateAssetMenu(menuName = "test")]
    public class SerializeTest:SerializedScriptableObject
    {
        public A A;
        [ListDrawerSettings(ListElementLabelName = "asd")]
        public List<A> ListA;

        public void SerTest<T>()
        {
            
            // Unity should be allowed to handle serialization and deserialization of its own weird objects.
            // So if your data-graph contains UnityEngine.Object types, you will need to provide Odin with
            // a list of UnityEngine.Object which it will then use as an external reference resolver.
            Vector3 originalData = default;
            List<UnityEngine.Object> unityObjectReferences = new List<UnityEngine.Object>();

            //DataFormat dataFormat = DataFormat.Binary;
            DataFormat dataFormat = DataFormat.JSON;
            //DataFormat dataFormat = DataFormat.Nodes;

            byte[] bytes;
            // Serialization
            {
                bytes = SerializationUtility.SerializeValue(originalData, dataFormat, out unityObjectReferences);

                // If you want the json string, use UTF8 encoding
                // var jsonString = System.Text.Encoding.UTF8.GetString(bytes);
            }

            // Deserialization
            {
                // If you have a string to deserialize, get the bytes using UTF8 encoding
                // var bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

                var data = SerializationUtility.DeserializeValue<T>(bytes, dataFormat, unityObjectReferences);
            }
        }
    }
    
   
    
    public class A
    {
        public float a;
        public float a1;
        public float a2;
        public B B;
        public string asd;
        
        [TableList()]
        public List<int> la = new List<int>();
    }

    public class B
    {
        public int b;
    }
}