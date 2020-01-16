# How to use git

## Git vs Github

Git is a configuration control application used to manage repositories so that multiple people can work on local repositories which then push to a global repository.

Github is a website which hosts global repositories.

## Local vs Remote

Remember that when you are working with git, there are multiple copies of the repository. The globals (sometimes called remote) repository is the one located on github.com. Each of us has a local repository located on our computers. The git application is what is used to move changes between the local repositories and global repository.

## Branches

A branch is a version of the project that is stored in the repository. Remember that both the local and remote repository have branches, and they might be different. When you create a new branch, it will create a version of the project which has the same code as the branch you switch out of. As you make changes, they will be tracked with that branch. Whenever you switch branches, your machine will swap out all of your files with the version of those files in the other branch.

For each feature you work on, create a branch for that feature. On completion of that feature, create a pull request for that branch (there is a button for this online on github.com) and notify the project leader that you created a pull request. The project leader will merge your request into master, and upon completion, will delete your branch. When you work on the next feature, you will create a new branch off of master.

Try not to work on multiple features on the same branch. As a word of advice, branches are cheep. If you aren't sure if you should create a new branch, you should probably create a new branch.

### Creating a new branch

Use the command:

    git checkout -b my-new-branch-name

In this command, my-new-feature is the name of the new branch.

### Switching to an existing branch

Use the command:

    git checkout my-branch-name

Remember that switching branches will always switch to a local branch

### Pushing code to the remote repository

If you are pushing code to the global repository on an existing branch

    git add .
    git commit -m "Enter your commit message here"
    git push

If you get an error says "did you mean git push --set-upstream origin my-feature" that means that branch doesn't exist on the remote repo. To create the new branch

    git add .
    git commit -m "Enter your commit message here"
    git push --set-upstream origin my-branch-name

In the above command, origin is a reference to the remote repo.

### Pulling code from the remote repository

    git checkout branch-i-want-to-pull-from
    git pull

### Creating a new branch from the current version of master

    git checkout master
    git pull
    git checkout -b my-new-branch-name