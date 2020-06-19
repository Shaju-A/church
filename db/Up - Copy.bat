SET path=%~1
SET server=%~2
SET dbname=%~3
SET user=%~4
SET password=%~5

cd /d "%path%"

echo running roundhouse
SET sqlfilesdirectory="%DIR%"
SET constring="Database=%dbname%;Data Source=%server%;User Id=%user%;Password=%password%;Convert Zero Datetime=True;Allow Zero Datetime=True;"
echo "%DIR%rh.exe"
"%DIR%rh.exe" /d=%dbname% /f=%sqlfilesdirectory% /cs=%constring% /dt=MySQL /silent