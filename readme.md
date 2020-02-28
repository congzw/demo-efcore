# a demo for efcore

## change list

- 20200228 init projects

## sqlLite tricks

how to use sqlLite browser with guid

	select 
	quote(Id) as QUOTE, 
	hex(Id) as HEX,
	substr(hex(Id), 1, 8)
	|| '-' || substr(hex(Id), 9, 4)
	|| '-' || substr(hex(Id), 13, 4)
	|| '-' || substr(hex(Id), 17, 4)
	|| '-' || substr(hex(Id), 21, 12) as GUID,
	* from Accounts;
