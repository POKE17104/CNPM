CREATE DATABASE KoiVc;
GO

USE KoiVc;
GO

CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Username NVARCHAR(50) NOT NULL UNIQUE, 
    Password NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    PhoneNumber NVARCHAR(15), 
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Kois (
    KoiId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL, 
    Color NVARCHAR(50), 
    Price DECIMAL(18, 2) NOT NULL CHECK (Price >= 0),
    Breed NVARCHAR(100) NOT NULL,
    ImageUrl NVARCHAR(200) 
);

CREATE TABLE KoiFishes (
    KoiFishId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Color NVARCHAR(50) NOT NULL, 
    Price DECIMAL(18, 2) NOT NULL CHECK (Price >= 0),
    Breed NVARCHAR(100), 
    ImageUrl NVARCHAR(200) 
);

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    CustomerId INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId) 
    ON DELETE CASCADE 
);

CREATE TABLE OrderKois (
    OrderId INT NOT NULL,
    KoiFishId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1 CHECK (Quantity > 0),
    UnitPrice DECIMAL(18, 2) NOT NULL DEFAULT 0,
    PRIMARY KEY (OrderId, KoiFishId),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) 
    ON DELETE CASCADE, 
    FOREIGN KEY (KoiFishId) REFERENCES KoiFish(KoiFishId) 
    ON DELETE CASCADE 
);

INSERT INTO Customer (Name, Email, Username, Password, Address, PhoneNumber) 
VALUES 
('John Doe', 'john.doe@example.com', 'johndoe', 'password123', '123 Le Duan, TPHCM', '1234567890'),
('Jane Smith', 'jane.smith@example.com', 'janesmith', 'securepassword', '456 Nguyen Oanh, Ben Tre', '9876543210'),
('Alice Brown', 'alice.brown@example.com', 'alicebrown', 'mypassword', '789 Le Duc Tho, Ninh Thuan', '1122334455');

INSERT INTO Koi (Name, Color, Price, Breed, ImageUrl) 
VALUES 
('Sakura Koi', 'Red and White', 150.00, 'Kohaku', 'https://onkoi.vn/wp-content/uploads/2022/04/thuc-an-ca-koi-nhat-sakura-growth-color-38-prorein-tang-truong-tang-mau-CA24_05.jpg'),
('Blue Wave Koi', 'Blue and Black', 200.00, 'Asagi', 'https://i.pinimg.com/736x/20/ff/d5/20ffd50b67d9c6b1a2940a0677f985bd.jpg'),
('Golden Shine Koi', 'Gold', 250.00, 'Yamabuki Ogon', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-BdZetj7ejNa30FPg-eKi3DV1asFGcsyvmQ&s');

INSERT INTO KoiFish (Name, Color, Price, Breed, ImageUrl) 
VALUES 
('Sunny Koi', 'Yellow and White', 180.00, 'Kohaku', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTE2EOj6Nu8_x4wo-Cd7W0F1Y4jTCwDVIxYHg&s'),
('Twilight Koi', 'Black and White', 220.00, 'Shiro Utsuri', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbYxugDfiqlQD0_1s4ZUn3y1YgCeCngRN8WQ&s'),
('Emerald Koi', 'Green and White', 300.00, 'Kikusui', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVe9HxEaEfhRYoDPzb24TR2oqVESJXkWud_Q&s');

INSERT INTO Orders(OrderDate, CustomerId) 
VALUES 
(GETDATE(), 1),
(GETDATE(), 2),
(GETDATE(), 3);

INSERT INTO OrderKoi (OrderId, KoiFishId, Quantity, UnitPrice) 
VALUES 
(1, 1, 2, 180.00), 
(2, 2, 1, 220.00), 
(3, 3, 3, 300.00); 
