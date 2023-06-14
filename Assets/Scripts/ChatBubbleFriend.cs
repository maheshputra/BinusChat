using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BinusChat
{
    public class ChatBubbleFriend : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chatText;

        private void Start()
        {
            chatText.text = "";
        }

        public void UpdateChat(string text)
        {
            chatText.text = text;
        }
    }
}