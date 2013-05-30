@ECHO OFF
rake %*
IF %ERRORLEVEL%==9009 GOTO:rake_failed
GOTO:EOF

:rake_failed
type build_support\Ruby_Not_Installed.txt
GOTO :EOF