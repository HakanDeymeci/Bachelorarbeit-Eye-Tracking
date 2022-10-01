using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour
{
    public string username;
    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public int maxMessages = 25;
    public Color playerMessage, info;

    
    string[] Lines = { "is that a girl? lmao", "looking for egirl", "this game is boring", "anyone need a duo?","nasil oluyor bu oyun", "someone gift me skins pls","can you ban xVinniQ pls @Mods", "lfg", "join my dc", };
    string[] usernames = { "natsumi77", "m4dara", "xVinniQ", "qhren", "Prof","grndmstr","g-zs", "avgsageenjoyer", "manu97", "destroyer21","yaralikartal" };

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    [SerializeField]
    List<Message> messageList = new List<Message>();

    public string randomPicker(string[] array)
    {
       
        string picked = "";
        int randIndex;

        randIndex = Random.Range(0,array.Length);
        picked = array[randIndex];

        return picked;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (period > Random.Range(0.4f, 1f))
        {
            SendMessageToChat(randomPicker(usernames) + ": " + randomPicker(Lines), Message.MessageType.playerMessage);
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;

            if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }
        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("Pressed Space", Message.MessageType.info);
                Debug.Log("Space");
            }
        }
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();
        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }
    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;
        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }
        return color;
    }

    public Image tutPopup;
    public void deleteInfo()
{
        Destroy(tutPopup);
}

}


 

    

   



[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;
    public enum MessageType
    {
        playerMessage,
        info
    }

}

