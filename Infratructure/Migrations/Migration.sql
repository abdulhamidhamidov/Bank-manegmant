create table customers(
                          customerid serial primary key,
                          firstname varchar(50),
                          lastname varchar(50),
                          city varchar(20),
                          phonenumber varchar(13),
                          pancardno varchar(16),
                          dob date,
                          createdat date,
                          deletedat date
);

create table branches(
                         branchid serial primary key,
                         branchname varchar(50),
                         branchlocation varchar(50),
                         createdat date,
                         deletedat date
);

create table loans(
                      loanid serial primary key,
                      loanamount decimal(10,2),
                      dateissued date,
                      createdat date,
                      deletedat date,
                      customerid int references customers(customerid),
                      branchid int references branches(branchid)
);
create type accountstatus as enum('active', 'inactive')
create type accounttype as enum('premium', 'gold', 'silver')

create table accounts(
                         accountid serial primary key,
                         balance decimal(10,2),
                         accountstatus accountstatus,
                         accounttype accounttype,
                         currency varchar(10),
                         createdat date,
                         deletedat date
);

create type transactionstatus as enum('failed', 'successfull', 'canceled', 'waited')


create table transactions(
                             transactionid serial primary key,
                             transactionstatus transactionstatus,
                             dateissued date,
                             amount decimal(10,2),
                             createdat date,
                             deletedat date,
                             fromaccountid int references accounts(accountid),
                             toaccountid int references accounts(accountid)
);

insert into branches( branchname, branchlocation, createdat, deletedat) values ( @Branchname, @BranchLocation, @CreatedAt, @DeletedAt);
select * from branches;
select * from branches where branchid=@Id;
delete from branches where branchid=@Id;
update branches set branchname=@Branchname, branchlocation=@BranchLocation, createdat=@CreatedAt, deletedat=@DeletedAt where branchid=@Id;

insert into accounts( balance, accountstatus, accounttype, currency, createdat, deletedat) values ( @Balance, @AccountStatus, @AccountType, @Currency,@CreatedAt, @DeletedAt);
select * from accounts;
select * from accounts where accountid=@Id;
delete from accounts where accountid=@Id;
update accounts set balance=@Balance, accountstatus=@AccountStatus, accounttype=@AccountType, currency=@Currency,createdat=@CreatedAt, deletedat=@DeletedAt where accountid=@Id;

insert into loans( loanamount, dateissued, createdat, deletedat, customerid, branchid) values( @LoanAmount, @DateIssued, @CreatedAt, @DeletedAt, @CustomerId, @BranchId); 

select * from loans;
select * from loans where loanid=@Id;
delete from loans where loanid=@Id;
update loans set loanamount=@LoanAmount, dateissued=@DateIssued, createdat=@CreatedAt, deletedat=@DeletedAt, customerid=@CustomerId, branchid=@BranchId where loanid=@Id;

INSERT INTO transactions (transactionstatus, dateissued, amount, createdat, deletedat, fromaccountid, toaccountid) VALUES (@TransactionStatus, @DateIssued, @Amount, @Createdat, @DeletedAt, @FromaccountId, @ToaccountId);
SELECT * FROM transactions;
SELECT * FROM transactions WHERE transactionid = @Id;
DELETE FROM transactions WHERE transactionid = @Id;
UPDATE transactions SET transactionstatus = @TransactionStatus,dateissued = @DateIssued,amount = @Amount,createdat = @Createdat,deletedat = @DeletedAt,fromaccountid = @FromaccountId,toaccountid = @ToaccountId WHERE transactionid = @Id;                







