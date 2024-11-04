// cart.js
let cart = [];

function addToCart(product) {
    cart.push(product);
    updateCartDisplay();
}

function updateCartDisplay() {
    const cartTableBody = document.querySelector('#cart tbody');
    cartTableBody.innerHTML = '';
    let totalPrice = 0;

    cart.forEach((item, index) => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td><img src="${item.image}" alt="${item.name}" width="100"></td>
            <td>${item.name}</td>
            <td>${item.quantity}</td>
            <td>${item.price}</td>
            <td>${item.price * item.quantity}</td>
            <td><button onclick="removeFromCart(${index})">Xóa</button></td>
        `;
        cartTableBody.appendChild(row);
        totalPrice += item.price * item.quantity;
    });

    document.getElementById('total-price').innerText = `Tổng Giá: ${totalPrice}`;
}

function removeFromCart(index) {
    cart.splice(index, 1);
    updateCartDisplay();
}

function proceedToCheckout() {
    // Điều hướng đến trang thanh toán
    window.location.href = 'checkout.html';
}
