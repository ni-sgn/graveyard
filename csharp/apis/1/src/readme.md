### you have to install dotnet-ef tools in order to
### make migrations and do the database manipulation operations

```dotnet tool install --global dotnet-ef``` 

'''
for some reason tools need EntityFrameworkCore.Design package 
to work ... 
How does that make sense?

!!! EntityFrameworkCore.SqlServer also contains namespaces
!!! that are needed to make migrations work.
'''