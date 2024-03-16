CREATE DATABASE store;
USE store;

CREATE TABLE items(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	name VARCHAR(255) NOT NULL,
	manufacturer VARCHAR(255) NOT NULL,
	description TEXT NOT NULL,
	price DECIMAL(4, 4) NOT NULL
);

CREATE TABLE stock(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	amount INT NOT NULL,
	items_id INT NOT NULL REFERENCES items(id)
);

ALTER TABLE items ADD stock_id INT NOT NULL REFERENCES stock(id); 

CREATE TABLE users(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	username VARCHAR(255) NOT NULL,
	email VARCHAR(255) NOT NULL,
	password VARCHAR(255) NOT NULL,
	type INT NOT NULL
);

CREATE TABLE reviews(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	rating INT NOT NULL,
	title VARCHAR(255) NOT NULL,
	description TEXT NOT NULL,
	user_id INT NOT NULL REFERENCES users(id),
	item_id INT NOT NULL REFERENCES items(id)
);

CREATE TABLE item_specifications(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	name VARCHAR(255) NOT NULL,
	value TEXT NOT NULL,
	item_id INT NOT NULL REFERENCES items(id)
);

CREATE TABLE invoices(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	total DECIMAL(4, 4) NOT NULL,
	tax DECIMAL(4, 4) NOT NULL,
	paid DECIMAL(4, 4) NOT NULL,
	due DECIMAL(4, 4) NOT NULL,
	date_created DATE NOT NULL,
	date_due DATE NOT NULL,
	date_closed DATE
);

CREATE TABLE invoice_lines(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	amount INT NOT NULL,
	price DECIMAL(4, 4) NOT NULL,
	tax CHAR(1),
	invoice_id INT NOT NULL REFERENCES invoices(id),
	item_id INT REFERENCES items(id)
);

CREATE TABLE sales(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	user_id INT NOT NULL REFERENCES users(id),
	invoice_id INT NOT NULL REFERENCES invoices(id)
);

CREATE TABLE sale_item(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	item_id INT NOT NULL REFERENCES items(id),
	sale_id INT NOT NULL REFERENCES sales(id),
);

/* Selektuje item koji se prodaje i sve njegove deskripcije
	primer item_id = 0
 */
SELECT name, manufacturer, description, price FROM items WHERE items.id = 0;
SELECT name, value FROM item_specifications WHERE item_specifications.item_id = 0;

/* Selektuje kupca, prodaju, broj prodatih produkta i racun preko ID-a narudzbine 
	primer sale_id = 2
*/
SELECT users.username, users.email, COUNT(items.id) AS 'Item Count', invoices.total, invoices.paid, invoices.due, invoices.date_created, FROM sales
INNER JOIN users ON users.id = sales.user_id
INNER JOIN invoices ON invoices.id = sales.invoice_id
INNER JOIN sale_item ON sale_item.sale_id = sales.id
INNER JOIN items ON items.id = sale_item.item_id
WHERE sales.id = 2;

/* Selektuje sve recenzije korisnika za odredjen predmet
	primer user_id = 3, item_id = 13
*/
SELECT rating, title, description From reviews
WHERE user_id = 3 AND item_id = 13;

/* Izabere korisnika koji ima najvise narudzbina */
SELECT users.id, COUNT(users.id) FROM sales
INNER JOIN users ON users.id = sales.user_id
GROUP BY users.id
ORDER BY COUNT(users.id) DESC;

/* Izabere maximalnu ne-placenu vrednost racuna */
SELECT MAX(invoices.due) FROM invoices;