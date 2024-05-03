select * from sales

--Print the storeid and number of orders for the store
select stor_id "Store Id", count(ord_num) "OrderCount for the store"
from sales group by stor_id

--print the number of orders for every title
select t.title_id, count(ord_num) "No.Of Orders"
from titles t join sales s
on t.title_id = s.title_id
group by t.title_id

--print the publisher name and book name
select distinct title "Book", pub_name "Publisher name" 
from publishers p join titles t
on p.pub_id = t.pub_id
order by pub_name

--Print the author full name for all the authors
select CONCAT(au_fname,au_lname) "Authors" from authors

--Print the price of every book with tax (price+price*12.36/100)
select title, (price+(price*12.36)/100) "Total Price" from titles
order by 1

--Print the author name, title name 
select CONCAT(au_fname,au_lname) "Author" , title
from titles t join titleauthor ta
on t.title_id = ta.title_id
join authors a on a.au_id = ta.au_id
order by 2

--print the author name, title name and the publisher name
select CONCAT(au_fname,au_lname) "Author", t.title, p.pub_name "Publisher"
from titles t join titleauthor ta 
on t.title_id = ta.title_id
join authors a on ta.au_id = a.au_id
join publishers p on t.pub_id = p.pub_id
order by t.title

--Print the average price of books pulished by every publicher
select Year(pubdate) "Publish Year" , avg(price) "Average Price of Books published"
from titles group by Year(pubdate)

--print the books published by 'Marjorie'
select t.title from titles t join titleauthor ta
on t.title_id = ta.title_id
join authors a on ta.au_id = a.au_id
where a.au_fname ='Marjorie'

--Print the order numbers of books published by 'New Moon Books'
select distinct s.ord_num "OrderId", p.pub_name from sales s join titles t
on s.title_id = t.title_id
join publishers p on p.pub_id = t.pub_id
where p.pub_name = 'New Moon Books'


--Print the number of orders for every publisher
select t.pub_id, count(ord_num) "No. of Orders" from titles t join publishers p 
on t.pub_id = p.pub_id
join sales s on s.title_id = t.title_id
group by t.pub_id


--print the order number , book name, quantity, price and the total price for all orders
select s.ord_num "OrderId", t.title "Book", s.qty "Quantity", t.price "Price", (t.price * s.qty) "Total Price"
from sales s join titles t
on s.title_id = t.title_id
order by t.title

--print the total order quantity for every book
select title_id, sum(qty) "Total Quantity Sold" from sales
group by title_id

--print the total ordervalue for every book
select s.title_id, sum(s.qty) "Total Quantity ordered", sum(s.qty*t.price) "Order Value" 
from sales s join titles t 
on s.title_id = t.title_id
group by s.title_id

--print the orders that are for the books published by the publisher for which 'Paolo' works for
select s.ord_num "OrderId", e.pub_id "PublisherId for whom Paolo works"
from sales s join titles t
on s.title_id = t.title_id
join employee e on t.pub_id = e.pub_id
where e.fname = 'Paolo';
