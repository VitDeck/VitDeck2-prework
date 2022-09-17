using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace VitDeck.Validation
{
    public class Validator
    {
        public Result Validate(Object rootAsset)
        {
            if(rootAsset == null)
            {
                throw new ArgumentNullException(nameof(rootAsset));
            }
            var result = ScriptableObject.CreateInstance<Result>();
            result.Initialize($"OK - {rootAsset.name} - {UnityEngine.Random.Range(0, 255)}");
            
            for(int i=0; i<10; i++)
            {
                result.AddLog(LogType.Info, $"Info {i}");
            }
            return result;
        }
    }
}