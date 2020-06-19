SET /P DBNAME=Enter the name of the DB :

echo running roundhouse
cd /d "D:\workspace\church\DB\"
echo "D:\workspace\church\db\Up.bat" "D:\workspace\church\DB\roundhousE\" "127.0.0.1" "%dbname%" "root" "password"
call "D:\workspace\church\db\Up.bat" "D:\workspace\church\DB\roundhousE\" "127.0.0.1" "%dbname%" "root" "password"

