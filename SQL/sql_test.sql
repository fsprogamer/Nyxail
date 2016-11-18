a)	The names of all salespeople that have an order with Seamens.


select s."Name" from Salesperson s join Orders o
on s.id = o.salesperson_id
join Customer c
on c.id = o.cust_id
where c."Name" = 'Seamens'

b)	The names of all salespeople that do not have any order with Seamens. 

select s."Name" from Salesperson s left join
(select o.salesperson_id from Customer c join Orders o
on c.id = o.cust_id
where c."Name" = 'Seamens') c
on s.id = c.salesperson_id
where c.salesperson_id is null

c)	The names of salespeople that have 2 or more orders. 

select min(s."Name") from Salesperson s join Orders o
on s.id = o.salesperson_id
group by s.id
having count(1)>=2

d)	Write a SQL statement to insert rows into a table called TopSales(Name, Age), 
where a salesperson must have a salary of 100,000 or greater to be included in the table.

create table TopSales (
 "Name" varchar2(100),
 Age number 
);

insert into TopSales("Name", Age) 
select "Name", Age from Salesperson s
where s.salary>=100000;

commit;

