// checkout.js
document.getElementById('checkout-form').addEventListener('submit', function(event) {
    event.preventDefault();
    
    const name = document.getElementById('name').value;
    const address = document.getElementById('address').value;
    const phone = document.getElementById('phone').value;
    const paymentMethod = document.getElementById('payment-method').value;

    // Gửi dữ liệu đơn hàng đến server (thay thế bằng API thực tế của bạn)
    console.log({
        name,
        address,
        phone,
        paymentMethod,
        cart
    });

    alert('Đơn hàng của bạn đã được xác nhận!');
    // Có thể điều hướng về trang khác hoặc reset giỏ hàng
});
