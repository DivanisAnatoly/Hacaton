* Copy and rename **docker-compose.yml.sample** to **docker-compose.yml**
* Specify your our physicals path to `volums` if needed. For example
```
    volumes:
        - D:/Docker/Databases/factory/backups:/var/opt/mssql/backups
        - D:/Docker/Databases/factory/data:/var/opt/mssql/data
```
* From current path in terminal execute
	* `docker-compose up -d` to start all specified containers from file **docker-compose.yml**
	* `docker-compose down` to stop all specified containers from file **docker-compose.yml**.