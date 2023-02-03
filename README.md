# Docker Runner

`docker run --name mysql-server -e MYSQL_ROOT_PASSWORD='p@$$w0rd' -p 3306:3306 -d mysql`

`dotnet ef dbcontext scaffold 'server=localhost;uid=root;pwd=p@$$w0rd;database=tutorial' Pomelo.EntityFrameworkCore.MySql -o Models --context TutorialContext --data-annotations --use-database-names --force`

docker run -d --name db-mongo \
    -p 27017:27017 \
	-e MONGO_INITDB_ROOT_USERNAME=mongoadmin \
	-e MONGO_INITDB_ROOT_PASSWORD=passw0rd \
	mongo