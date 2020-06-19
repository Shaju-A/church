SET /P DBNAME=Enter the name of the DB :

echo running roundhouse
cd /d "D:\workspace\churchgith\DB\"
echo "D:\workspace\churchgith\db\Up.bat" "D:\workspace\church\DB\roundhousE\" "127.0.0.1" "%dbname%" "root" "password"
call "D:\workspace\churchgith\db\Up.bat" "D:\workspace\churchgith\DB\roundhousE\" "127.0.0.1" "%dbname%" "root" "password"

