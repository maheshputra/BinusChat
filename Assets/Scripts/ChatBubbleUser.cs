using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace BinusChat
{
    public class ChatBubbleUser : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chatText;
        [SerializeField] private RectTransform chatContentRect;
        public void UpdateChat(string text)
        {
            chatText.text = text;
            LayoutRebuilder.MarkLayoutForRebuild(chatContentRect);
        }
    }
}