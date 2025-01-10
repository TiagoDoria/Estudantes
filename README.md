Criar as bases:
estudantes e authdb

Executar as migrations:
Add-Migration initialAuth -Context AuthContext
update-database -Context AuthContext
Add-Migration initialStudent -Context StudentContext
update-database -Context StudentContext

