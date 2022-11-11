# Race-Game

<b>To get this repository:</b>

Right click where you want the repository to be saved localy on your computer.

The select "Git Bash Here"

In the Bash Shell type: "git clone https://github.com/Pieterv24/Race-Game.git"

now you have the repository stored localy.

<b>To Save github login credentials:</b>

type "git config credential.helper store"

after you've done that you you'll need to enter your credentials one more time.
after that git will save your credentials and you wont have to enter them again.

<b>to commit:</b>

mark all your files (New files or edited files or removed files) as staged by typing: "git add FILENAME"

after that type: "git commit -m MESSAGE"

to add your commit to the shared repository type: "git push origin YOUR_BRANCH_NAME"

in this YOUR_BRANCH_NAME will always be your name to add it to your branch.

unless you want to add the code directly to the main branch but this is highly unlikely.

once in a while we will merge all branches to test or evaluate the code.

<b>Adding the current main code from the master branch to your branch</b>

Type: "git checkout YOUR_BRANCH_NAME"

now to merge the master branch to your branch type: "git merge master"

now your code is merged with the main branch and you can go on.

<b>Adding your code to the shared repository</b> 

type: "git push origin YOUR_BRANCH_NAME"

never type master here.

merging with the master will only be done with the group.