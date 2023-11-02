-- Создание таблицы Категории по идее, тут только ID и наменование категории
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);

-- Создание таблицы Продукты по идее, тут только ID и наменование товара
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);

-- В этой таблице мы уже связываем, какой товар относится к какой категории MANYTOMANY
CREATE TABLE ProductCategory (
	ProductCategoryID INT,
    ProductID INT,
    CategoryID INT,
    PRIMARY KEY (ProductID, CategoryID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE Sales (
    SaleID INT IDENTITY(1,1) PRIMARY KEY, 
    SaleDate DATETIME NOT NULL,
    ProductID INT NOT NULL, 
    Quantity INT NOT NULL,
    SaleAmount DECIMAL(10, 2) NOT NULL
);

-- Заполняем тестовыми данными категории(Было взято из генератора моковых данных)
INSERT INTO Categories (CategoryID, Name)
VALUES
    (1, 'Электроника'),
    (2, 'Одежда'),
    (3, 'Бытовая техника'),
    (4, 'Книги'),
    (5, 'Онлайн игры');

-- Заполняем тестовыми данными продукты(Было взято из генератора моковых данных)
INSERT INTO Products (ProductID, Name)
VALUES
    (1, 'Смартфон'),
    (2, 'Футболка'),
    (3, 'Холодильник'),
    (4, 'Роман'),
    (5, 'Ноутбук'),
	(6, 'GTAV'),
	(7, 'CSGO'),
	(8, 'Какой-то левый товар'),
	(9, 'CSGO руководство(Оно лежит в двух категориях)');


-- Указываем что к кому относится
INSERT INTO ProductCategory (ProductCategoryID, ProductID, CategoryID)
VALUES
    (1, 1, 1),  
    (2, 2, 2), 
    (3, 3, 3),
    (4, 4, 4),
    (5, 5, 1),
	(6, 6, 5),
	(8, 7, 5);

-- Личная импровизация, это таблица которая показывает какое количество товара, когда и за какую цену было продано
INSERT INTO Sales (SaleDate, ProductID, Quantity, SaleAmount)
VALUES
    (Convert(Datetime, '2023-01-05 10:30:00', 120), 1, 2, 999.99),
    (Convert(Datetime, '2023-01-10 14:15:00', 120), 2, 5, 49.95),
    (Convert(Datetime, '2023-02-20 09:45:00', 120), 3, 1, 799.99),
    (Convert(Datetime, '2023-03-03 16:20:00', 120), 4, 3, 38.97),
    (Convert(Datetime, '2023-03-12 11:00:00', 120), 5, 2, 1799.98),
	(Convert(Datetime, '2023-01-12 17:03:00', 120), 5, 5, 2980.02),
    (Convert(Datetime, '2023-03-12 15:23:00', 120), 5, 8, 3258.11),
    (Convert(Datetime, '2023-01-12 11:00:00', 120), 9, 19, 123.45);


-- Пишем интересный запросик, типа аналитический для руководства
with tbl_count_of_salles_products as(
	select 
		a.ProductID,
		sum(a.Quantity) sumQuantity, 
		sum(a.saleamount) sumSaleAmount 
	from Sales a 
	group by a.ProductID
),
tbl_first_sell_of_products_prep as(
	select 
		a.ProductID,
		row_number() over (partition by a.productid order by a.SaleDate desc) rownum,
		a.SaleDate
	from Sales a 
),
tbl_first_sell_of_products as(
	select 
		a.Productid, 
		a.saledate 
	from tbl_first_sell_of_products_prep a
	where a.rownum = 1
)
SELECT 
	a.Name 'Продукт', 
	ISNULL(c.Name, 'Категории нет(Сорян =((()') 'Категория',
	d.sumQuantity 'Количество проданного',
	d.sumSaleAmount 'На общую сумму',
	e.SaleDate 'Дата первой продажи'
FROM Products a
LEFT JOIN ProductCategory b ON a.ProductID = b.ProductID
LEFT JOIN Categories c ON b.CategoryID = c.CategoryID
inner join tbl_count_of_salles_products d on a.Productid = d.productid
inner join tbl_first_sell_of_products e on a.ProductID = e.ProductID