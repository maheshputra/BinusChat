using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinusChat
{
    [CreateAssetMenu(fileName = "FriendSO", menuName = "ScriptableObjects/FriendSO")]
    public class FriendSO : ScriptableObject
    {
        public string firstName;
        public string lastName;
        public Sprite sprite;
    }
}