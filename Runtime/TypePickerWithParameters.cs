using System;
using Newtonsoft.Json;
using UnityEngine;

namespace TypePickerWithParameters.Runtime
{
    [Serializable]
    public class TypePickerWithParameters<T>
    {
        public TypeRef<T> TypeRef;
        [Params] public string Params;

        private T instance;

        public T Instance
        {
            get
            {
                if (instance != null) return instance;
                if ((Type)TypeRef == null)
                    Debug.LogException(new Exception("A type is null. Choose the type in the inspector"));

                instance = (T)JsonConvert.DeserializeObject(Params, TypeRef);

                return instance;
            }
        }
    }
}