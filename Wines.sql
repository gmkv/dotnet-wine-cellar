BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `Wines` (
	`Id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Style`	INTEGER NOT NULL,
	`SellingPrice`	REAL NOT NULL,
	`BuyingPrice`	REAL NOT NULL,
	`BottlesRemaining`	INTEGER NOT NULL,
	`Vineyard`	TEXT NOT NULL,
	`Location`	TEXT NOT NULL,
	`Year`	TEXT NOT NULL,
	`TastingNotes`	TEXT NOT NULL,
	`ImageName`	TEXT
);
INSERT INTO `Wines` (Id,Style,SellingPrice,BuyingPrice,BottlesRemaining,Vineyard,Location,Year,TastingNotes,ImageName) VALUES (1,0,10.5,7.2,50,'Vinex Preslav','Bulgaria','2017','Jasmine, Lime, Honey, Green Apple','sterling-aromatic-white.jpg'),
 (2,1,24.5,17.0,15,'Celtic Wines','Wales','2018','Cherry, Raspberry, Blueberry','dessert-wine.png'),
 (3,2,40.0,30.0,50,'Radius Cabernet','USA','2017','Salt, Herbs, Smoke, Earth, Pepper','full-bodied-red.jpeg'),
 (4,3,35.0,18.5,50,'Chateau Filhot','France','2017','Flower, Petichor','full-bodied-white.jpeg'),
 (5,4,32.5,25.0,15,'Sonoma Coast','USA','2017','Vanilla, Clove, Licorice, Mushroom, Wet Leaves, Tobacco, Cola, Caramel','light-bodied-red-wine.jpg'),
 (6,5,50.0,30.0,5,'Alsace Winery','France','2016','Citrus, Melon, Pear','light-bodied-white-wine.jpg'),
 (7,6,70.0,40.0,20,'Podere Rocche Dei Manzoni','Italy','2015','Strawberries, Plum, Spice','medium-bodied-red-wine.jpeg'),
 (8,7,25.0,15.0,15,'Minkov Brothers','Bulgaria','2017','Strawberry, Orange, Hibiscus, Allspice','rose-wine.jpg'),
 (9,8,100.0,48.5,10,'Nuits St Georges','France','2017','Apples, Honeysuckle, Strawberry, Toasted Brioche','sparkling-wine.jpg');
COMMIT;
