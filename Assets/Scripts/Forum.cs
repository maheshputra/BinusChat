using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinusChat
{
    public class Forum : MonoBehaviour
    {
        [SerializeField] private List<ForumSO> forumSOs;

        [SerializeField] private ForumBubble forumBubblePrefab;
        [SerializeField] private Transform forumBubbleParent;

        [Header("UI")]
        [SerializeField] private Canvas canvasForum;
        [SerializeField] private Canvas canvasForumScreen;
        

        private void Start()
        {
            canvasForum.gameObject.SetActive(true);
            ShowForum(false);
            InitializeBubbles();
        }

        public void ShowForum(bool show)
        {
            canvasForum.enabled = show;
        }

        public void InitializeBubbles()
        {
            for (int i = 0; i < forumSOs.Count; i++)
            {
                ForumBubble fb = Instantiate(forumBubblePrefab, forumBubbleParent);
                fb.InitializeBubble(forumSOs[i]);
            }
        }
    }
}
