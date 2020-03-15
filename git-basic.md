# git command line instructions

## git global setup

    git config --global user.name "丛忠伟"
    git config --global user.email "congzw@zqnb.com"

## create a new repository

    git clone https://github.com/congzw/demo-efcore.git
    cd demo-efcore
    touch README.md
    git add README.md
    git commit -m "add README"
    git push -u origin master


## existing folder

    cd existing_folder
    git init
    git remote add origin https://github.com/congzw/demo-efcore.git
    git add .
    git commit -m "Initial commit"
    git push -u origin master

## existing Git repository

    cd existing_repo
    git remote rename origin github-origin
    git remote add origin https://another_origin.git
    git push -u origin --all
    git push -u origin --tags

 

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
   