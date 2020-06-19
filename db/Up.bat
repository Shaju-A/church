SET path=%~1
SET server=%~2
SET dbname=%~3
SET user=%~4
SET password=%~5

cd /d "%path%"

echo running roundhouse
SET sqlfilesdirectory="%DIR%"
SET constring="initial catalog=%dbname%;Data Source=DESKTOP-8D69L64;integrated security=True;"
echo "%DIR%rh.exe"
"%DIR%rh.exe" /d=%dbname% /f=%sqlfilesdirectory% /cs=%constring% /dt=SQLServer /silent