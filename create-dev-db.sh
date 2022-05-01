/opt/mssql-tools/bin/sqlcmd -U sa -P $SQL_PASSWORD -e -i scripts/CreateDb.sql

for script in scripts/Tables/*.sql
    do /opt/mssql-tools/bin/sqlcmd -U sa -P $SQL_PASSWORD -e -i $script
done