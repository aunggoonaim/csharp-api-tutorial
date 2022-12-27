# Docker Runner

`docker run --name mysql-server -e MYSQL_ROOT_PASSWORD='p@$$w0rd' -d mysql`

`dotnet ef dbcontext scaffold 'server=localhost;uid=root;pwd=p@$$w0rd;database=tutorial' Pomelo.EntityFrameworkCore.MySql -o Models --context TutorialContext --data-annotations --use-database-names --force`