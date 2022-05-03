DBCC CHECKIDENT ('Orders', RESEED, 0);
DBCC CHECKIDENT ('ProductOrders', RESEED, 0);
DBCC CHECKIDENT ('Images', RESEED, 0);
DBCC CHECKIDENT ('Users', RESEED, 0);
DBCC CHECKIDENT ('Addresses', RESEED, 0);
DBCC CHECKIDENT ('Products', RESEED, 0);

DELETE FROM Addresses
DELETE FROM Images
DELETE FROM ProductOrders
DELETE FROM Orders
DELETE FROM Products
DELETE FROM Users

INSERT INTO Users(FirstName, LastName, Email, Discount, Password) VALUES
('Oana', 'Alexa', 'oana.alexa@a.com', 0, 'oana'),
('Ana', 'Pop', 'ana.pop@yahoo.com', 0.1, 'ana'),
('Andrei', 'Ionescu', 'andrei@gmail.com', 1, 'andrei'),
('Marius', 'Popescu', 'mpopescu@p.com', 0.65, 'marius'),
('Maria', 'Filip', 'maria@a.com', 0.5, 'mara'),
('George', 'Grigorescu', 'ggeorge@yahoo.com', 0.2, 'george'),
('Marius', 'Apostol', 'apostol@a.com', 0.21, 'marius'),
('Mara', 'Filip', 'mara_filip@gmsil.com', 0.13, 'mara'),
('Mara', 'Neagoe', 'mara@n.com', 0.23, 'mara'),
('Oana', 'Pop', 'oanapop@p.com', 0, 'oana')

INSERT INTO Addresses(City, Street, Number, UserId) VALUES
('Arad', 'Bulevardul Revolutiei', '12A', 1),
('Timisoara', 'Calea Aradului', '13', 2),
('Bucuresti', 'Calea Victoriei', '60', 3),
('Brasov', 'Calea Sforii', '20', 4),
('Arad', 'Calea Radnei', '30B', 5),
('Cluj-Napoca', 'Teodor Mihaly', '23', 6),
('Cluj-Napoca', 'Calea Dorobantilor', '66', 7),
('Timisoara', 'Strada Mihai Eminescu', '50C', 8),
('Iasi', 'Strada Mihai Eminescu', '90', 9),
('Iasi', 'Bulevardul Revolutiei', '1', 10)

INSERT INTO Products(Name, Description, Amount, Price, ProductUnit, CoffeeIntensity) VALUES 
('Espresso', 'Cafea simpla', 100, 5.5, 0, 5),
('Ristretto', 'Shot de cafea', 40, 4, 0, 7),
('Cappucino', 'Cafea simpla cu spuma de lapte', 150, 10, 0, 5),
('Latte Machiato', 'Cafea simpla cu spuma de lapte', 250, 12, 0, 5),
('Cappucino vienez', 'Cafea simpla cu spuma de lapte si frisca', 150, 15, 0, 5),
('Cafea boabe', 'Sac de cafea', 500, 30, 1, 6),
('Cafea macinata', 'Pachet de cafea', 500, 25, 1, 5),
('Ice coffee', 'Cafea simpla cu lapte si gheata', 200, 15, 0, 4),
('Double cream', 'Cafea simpla cu dubla spuma de lapte', 200, 15, 0, 4),
('Double coffee', 'Cafea dubla', 100, 8, 0, 8)

INSERT INTO Orders(UserId, OrderStatus) VALUES 
(1, 0),
(1, 1),
(2, 2),
(3, 3),
(5, 0),
(6, 1),
(7, 2),
(8, 3),
(9, 2),
(9, 1)

INSERT INTO Images(AzurePath, ProductId) VALUES
('image1', 1),
('image2', 2),
('image3', 3),
('image4', 4),
('image5', 5),
('image6', 6),
('image7', 7),
('image8', 8),
('image9', 9),
('image10', 10)

INSERT INTO ProductOrders(ProductId, OrderId, Quantity, Name, Description, Amount, Price, CoffeeIntensity) VALUES 
(1, 1, 2, 'Espresso', 'Cafea simpla', 100, 5.5, 5),
(1, 2, 3, 'Ristretto', 'Shot de cafea', 40, 4, 7),
(2, 1, 1, 'Cappucino', 'Cafea simpla cu spuma de lapte', 150, 10, 5),
(3, 3, 4, 'Latte Machiato', 'Cafea simpla cu spuma de lapte', 250, 12, 5),
(4, 4, 1, 'Cappucino vienez', 'Cafea simpla cu spuma de lapte si frisca', 150, 15, 5),
(3, 2, 3, 'Cafea boabe', 'Sac de cafea', 500, 30, 6),
(5, 1, 2, 'Cafea macinata', 'Pachet de cafea', 500, 25, 5),
(7, 5, 3, 'Ice coffee', 'Cafea simpla cu lapte si gheata', 200, 15, 4),
(8, 6, 6, 'Double cream', 'Cafea simpla cu dubla spuma de lapte', 200, 15, 4),
(10, 8, 2, 'Double coffee', 'Cafea dubla', 100, 8, 8)