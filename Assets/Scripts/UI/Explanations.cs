using System;
using JetBrains.Annotations;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "Gameplay/Explanation", fileName = "New explanations", order = 0)]
    public class Explanations : ScriptableObject
    {
        [SerializeField] private string[] content;
        private int _index = 0;
        private int Index {
            get => _index;
            set => _index = _index >= content.Length ? 0 : value;
        }

        public void Reset() => Index = 0;

        [CanBeNull]
        public string GetNextContent()
        {
            try {
                var text = content[Index];
                Index++;
                return text;
            }
            catch (IndexOutOfRangeException e)
            {
                return null;
            }
            
        }
    }
}