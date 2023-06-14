using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BinusChat
{
    public class ChatBubbleUser : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chatText;
        
        public void UpdateChat(string text)
        {
            chatText.text = text;
        }
    }
}