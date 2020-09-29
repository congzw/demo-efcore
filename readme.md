# a demo for efcore

## change list

- 20200314 add remote for origin_gitlab_out
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


## how to track multi remotes



tell master to track up-stream to "gitlab_home"

 	- git branch -u gitlab_home/master

	[branch "master"]
	remote = gitlab_home
	merge = refs/heads/master

tell master to track up-stream to "origin"

	- git branch -u origin/master
	
	[branch "master"]
	remote = origin
	merge = refs/heads/master
