
--Create a stored procedure that will take the author firstname and print all the books published by him 
--with the publisher's name

create proc proc_DisplayAuthorBooks(@aname varchar(10))
as
begin
    select t.title , pub_name "Publisher Name" from titles t
	join publishers p  on t.pub_id = p.pub_id
	join titleauthor ta on ta.title_id = t.title_id
	join authors a on a.au_id = ta.au_id
	where a.au_fname = @aname
end

exec proc_DisplayAuthorBooks 'Marjorie'

-- Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
Alter proc proc_DisplaySalesDetailsByEmployee(@ename varchar(10))
as
begin
	select t.title, sum(t.price) "Price", sum(s.qty) "Quantity", sum((t.price * s.qty)) "Cost"
	from titles t join sales s on t.title_id = s.title_id
	join employee e on e.pub_id = t.pub_id
	where e.fname = @ename
	group by t.title
end

exec proc_DisplaySalesDetailsByEmployee 'Paolo'

--Create a query that will print all names from authors and employees
select au_fname + ' '+ au_lname "Contact Names" from authors
union 
select fname +' '+ lname "Contact Names" from employee

--Create a  query that will float the data from sales,titles, publisher and authors table to print
--title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order

select top 5 t.title, p.pub_name "Publisher Name", CONCAT(au_fname, au_lname) "Author", sum(s.qty) "Quantity ordered",
sum((t.price * s.qty)) "Total Price" from sales s 
join titles t on s.title_id = t.title_id
join publishers p on p.pub_id = t.pub_id
join titleauthor ta on ta.title_id = t.title_id
join authors a on a.au_id =  ta.au_id
group by t.title, p.pub_name,a.au_fname,a.au_lname
order by [Total Price] desc
