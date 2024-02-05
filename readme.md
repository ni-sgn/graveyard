# Print information about branches 
    git branch     (local  branches)
    git branch -r  (remote branches)
    git branch -a  (local + remote branches)
    git branch -v  (verbose list)
    git branch -vv (doubly verbose, shows which local branches are tracking remote branches)

# Prints information about remote repo, its branches and local branch refs to those branches
    git remote show origin

# Remove the ref to the branch which is not tracked 
    git remote prune origin 

# Delete remote branch 
    git push origin -d remote-branch-name  

# Delete local branch 
    git branch -d branch-name
    git branch -D branch-name  (force delete)

# Print info on the history of commits 
    git log   
    git log branch-name

# Prints lost commits
    git reflog

# Print info on the modified files
    git status

# Print all the changes(differences) in a commit
    git show commit-id
    git show HEAD       (last commit changes)
    git show HEAD~1     (go back 1 extra commit)

# Upstream branch is a remote branch hosted on Github or Bitbucket, it's the branch that is fetched pulled without arguments
# To create an upstream branch, currently checked-out branch will track this upstream
    git push --set-upstream origin upstream-branch-name 

# After pruning a remote repository the reference which was connecting to remote
# branch is gone, then when you check out previously upstreamed branch, it will
# see that the reference is gone(pruned), and we have to manually tell the branch not to look at upstream anymore 
    git branch --unset-upstream

# Reverting in git does not delete the whole commit, instead it adds a new
# commit where the changes made in the commit are reverted. This is good, because
# it leaves better history(breadcrumbs) of what actions took place during the development
    git revert commit

# Reset (complicated, needs repetition), basically --hard, --mix or --soft, 
# --hard puts HEAD and main refs to specific commit, deletes rest of the commit
# history(commit tree), also deletes everything that is staged(stage index tree) and 
# files that are not even staged(working directory tree).
# in case of mixed, staged changes pop out from staged intex tree to working
# directory tree.
# Reset does not delete commit when goig back, but rest of the commits become orphaned
# until garbage collector runs, then they are deleted(30 days)
    git reset --hard
    git reset --mixed
    git reset --soft


# Resources
    https://www.atlassian.com/git/tutorials/learn-git-with-bitbucket-cloud

# To revert untracked files you have to force clean them
git clean -f [filename | folder] 
