using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinusChat
{
    [CreateAssetMenu(fileName = "ConversationSO", menuName = "ScriptableObjects/ConversationSO")]
    public class ConversationSO : ScriptableObject
    {
        public FriendSO friendSO;
        public List<ChatData> chatDatas;
    }
}