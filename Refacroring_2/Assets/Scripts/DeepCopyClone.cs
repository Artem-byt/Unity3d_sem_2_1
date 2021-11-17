using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Asteroids
{
    public static class DeepCopyClone
    {
        public static T DeepCopy<T>(this T self)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Type must be iserializable");
            }
            if (ReferenceEquals(self, null))
            {
                return default;
            }

            var formatter = new BinaryFormatter();

            var selector = new SurrogateSelector();
            var transformSurrogate = new Vector3SerializationSurrogate();
            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), transformSurrogate);
            formatter.SurrogateSelector = selector;

            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}

