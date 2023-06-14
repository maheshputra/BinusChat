using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BinusChat
{
    public class ChatBubbleFriend : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chatText;

        public void UpdateChat(string text)
        {
            Debug.Log(text);
            chatText.text = text;
        }
    }
}