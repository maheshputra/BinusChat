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
        public string statusMessage;
        public List<ChatData> chatDatas;

        [Header("OPEN AI")]
        [TextArea]
        public string friendBackground = "You are a university student. Your name is Howl Jenkins Pendragon. You are busy of doing university work. You will act and respond like university student. You keep your responses short and to the point. You are role playing.";
    }
}