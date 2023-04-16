select * from ACCOUNT;
select * from ACCOUNT_NAME;
UPDATE ACCOUNT SET amount='500', remark='cash' WHERE name='hii'
INSERT INTO ACCOUNT(name) SELECT name FROM ACCOUNT_NAME;
DELETE FROM ACCOUNT_NAME WHERE name='hii';
select sum(amount) from ACCOUNT where type = 'debit';


use [C:\Users\Ary patel\Downloads\New folder (2)\sample_Telly\Telly.mdf] IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ACCOUNT_NAME') BEGIN select * from ACCOUNT_NAME PRINT 'Table exists.' END ELSE BEGIN CREATE TABLE ACCOUNT_NAME(name nvarchar(50), date datetime); PRINT 'Table does not exist.' insert into ACCOUNT_NAME(NAME) values(NULL); print 'ok' END
use [C:\Users\Ary patel\Downloads\New folder (2)\sample_Telly\Telly.mdf] IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ACCOUNT') BEGIN select * from ACCOUNT PRINT 'Table exists.' END ELSE BEGIN CREATE TABLE ACCOUNT(name nvarchar(50), amount numeric(10,0), remark nvarchar(500), type nvarchar(20), date datetime); PRINT 'Table does not exist.' END





