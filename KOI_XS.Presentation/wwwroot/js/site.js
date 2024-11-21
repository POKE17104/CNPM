document.addEventListener("DOMContentLoaded", function () {
    // Gắn sự kiện click cho nút mở chat
    const chatToggleButton = document.querySelector('.chat-toggle-button');
    const chatWindow = document.querySelector('.chat-window');

    if (chatToggleButton && chatWindow) {
        chatToggleButton.addEventListener('click', function () {
            chatWindow.classList.toggle('active'); // Thêm/gỡ lớp 'active' cho chat window
        });
    } else {
        console.error("Không tìm thấy nút hoặc cửa sổ chat. Kiểm tra lớp CSS hoặc HTML.");
    }

    // Gõ chữ tự động
    const textArray = [
        "Dịch vụ vận chuyển cá Koi nhanh chóng.",
        "Đảm bảo chất lượng hàng đầu.",
        "Giá cả hợp lý và cạnh tranh.",
        "Hỗ trợ tận tâm, chu đáo."
    ];
    let textIndex = 0;
    let charIndex = 0;
    const typedTextElement = document.getElementById("typed-text");
    const cursorElement = document.querySelector(".cursor");

    function typeText() {
        if (typedTextElement) {
            if (charIndex < textArray[textIndex].length) {
                typedTextElement.textContent += textArray[textIndex].charAt(charIndex);
                charIndex++;
                setTimeout(typeText, 100);
            } else {
                setTimeout(eraseText, 2000);
            }
        }
    }

    function eraseText() {
        if (typedTextElement) {
            if (charIndex > 0) {
                typedTextElement.textContent = textArray[textIndex].substring(0, charIndex - 1);
                charIndex--;
                setTimeout(eraseText, 50);
            } else {
                textIndex = (textIndex + 1) % textArray.length;
                setTimeout(typeText, 500);
            }
        }
    }

    typeText();
});

function sendMessage() {
    const chatInput = document.getElementById('chatInput');
    const chatBody = document.getElementById('chatBody');
    const messageText = chatInput.value.trim();

    if (messageText !== '') {
        const messageElement = document.createElement('div');
        messageElement.classList.add('chat-message');
        messageElement.textContent = messageText;
        chatBody.appendChild(messageElement);
        chatInput.value = '';
        chatBody.scrollTop = chatBody.scrollHeight; 
    }
}
