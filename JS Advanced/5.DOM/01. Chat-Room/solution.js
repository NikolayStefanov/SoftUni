function solve() {
   let sendButton = document.querySelector("#send");
   let textArea = document.getElementById("chat_input");
   sendButton.addEventListener("click", sendMessage)

   function sendMessage() {
      let message = textArea.value;
      let newMessage = document.createElement("div");

      newMessage.classList.add('message', 'my-message');
      newMessage.textContent = message;
      document.querySelector("#chat_messages").appendChild(newMessage);

      textArea.value = '';
   }
}