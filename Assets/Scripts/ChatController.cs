using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BinusChat
{
    public class ChatController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Transform chatContent;

        [Header("UI")]
        [SerializeField] private ChatBubbleUser prefabChatBubbleUser;
        [SerializeField] private ChatBubbleFriend prefabChatBubbleFriend;
        [SerializeField] private TMP_InputField inputFieldChat;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PublishMessage(string text)
        {
            ChatBubbleUser cbu = Instantiate(prefabChatBubbleUser, chatContent);
            cbu.UpdateChat(text);
        }
    }
}