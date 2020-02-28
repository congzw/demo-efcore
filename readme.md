# a demo for efcore

## change list

- 20200228 init projects

## sqlLite tricks

how to use sqlLite browser with guid

	select quote(Id),* from Accounts;
	select * from Accounts where Id == X'00000000000000000000000000000001';
