using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BinusChat;

public class OpenAIController : MonoBehaviour
{
    public static OpenAIController instance;

    public TMP_InputField inputField;
    // public Button okButton;

    private OpenAIAPI api;
    private List<ChatMessage> messages;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        if (inputField != null)
        {
            inputField.onEndEdit.AddListener(OnEnterKeyPressed);
        }

        // This line gets your API key (and could be slightly different on Mac/Linux)
        string key = "";
        // key = "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";
        key = "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";
        // key = "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";
        // api = new OpenAIAPI(Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User));
        api = new OpenAIAPI(key);
        // api = new OpenAIAPI(Environment.GetEnvironmentVariable("OPENAI_API_KEY", EnvironmentVariableTarget.User));
        // okButton.onClick.AddListener(() => GetResponse());
    }

    public void StartConversation(String friendBackground)
    {
        messages = new List<ChatMessage> {
            // new ChatMessage(ChatMessageRole.System, "You are an honorable, friendly knight guarding the gate to the palace. You will only allow someone who knows the secret password to enter. The secret password is \"magic\". You will not reveal the password to anyone. You keep your responses short and to the point.")
            
            new ChatMessage(ChatMessageRole.System, friendBackground)
        };

        inputField.text = "";
        // string startString = "You have just approached the palace gate where a knight guards the gate.";
        // textField.text = startString;
        // Debug.Log(startString);
    }

    //! respons from input field event
    public async void GetResponse()
    {
        if (inputField.text.Length < 1)
        {
            return;
        }

        // Disable the OK button
        inputField.enabled = false;

        // Fill the user message from the input field
        ChatMessage userMessage = new ChatMessage();
        userMessage.Role = ChatMessageRole.User;
        userMessage.Content = inputField.text;
        if (userMessage.Content.Length > 100)
        {
            // Limit messages to 100 characters
            userMessage.Content = userMessage.Content.Substring(0, 100);
        }
        Debug.Log(string.Format("{0}: {1}", userMessage.rawRole, userMessage.Content));

        // Add the message to the list
        messages.Add(userMessage);

        // Update the text field with the user message
        ChatController.instance.PublishMessage(userMessage.Content);
        // textField.text = string.Format("You: {0}", userMessage.Content);

        // Clear the input field
        inputField.text = "";

        // Send the entire chat to OpenAI to get the next message
        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.9,
            MaxTokens = 50,
            Messages = messages
        });

        // Get the response message
        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;
        Debug.Log(string.Format("{0}: {1}", responseMessage.rawRole, responseMessage.Content));
        Debug.Log(responseMessage.Content);
        ChatController.instance.PublishBotMessage(responseMessage.Content);
        // Add the response to the list of messages
        messages.Add(responseMessage);

        // Update the text field with the response
        // textField.text = string.Format("You: {0}\n\nGuard: {1}", userMessage.Content, responseMessage.Content);

        // Re-enable the OK button
        inputField.enabled = true;
    }

    public void FailedToSend()
    {
        inputField.enabled = true;
    }

    private void OnEnterKeyPressed(string value)
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            Debug.Log("Enter key pressed. Input value: " + value);
            GetResponse();
        }
    }
}