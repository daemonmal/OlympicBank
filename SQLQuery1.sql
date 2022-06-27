create table userAccounts(
	userName varchar(20) not null,
	userPassword varchar(20) not null,
	customerId int identity(1111,1) not null,
	accountCreationDate datetime default(GETDATE()),
	loginAttempts int default(0),
	accountIsActive bit default(1), 
	userIsAdmin bit default(0),
	constraint pk_uName primary key(userName),
	constraint unk_uName unique(userName),
	constraint chk_uName check (len(userName)>5),
	constraint chk_uPass check (len(userPassword)>10),
	constraint chk_loginAtt check (loginAttempts <= 3),	
	constraint unk_cusId unique(customerId)
	);

insert into userAccounts (userName,userPassword) values('bilbo1234','pass1234567');
insert into userAccounts (userName,userPassword) values('johndoe1234','pass1234567');
insert into userAccounts (userName,userPassword) values('appleseed1234','pass1234567');
insert into userAccounts (userName,userPassword) values('oleson1234','pass1234567');
insert into userAccounts (userName,userPassword, userIsAdmin) values('admin123','admin123456',1);
select loginAttempts from userAccounts where userName = 'bilbo1234';
update userAccounts set loginAttempts=loginAttempts-1 where userName='bilbo1234';
select * from userAccounts order by customerId;

create table bankAccounts(
	accountId int identity(1111,1) not null,
	customerId int,
	accountType varchar(9) default('Checking'),
	accountBalance money default(0),
	creationDate datetime default(GETDATE()) not null,
	branchId int default(105),
	constraint pk_accId primary key(accountId),
	constraint unk_accId unique(accountId),
	constraint fk_cusId2 foreign key(customerId) references userAccounts(customerId),
	constraint chk_accType check (accountType in ('Checking','Savings','Loan')),
	constraint chk_branchId check (branchId in (105,106,107)),
	);

insert into bankAccounts (customerId,accountType,accountBalance) values(1111,'Savings',15000);
insert into bankAccounts (customerId,accountType,accountBalance) values(1112,'Checking',12000);
insert into bankAccounts (customerId,accountType,accountBalance) values(1113,'Loan',22000);
select * from bankAccounts;
select customerId from bankAccounts where accountId=1116;

create table Transactions(
	transactionId bigint identity(1456879,1) not null,
	transactionType varchar(9),
	amount money,
	fromAccountId int,
	fromCustomerId int,
	toAccountId int default(0),
	toCustomerId int default(0),
	transactionDate date default(GETDATE()),
	constraint pk_tranId primary key(transactionId),
	constraint unk_tranId unique(transactionId),
	constraint chk_tranType check (transactionType in ('Withdraw','Deposit','Transfer')),
	constraint fk1_fromAccId foreign key(fromAccountId) references bankAccounts(accountId),
	--constraint fk2_fromAccId foreign key(toAccountId) references bankAccounts(accountId),
	constraint fk3_customerId foreign key(fromcustomerId) references userAccounts(customerID),
	--constraint fk4_customerId foreign key(tocustomerId) references userAccounts(customerID),
	);

insert into Transactions (transactionType,amount,fromAccountId,fromCustomerId) values('Withdraw',500,1113,1113)
select * from Transactions;
